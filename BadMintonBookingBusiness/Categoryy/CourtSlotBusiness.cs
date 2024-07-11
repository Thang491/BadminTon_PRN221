using BadMintonBooking.Common;
using BadMintonBookingBusiness.Base;
using BadMintonBookingBusiness.Categoryy;
using BadMintonData.Models;
using BadMintonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BadMintonBookingBusiness
{
    public class CourtSlotBusiness : ICourtSlotBusiness
    {
        /* private readonly CustomerDAO _DAO;*/
        private readonly UnitOfWork _unitOfWork;
        public CourtSlotBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> SearchCourtSlotByDate(string date)
        {
            try
            {
                var courtSlots = await _unitOfWork.CourtSlotsRepository.GetAllAsync();
                var slot = courtSlots.Where(e => e.SlotStartTime.ToString().Contains(date)).ToList();
                if (courtSlots == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, slot);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);

            }
        }
        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                var courtSlots = await _unitOfWork.CourtSlotsRepository.GetAllIncludeCourt();

                if (courtSlots == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, courtSlots);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            try
            {
                #region Business rule
                #endregion

                //var currency = await _currencyRepository.GetByIdAsync(code);
                var courtSlot = await _unitOfWork.CourtSlotsRepository.GetByIdAsync(id);

                if (courtSlot == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, courtSlot);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(CourtSlot courtSlot)
        {
            try
            {
                //int result = await _currencyRepository.CreateAsync(currency);
                int result = await _unitOfWork.CourtSlotsRepository.CreateAsync(courtSlot);

                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(CourtSlot courtSlot)
        {
            try
            {
                //int result = await _currencyRepository.UpdateAsync(currency);
                int result = await _unitOfWork.CourtSlotsRepository.UpdateAsync(courtSlot);

                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                //var currency = await _currencyRepository.GetByIdAsync(code);
                var courtSlot = await _unitOfWork.CourtSlotsRepository.GetByIdAsync(id);
                if (courtSlot != null)
                {
                    //var result = await _currencyRepository.RemoveAsync(currency);
                    var result = await _unitOfWork.CourtSlotsRepository.RemoveAsync(courtSlot);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

    }
}
