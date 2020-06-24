using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthanticationInMvc.Models.IRepository
{
    public interface ICountry
    {
        IEnumerable<Country> GetAll();
    }
}
