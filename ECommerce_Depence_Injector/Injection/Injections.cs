using AutoMapper;
using ECommerce_Application.Application;
using ECommerce_Application.Interface;
using ECommerce_Depence_Injector.AutoMapper;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using ECommerce_Domain.Service;
using ECommerce_Repository.Context;
using ECommerce_Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Depence_Injector.Injection
{
    public static class Injections
    {
        public static void DependenceInjector(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterContext(services);
            RegisterServices(services);
            AutoMapperConfig.ConfigureMappers(services);
        }
        
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IClientCreditCardService, ClientCreditCardService>();
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseApplication<,>), typeof(BaseApplication<,>));
            services.AddTransient<ICityApplication, CityApplication>();
            services.AddTransient<IClientCreditCardApplication, ClientCreditCardApplication>();
            services.AddTransient<ICountryApplication, CountryApplication>();
            services.AddTransient<IStateApplication, StateApplication>();
            services.AddTransient<IUserAddressApplication, UserAddressApplication>();
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRoleApplication, UserRoleApplication>();
        }

        private static void RegisterContext(IServiceCollection services)
        {
            services.AddTransient<BaseContext, BaseContext>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAddressRepository, UserAddressRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IClientCreditCardRepository, ClientCreditCardRepository>();
        }
    }
}
