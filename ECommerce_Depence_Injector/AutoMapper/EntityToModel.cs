using AutoMapper;
using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Depence_Injector.AutoMapper
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<User, UserModel>().ForMember(x => x.Password, obj => obj.Ignore());
            CreateMap<City, CityModel>();
            CreateMap<State, StateModel>();
            CreateMap<Country, CountryModel>();
            CreateMap<ClientCreditCard, ClientCreditCardModel>();
            CreateMap<UserRole, UserRoleModel>();
            CreateMap<UserAddress, UserAddressModel>();
        }
    }
}
