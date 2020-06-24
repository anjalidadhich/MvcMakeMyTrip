using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class ProductRepository : GenericModel<Product>, IProduct
    {
        public ProductRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<Product> GetAll()
        {
            return context.products.ToList();

        }
    }
}