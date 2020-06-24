using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthanticationInMvc.Models.IRepository
{
    interface IBookingDetail
    {
        IEnumerable<BookingDetail> GetAll();
        BookingDetail GetById( int ID);
    }
}
