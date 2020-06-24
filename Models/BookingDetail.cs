using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class BookingDetail
    {
        [Key]
        public int BookId { get; set; }
        public string Extra { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivingDate { get; set; }
        public int ProId { get; set; }
        public Product Product { get; set; }
        public int CatId { get; set; }
        public virtual Category Category { get; set; }
        public string NoOfPeople { get; set; }
        public string NoOfRoom { get; set; }
        public decimal Charges { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string AlternateMobile { get; set; }

    }
}