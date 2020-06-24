using RoleBasedAuthanticationInMvc.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
    public class BookingDetailRepository : GenericModel<BookingDetail>, IBookingDetail
    {
        public BookingDetailRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public override IEnumerable<BookingDetail> GetAll()
        {
            return context.bookingDetails.ToList();

        }
        public override BookingDetail GetById( int ID)
        {
            int CatId = ID;
            return context.bookingDetails.Find(CatId);

        }
    }
}