using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearRegression;
using RealtyInvest.Common;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.UnitsOfWorks;
using System.Linq;

namespace RealtyInvest.Core.Services.Impl
{
    public class ForecastService : IForecastService
    {
        private readonly IUnitOfWorkFactory _factory;
        private readonly IForecastDataProvider _dataProvider;

        public ForecastService(IUnitOfWorkFactory factory, IForecastDataProvider dataProvider)
        {
            _factory = factory;
            _dataProvider = dataProvider;
        }

        private RawPriceHistory[] _history;
        public ServiceResult<ChartPoint[]> GetLandPriceForecast(HistoryPeriod period, string src)
        {
            ServiceResult<ChartPoint[]> result = new ServiceResult<ChartPoint[]>(new ChartPoint[0]);
            try
            {
                using (var uow = _factory.CreateUnitOfWork())
                {
                    _history = _dataProvider.GetPriceHistory(src);
                    LinkedList<ChartPoint> list = new LinkedList<ChartPoint>();
                    
                    for (int i = 0; i < _history.Length; i++)
                        list.AddLast(new ChartPoint() { X = _history[i].Time, Y = _history[i].Price });

                    list.AddLast(Regression(new RawPriceHistory
                    {
                        Fact1 =  AdoptableFilter(_history.Select(x=>x.Fact1).ToArray()),
                        Fact2 = AdoptableFilter(_history.Select(x => x.Fact2).ToArray()),
                        Fact3 =  AdoptableFilter(_history.Select(x=>x.Fact3).ToArray()),
                        Fact4 = AdoptableFilter(_history.Select(x => x.Fact4).ToArray()),
                        Time = list.Last.Value.X+0.25
                    }));

                    result.Value = list.ToArray();
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        private const double alpha = 0.3;
        private const int qlen = 4;

        private double ComputeK(double[] backs)
        {
            double k = 0, sum = 0;

            sum = 0;
            for (int i = 0; i < qlen; i++)
            {
                sum += Math.Pow(backs[i], 2);
            }

            sum *= 2;
            if (sum != 0)
                k = alpha/sum;
            else
                k = 1;
            return k;
        }
    

        public double[] GetBacks(double[] A, int t)
        {
            double[] subA = new double[qlen];

            for (int j = 0; j < qlen; j++)
            {
                if (t - j >= 0)
                    subA[j] = A[t - j];
                else
                    subA[j] = A[t];
            }

            return subA;
        }

        private double AdoptableFilter(double[] A)
        {
            double[] weights = new double[qlen];

            for (int i = 0; i < qlen; i++)
                weights[i] = alpha * Math.Pow(1-alpha, i);

            double fX = 0; //Прогнозоване значення

            for (int t = 0; t < A.Length; t++)
            {
                var backs = GetBacks(A, t);

                fX = 0;
                for (int i = 0; i < qlen; i++)
                    fX += weights[i] * backs [i];

                var error = A[t] - fX;

                var k = ComputeK(backs);
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] += 2 * k * error * backs[i];
                }
            }
            return fX;
        }

        private ChartPoint Regression(RawPriceHistory row)
        {
            var result = MultipleRegression.QR(
                            _history.Select(x => new [] { x.Fact1, x.Fact2, x.Fact3, x.Fact4 }).ToArray()
                    ,
                            _history.Select(x=>x.Price).ToArray()
                    ,
                    intercept: true);

            var price = result[0] + result[1]*row.Fact1 + result[2]*row.Fact2 + result[3]*row.Fact3
                        + result[4]*row.Fact4;

            return new ChartPoint() {X = row.Time, Y = price};
        }
    }
}
