using System;
using RealtyInvest.DataModel.Impl;
using RealtyInvest.DataModel.Repositories;

namespace RealtyInvest.DataModel.UnitsOfWorks.Impl
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private readonly RealtyInvestDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(RealtyInvestDbContext context)
        {
            _context = context;
        }

        //private IAccountRepository _accountRepository;


        ///// <summary>
        ///// Repository creation implementation
        ///// </summary>
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));

  
        private void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Save();
                _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
