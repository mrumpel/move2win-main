using LolaRenntFBServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaRenntProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var fbService = new FBService();
            var e = fbService.LoadRoomsByStatus(LolaRenntServer.Status.End);

            //fbService.FakeCreateUserAsync(49);
            var u = fbService.LoadUserById("User-04f346be60be441aa490e1b6a7bb4ce7");

            Console.ReadKey();
        }
    }
}
