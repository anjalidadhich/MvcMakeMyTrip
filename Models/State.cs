using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ConId { get; set; }
        public virtual  Country Country { get; set; }
        //public ICollection<City> City { get; set; }
        public ICollection<Product> Product { get; set; }
        //public ICollection<BookingDetail> bookingDetails { get; set; }
    }
}