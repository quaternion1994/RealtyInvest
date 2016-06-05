using System.Collections.Generic;
using RealtyInvest.DataModel.Models;

namespace RealtyInvest.Core.Services
{
    public interface IForecastDataProvider
    {
        LinkedList<RawPriceHistory> GetPriceHistory();
    }
}