using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public ICollection<Product> products { get; set; }
        //public ICollection<BookingDetail> bookingDetails { get; set; }

    }
}