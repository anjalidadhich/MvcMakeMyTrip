using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public DateTime CheckInDate { get; set; }
        public string Name { get; set; }
        public int CatId { get; set; }
        public IEnumerable<Product> ListProduct { get; set; }
        public BookingDetail BookingDetail { get; set; }
        public IEnumerable<BookingDetail> ListBookingDetail { get; set; }
        //public IEnumerable<Category> ListCategory { get; set; }
    }
}