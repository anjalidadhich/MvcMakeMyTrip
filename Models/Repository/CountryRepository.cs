using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class CountryRepository:GenericModel<Country>,ICountry
    {
        public CountryRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<Country> GetAll()
        {
            return context.countries.ToList();

        }

    }
}