using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class Country
    {
        [Key]
        public int ConId { get; set; }
        public String CountryName { get; set; }
        public ICollection<State> State { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}