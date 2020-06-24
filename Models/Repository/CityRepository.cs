using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class CityRepository : GenericModel<City>, ICity
    {
        public CityRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<City> GetAll()
        {
            return context.cities.ToList();

        }
    }
}