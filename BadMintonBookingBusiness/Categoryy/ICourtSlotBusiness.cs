using BadMintonBookingBusiness.Base;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonBookingBusiness.Categoryy
{
    public interface ICourtSlotBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(CourtSlot courtSlot);
        Task<IBusinessResult> Update(CourtSlot courtSlot);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> SearchCourtSlotByDate(string date);
    }
}
