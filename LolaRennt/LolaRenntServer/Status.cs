using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaRenntServer
{
    public enum Status

    {

        Empty = 0, //только создатель комнаты, ожидающий соперника

        Full = 1, //создатель и соперник

        Start = 2, //гонка началась

        End = 3, //гонка закончилась

        Break = 4, //гонка отменена

        Processed = 5 //ставки обработаны
    }
}
