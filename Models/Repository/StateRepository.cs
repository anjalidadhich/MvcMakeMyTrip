using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class StateRepository : GenericModel<State>, IState
    {
        public StateRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<State> GetAll()
        {
            return context.states.ToList();//context.states.Include(a => a.Country).ToList();


        }
    }
}