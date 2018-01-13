using Firebase.Database;
using Firebase.Database.Query;
using LolaRenntServer;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolaRenntFBServer
{
    public class FBService
    {
        private string fbPath = "https://tstapp-eedbc.firebaseio.com/";

        private string token = "vrwQwApj78sb2MpxTAVd44aMdmhUTnoIY0LR4FwG";

        private string root = "testrooms1";

        public List<Room> LoadRoomsByStatus(Status status)
        {
            return LoadRoomsByStatusVoid(status).Result;
        }

        private async Task<List<Room>> LoadRoomsByStatusVoid(Status status)
        {
            var firebase = new FirebaseClient(fbPath, new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(token) });

            var rooms = await firebase
                .Child(root)
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
    }
}
