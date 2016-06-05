using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.UnitsOfWorks;
using RealtyInvest.DataModel.ViewModels.Manage;
using System.Linq;

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
                    result.Value = uow.RealEstateRepository
                        .All(x => x.Owner.Id == userid)
                        .Select(x => new RealtyManageViewModel
                        {
                            Id = x.Id,
                            Description = x.Description,
                            Location = x.Location,
                            Name = x.Name,
                            PictureUrl = x.MainPictureUrl,
                            Price = x.Price,
                            Square = x.Square
                        }).ToArray();
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
                    var estate = uow.RealEstateRepository
                        .Find(y => y.Owner.Id == userid && y.Id == id);

                    result.Value = new RealtyManageViewModel
                    {
                        Id = estate.Id,
                        Description = estate.Description,
                        Location = estate.Location,
                        Name = estate.Name,
                        PictureUrl = estate.MainPictureUrl,
                        Price = estate.Price,
                        Square = estate.Square
                    };
                    
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception e)
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
                        uow.RealEstateRepository.Add(new RealEstate
                        {
                            Name = model.Name,
                            Price = model.Price,
                            Square = model.Square,
                            MainPictureUrl = model.PictureUrl,
                            Description = model.Description,
                            Location = model.Location,
                            Owner = uow.UserManager.FindById(userid)
                        });
                    }
                    else
                    {
                        entity.Name = model.Name;
                        entity.Price = model.Price;
                        entity.Square = model.Square;
                        entity.Description = model.Description;
                        entity.MainPictureUrl = model.PictureUrl;
                        entity.Location = model.Location;
                        uow.RealEstateRepository.Update(entity);
                    }
                    result.ServiceStatus = Status.Success;
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}