using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaRenntServer
{
    public class Room

    {

        public string Name { get; set; } //название комнаты

        public Driver Driver1 { get; set; } //создатель комнаты

        public Driver Driver2 { get; set; } //соперник

        public Point Start { get; set; } //начальная точка

        public Point Finish { get; set; } //конечная точка

        public Status Status { get; set; } //статус гонки

        public long Timestamp { get; set; } //время создания комнаты (тики)

        public BetItem[] Bets { get; set; } //ставки
    }
}
