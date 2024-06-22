using BadMintonBooking.Common;
using BadMintonBookingBusiness.Base;
using BadMintonBookingBusiness.Categoryy;
using BadMintonData;
using BadMintonData.DAO;
using BadMintonData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonBookingBusiness
{
    public class CustomerBusiness :ICustomerBusiness
    {
       /* private readonly CustomerDAO _DAO;*/
        private readonly UnitOfWork _unitOfWork;
        public CustomerBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        
        public async  Task<IBusinessResult> SearchCustomerByName(string customerName)
        {
            try
            {

                var customer = await _unitOfWork.CustomerRepository.GetAllAsync();
                var cus = customer.Where(e => e.FullName.Contains(customerName)).ToList();
                if (customer == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, cus);
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

                    //var currencies = _DAO.GetAll();
                    //var currencies = await _currencyRepository.GetAllAsync();
                    var currencies = await _unitOfWork.CustomerRepository.GetAllAsync();


                    if (currencies == null)
                    {
                        return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currencies);
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
                    var currency = await _unitOfWork.CustomerRepository.GetByIdAsync(id);

                    if (currency == null)
                    {
                        return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currency);
                    }
                }
                catch (Exception ex)
                {
                    return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
                }
            }

            public async Task<IBusinessResult> Save(Customer customer)
            {
                try
                {
                    //int result = await _currencyRepository.CreateAsync(currency);
                    int result = await _unitOfWork.CustomerRepository.CreateAsync(customer);
                
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

            public async Task<IBusinessResult> Update(Customer customer)
            {
                try
                {
                    //int result = await _currencyRepository.UpdateAsync(currency);
                    int result = await _unitOfWork.CustomerRepository.UpdateAsync(customer);

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
                    var currency = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                    if (currency != null)
                    {
                        //var result = await _currencyRepository.RemoveAsync(currency);
                        var result = await _unitOfWork.CustomerRepository.RemoveAsync(currency);
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

