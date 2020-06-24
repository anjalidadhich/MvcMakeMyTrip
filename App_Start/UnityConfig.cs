using RoleBasedAuthanticationInMvc.Models.IRepository;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RoleBasedAuthanticationInMvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICategory, CategoryRepository>();
            container.RegisterType<ICountry, CountryRepository>();
            container.RegisterType<IState, StateRepository>();
            container.RegisterType<ICity, CityRepository>();
            container.RegisterType<IProduct, ProductRepository>();
            container.RegisterType<IBookingDetail, BookingDetailRepository>();
           // container.RegisterType<>
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}