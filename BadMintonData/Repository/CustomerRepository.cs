using BadMintonData.Base;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonData.Repository
{
    public class CustomerRepository: GenericRepository<Customer>
    {
        public CustomerRepository() { }
        public CustomerRepository(NET1702_PRN221_BadMintonContext context)  => _context ??= context; 

        ////TO-DO CODE HERE/////////////////
    }
}
