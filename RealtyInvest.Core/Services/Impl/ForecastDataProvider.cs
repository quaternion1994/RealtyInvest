using System.Collections.Generic;
using RealtyInvest.DataModel.Models;

namespace RealtyInvest.Core.Services.Impl
{
    public class ForecastDataProvider : IForecastDataProvider
    {
        public const string Url = "";
        public LinkedList<RawPriceHistory> GetPriceHistory()
        {
            LinkedList<RawPriceHistory> list = new LinkedList<RawPriceHistory>();
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 51,
                Fact2 = 560,
                Fact3 = 0
            });
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 53,
                Fact2 = 632,
                Fact3 = 1
            });          
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 56,
                Fact2 = 749,
                Fact3 = 2
            });
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 80,
                Fact2 = 865,
                Fact3 = 2
            }); 
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 80,
                Fact2 = 992,
                Fact3 = 2
            }); 
            list.AddLast(new RawPriceHistory
            {
                Fact1 = 78,
                Fact2 = 1185,
                Fact3 = 3
            });

            return list;
        }
    }
}