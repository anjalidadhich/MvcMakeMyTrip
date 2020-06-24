using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class CategoryRepository:GenericModel<Category>,ICategory
    {
        public CategoryRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<Category> GetAll()
        {
            return context.categories.ToList();

        }
    }
}