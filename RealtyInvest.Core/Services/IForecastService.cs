using RealtyInvest.Common;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;

namespace RealtyInvest.Core.Services
{
    public interface IForecastService
    {
        ServiceResult<ChartPoint[]> GetLandPriceForecast(HistoryPeriod period);
    }
}