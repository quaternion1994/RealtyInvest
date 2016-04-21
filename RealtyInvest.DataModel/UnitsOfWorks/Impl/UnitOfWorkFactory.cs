namespace RealtyInvest.DataModel.UnitsOfWorks.Impl
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(new RealtyInvestDbContext());
        }
    }
}
