using BadMintonBooking.Common;
using BadMintonBookingBusiness.Base;
using BadMintonBookingBusiness.Categoryy;
using BadMintonData;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonBookingBusiness
{
    public class CourtBusiness : ICourtBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public CourtBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> SearchCourtByName(string name)
        {
            try
            {
                var courts = await _unitOfWork.CourtRepository.GetAllAsync();
                var filterd = courts.Where(e => e.CourtName.Contains(name)).ToList();
                if (filterd == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, filterd);
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

                var courts = await _unitOfWork.CourtRepository.GetAllAsync();

                if (courts == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, courts);
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
                var court = await _unitOfWork.CourtRepository.GetByIdAsync(id);

                if (court == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, court);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(Court court)
        {
            try
            {
                //int result = await _currencyRepository.CreateAsync(currency);
                int result = await _unitOfWork.CourtRepository.CreateAsync(court);

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

        public async Task<IBusinessResult> Update(Court court)
        {
            try
            {
                //int result = await _currencyRepository.UpdateAsync(currency);
                int result = await _unitOfWork.CourtRepository.UpdateAsync(court);

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
                var court = await _unitOfWork.CourtRepository.GetByIdAsync(id);
                if (court != null)
                {
                    //var result = await _currencyRepository.RemoveAsync(currency);
                    var result = await _unitOfWork.CourtRepository.RemoveAsync(court);
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
