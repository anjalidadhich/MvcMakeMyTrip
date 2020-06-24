using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int CatId { get; set; }
        public virtual Category Category { get; set; }
        public int ConId { get; set; }
        public virtual Country Country { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

     
        [Required]
        public string Mobile { get; set; }
        [Required]
        public int Pincode { get; set; }

        public string Description { get; set; }
        [Required]
        public string Image { get; set; }


        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivingDate { get; set; }
        public string NoOfPeople { get; set; }
        public string NoOfRoom { get; set; }
        public decimal Charges { get; set; }
        public string Descr { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}