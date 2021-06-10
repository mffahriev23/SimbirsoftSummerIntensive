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
    public class StatisticFieldRepository : IStatisticFieldRepository
    {
        private Core.DBContext.AppDbContext _context;

        public StatisticFieldRepository(Core.DBContext.AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(StatisticField entity)
        {
            _context.StatisticField.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<StatisticField> entities)
        {
            _context.StatisticField.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public Task Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<StatisticField> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<StatisticField> GetAll()
            => _context.StatisticField;


        public Task Update(StatisticField entity)
        {
            throw new NotImplementedException();
        }
    }
}
