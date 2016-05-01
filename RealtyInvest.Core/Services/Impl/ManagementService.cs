using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.UnitsOfWorks;
using RealtyInvest.DataModel.ViewModels.Manage;

namespace RealtyInvest.Core.Services.Impl
{
    public class ManagementService : IManagementService
    {
        private readonly IUnitOfWorkFactory _factory;
        public ManagementService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ServiceResult<RealtyManageViewModel[]> GetRealtyListForUser(string userid)
        {
            ServiceResult<RealtyManageViewModel[]> result = new ServiceResult<RealtyManageViewModel[]>(new RealtyManageViewModel[0]);
            try
            {
                using (var uow = _factory.CreateUnitOfWork())
                {
                    //uow.RealEstateRepository.Find(x => x.Owner.Id == userid);
                    result.Value = new RealtyManageViewModel[]
                    {
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" }
                    };
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ServiceResult<RealtyManageViewModel> GetRealtyEstate(string userid, int id)
        {
            ServiceResult<RealtyManageViewModel> result = new ServiceResult<RealtyManageViewModel>(new RealtyManageViewModel());
            try
            {
                using (var uow = _factory.CreateUnitOfWork())
                {
                    //result.Value = uow.RealEstateRepository.Find(x => x.Owner.Id == userid && x.Id == id);
                    var arr = new RealtyManageViewModel[]
                    {
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                        new RealtyManageViewModel {Price = 10, Name = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" }
                    };
                    result.Value = arr[id];
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception)
            {
                
            }
            return result;
        }

        public ServiceResult<RealtyManageViewModel> SetRealtyEstate(string userid, RealtyManageViewModel model)
        {
            ServiceResult<RealtyManageViewModel> result = new ServiceResult<RealtyManageViewModel>(new RealtyManageViewModel());
            try
            {
                using (var uow = _factory.CreateUnitOfWork())
                {
                    var entity = uow.RealEstateRepository.Find(x => x.Owner.Id == userid && x.Id == model.Id);
                    ;
                    if (entity == null)
                    {
                        uow.RealEstateRepository.Add(new DataModel.Entites.RealEstate
                        {
                            Name = model.Name,
                            Price = model.Price,
                            Square = model.Square,
                            Description = model.Description,
                            Owner = uow.UserManager.FindById(userid)
                        });
                    }
                    else
                    {
                        uow.RealEstateRepository.Update(new RealEstate
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Price = model.Price,
                            Square = model.Square,
                            Description = model.Description,
                            MainPictureUrl = model.PictureUrl,
                        });
                    }
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}