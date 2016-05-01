using System;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.Impl;
using RealtyInvest.DataModel.Repositories;

namespace RealtyInvest.DataModel.UnitsOfWorks.Impl
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private readonly RealtyInvestDbContext _context;
    
        private IRealEstateRepository _estateRepository;
        private UserManager<RealtyInvestUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UnitOfWork(RealtyInvestDbContext context)
        {
            _context = context;
        }

        ///// <summary>
        ///// Repository creation implementation
        ///// </summary>
        public IRealEstateRepository RealEstateRepository => _estateRepository ?? (_estateRepository = new RealEstateRepository(_context));
        public UserManager<RealtyInvestUser> UserManager => _userManager ?? (_userManager = new UserManager<RealtyInvestUser>(new UserStore<RealtyInvestUser>(_context)));
        public RoleManager<IdentityRole> RoleManager => _roleManager ?? (_roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context)));

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
