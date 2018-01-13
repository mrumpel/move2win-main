using Firebase.Database;
using Firebase.Database.Query;
using LolaRenntServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolaRenntFBServer
{
    public class FBService
    {
        private string fbPath = "https://tstapp-eedbc.firebaseio.com/";

        private string token = "vrwQwApj78sb2MpxTAVd44aMdmhUTnoIY0LR4FwG";

        private string rootRoom = "testrooms1";

        private string rootUser = "testusers1";

        #region Rooms

        public List<Room> LoadRoomsByStatus(Status status)
        {
            return LoadRoomsByStatusAsync(status).Result;
        }

        public async Task<List<Room>> LoadRoomsByStatusAsync(Status status)
        {
            var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

            var rooms = await firebase
                .Child(rootRoom)
                .OrderByKey()
                .OnceAsync<Room>();


            var result = new List<Room>();
            foreach (var room in rooms)
            {
                if (room.Object.Status == status)
                    result.Add(room.Object);
            }

            return result;
        }

        public Room LoadRoomById(string roomId)
        {
            return LoadRoomByIdAsync(roomId).Result;
        }

        public async Task<Room> LoadRoomByIdAsync(string roomId)
        {
            var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

            var rooms = await firebase
                .Child(rootRoom)
                .OrderByKey()
                .EqualTo(roomId)
                .OnceAsync<Room>();

            foreach (var room in rooms)
            {
                if (room != null)
                    return room.Object;
            }

            return null;
        }

        #endregion

        #region Users

        public User LoadUserById(string userId)
        {
            return LoadUserByIdAsync(userId).Result;
        }

        public async Task<User> LoadUserByIdAsync(string userId)
        {
            var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

            var users = await firebase
                .Child(rootUser)
                .OrderByKey()
                .EqualTo(userId)
                .OnceAsync<User>();

            foreach (var user in users)
            {
                if (user != null)
                    return user.Object;
            }

            return null;
        }

        public void FakeCreateUser(int count)
        {
            FakeCreateUserAsync(count).Wait();
        }

        private async Task FakeCreateUserAsync(int count)
        {
            var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var name = "User-" + Guid.NewGuid().ToString("N");
                var user = new User()
                {
                    Id = name,
                    Points = (random.Next(10) + 1) * 100,
                    Name = name
                };

                await firebase
                    .Child(rootUser)
                    .Child(user.Name)
                    .PutAsync(user);
            }

        }

        #endregion

        #region Bet

        public bool SaveBet(string roomId, BetItem bet)
        {
            return SaveBetAsync(roomId, bet).Result;
        }

        public async Task<bool> SaveBetAsync(string roomId, BetItem bet)
        {
            var room = LoadRoomById(roomId);
            var user = LoadUserById(bet.UserId);

            if (room == null || user == null || room.Status != Status.Full)
                return false;

            if (bet.Amount < user.Points)
            {
                var bets = room.Bets.ToList();
                bets.Add(bet);
                room.Bets = bets.ToArray();

                user.Points = user.Points - (bet.Amount ?? 0);

                var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

                await firebase
                    .Child(rootUser)
                    .Child(user.Name)
                    .PutAsync(user);

                await firebase
                    .Child(rootRoom)
                    .Child(room.Name)
                    .PutAsync(room);

                return true;
            }

            
            return false;
        }

        #endregion
    }
}
