using BadMintonBookingBusiness.Base;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonBookingBusiness.Categoryy
{
    public interface ICourtBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(Court court);
        Task<IBusinessResult> Update(Court court);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> SearchCourtByName(string name);
    }
}
