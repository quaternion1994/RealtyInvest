using System.Collections.Generic;
using System.IO;
using System.Linq;
using RealtyInvest.DataModel.Models;

namespace RealtyInvest.Core.Services.Impl
{
    public class ForecastDataProvider : IForecastDataProvider
    {
        public const string Url = "";
        public RawPriceHistory[] GetPriceHistory(string filename)
        {
            LinkedList<RawPriceHistory> list = new LinkedList<RawPriceHistory>();
            var content = File.ReadAllLines(filename);
            foreach (var line in content)
            {
                var cells = line.Split('\t', ' ');
                list.AddLast(new RawPriceHistory
                {
                    Time = double.Parse(string.IsNullOrEmpty(cells[0]) ? "0" : cells[0]),
                    Fact1 = double.Parse(string.IsNullOrEmpty(cells[1]) ? "0" : cells[1]),
                    Fact2 = double.Parse(string.IsNullOrEmpty(cells[2]) ? "0" : cells[2]),
                    Fact3 = double.Parse(string.IsNullOrEmpty(cells[3]) ? "0" : cells[3]),
                    Fact4 = double.Parse(string.IsNullOrEmpty(cells[4]) ? "0" : cells[4]),
                    Price = double.Parse(string.IsNullOrEmpty(cells[5]) ? "0" : cells[5]),
                });
            }

            return list.ToArray();
        }
    }
}