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
        private CourtRepository _court;
        public UnitOfWork()
        {
            _unitOfWorkContext ??= new NET1702_PRN221_BadMintonContext();
        }
    
    public CourtRepository CourtRepository
        {
            get { return _court ??= new Repository.CourtRepository(_unitOfWorkContext); }
            //get { return _customer ??= new Repository.CourtRepository(); }
        }
    }
}
