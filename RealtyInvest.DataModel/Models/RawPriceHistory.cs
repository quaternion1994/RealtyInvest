using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyInvest.DataModel.Models
{
    public class RawPriceHistory
    {
        public DateTime Time { get; set; }
        public int Fact1 { get; set; }
        public int Fact2 { get; set; }
        public int Fact3 { get; set; }
    }
}
