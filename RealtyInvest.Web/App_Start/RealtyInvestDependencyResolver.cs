using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RealtyInvest.Core.Services;
using RealtyInvest.Core.Services.Impl;
using RealtyInvest.DataModel.Impl;
using RealtyInvest.DataModel.Repositories;
using RealtyInvest.DataModel.UnitsOfWorks;
using RealtyInvest.DataModel.UnitsOfWorks.Impl;

namespace RealtyInvest.Web
{
    public class RealtyInvestDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public RealtyInvestDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            //Services
            _kernel.Bind<IRealtySearchService>().To<RealtySearchService>();
            _kernel.Bind<IAuthService>().To<AuthService>();
        }
    }
}