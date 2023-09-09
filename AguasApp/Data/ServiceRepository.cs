using AguasApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AguasApp.Data
{
    public class ServiceRepository : GenericRepository<Service>,IServiceRepository
    {
        private readonly DataContext _context;
        public ServiceRepository(DataContext context) : base(context)
        {
            _context = context;
        }



    }
}
