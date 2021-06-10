using Microsoft.EntityFrameworkCore;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Core.DBModels;
using SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DB.Repositories
{
    public class ResourseRepository : IResourseRepository
    {
        private Core.DBContext.AppDbContext _context;

        public ResourseRepository(Core.DBContext.AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Resource entity)
        {
            _context.Resource.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddRange(IEnumerable<Resource> entities)
        {
            _context.Resource.AddRange(entities);
            int result = await _context.SaveChangesAsync();
            return result == entities.Count();
        }

        public Task Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Resource> Get(long Id)
            => await _context.Resource.SingleOrDefaultAsync(x => x.Id == Id);

        public IQueryable<Resource> GetAll()
            => _context.Resource;

        public async Task<Resource> GetFreshResourse()
            => await GetAll().SingleOrDefaultAsync(x => x.Id == GetAll().Max(y => y.Id));

        public async Task Update(Resource entity)
        {
            _context.Resource.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
