using BadMintonData.Models;
using BadMintonData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonData
{
    public class UnitOfWork
    {
        private NET1702_PRN221_BadMintonContext _unitOfWorkContext;
        private CustomerRepository _customer;
        public UnitOfWork()
        {
            _unitOfWorkContext ??= new NET1702_PRN221_BadMintonContext();
        }
    
    public CustomerRepository CustomerRepository
        {
            get { return _customer ??= new Repository.CustomerRepository(_unitOfWorkContext); }
            //get { return _customer ??= new Repository.CustomerRepository(); }
        }
    }
}
