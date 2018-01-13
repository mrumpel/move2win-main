using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaRenntServer
{
    public class Driver

    {

        public string Name { get; set; } //имя гонщика

        public TrackItem[] Track { get; set; } //путь гонщика

        public bool Ready { get; set; } //готов к старту гонки

    }
}
