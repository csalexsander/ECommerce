using AutoMapper;
using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Depence_Injector.AutoMapper
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<UserModel, User>();
            CreateMap<CityModel, City>();
            CreateMap<StateModel, State>();
            CreateMap<CountryModel, Country>();
            CreateMap<ClientCreditCardModel, ClientCreditCard>();
            CreateMap<UserRoleModel, UserRole>();
            CreateMap<UserAddressModel, UserAddress>();
        }
    }
}
