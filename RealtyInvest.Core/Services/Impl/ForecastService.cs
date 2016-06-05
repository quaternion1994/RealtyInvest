using System;
using MathNet.Numerics.LinearRegression;
using RealtyInvest.Common;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.UnitsOfWorks;

namespace RealtyInvest.Core.Services.Impl
{
    public class ForecastService : IForecastService
    {
        private readonly IUnitOfWorkFactory _factory;
        public ForecastService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ServiceResult<ChartPoint[]> GetLandPriceForecast(HistoryPeriod period)
        {
            ServiceResult<ChartPoint[]> result = new ServiceResult<ChartPoint[]>(new ChartPoint[0]);
            try
            {
                using (var uow = _factory.CreateUnitOfWork())
                {
                    result.Value = new[]
                    {
                        new ChartPoint {X = DateTime.Now.AddYears(-1), Y = 100 },
                        new ChartPoint {X = DateTime.Now.AddYears(-2), Y = 120 },
                        new ChartPoint {X = DateTime.Now.AddYears(-3), Y = 90 },
                        new ChartPoint {X = DateTime.Now.AddYears(-4), Y = 150 },
                    };
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public void Regression()
        {
            double[] p = MultipleRegression.QR(
                    new[] { new[] { 1.0, 4.0 }, new[] { 2.0, 5.0 }, new[] { 3.0, 2.0 } },
                    new[] { 15.0, 20, 10 },
                    intercept: true);
        }
    }
}
