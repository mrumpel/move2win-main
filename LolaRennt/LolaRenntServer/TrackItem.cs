using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaRenntServer
{
    public class TrackItem

    {

        public Point Point { get; set; } //точка пути

        public long Timestamp { get; set; } //время отметки точки (тики)

    }
}
