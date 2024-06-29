using BadMintonData.Base;
using BadMintonData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMintonData.Repository
{
    public class CourtSlotsRepository : GenericRepository<CourtSlot>
    {
        public CourtSlotsRepository() { }
        public CourtSlotsRepository(NET1702_PRN221_BadMintonContext context) => _context ??= context;
    }
}
