using RealtyInvest.DataModel.UnitsOfWorks.Impl;

namespace RealtyInvest.DataModel.UnitsOfWorks
{
    public interface IUnitOfWorkFactory
    {
         UnitOfWork CreateUnitOfWork();
    }
}