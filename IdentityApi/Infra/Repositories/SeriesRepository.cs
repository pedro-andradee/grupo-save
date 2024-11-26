using Domain.Repositories;
using IdentityApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infra.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Series> _dbSet;

        public SeriesRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Series>();
        }

        public async Task<bool> CreateAsync(Series series)
        {
            _dbSet.Add(series);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var serie = await _dbSet.FindAsync(id);
            if (serie == null)
            {
                return false;
            }
            _dbSet.Remove(serie);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Series>> GetAllAsync(string userId)
        {
            _dbSet.Where(s => s.UserId == userId);
            return await _dbSet.ToListAsync();
        }

        public async Task<Series> GetByIdAsync(Guid id, string userId)
        {
            _dbSet.Where(s => s.UserId == userId && s.Id == id);
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<Series> UpdateAsync(Series series)
        {
            if (series == null)
            {
                return null;
            }

            // Tenta atualizar diretamente
            var existingSeries = await _dbSet.FindAsync(series.Id);
            if (existingSeries == null)
            {
                return null;
            }

            existingSeries.Title = series.Title;
            existingSeries.CurrentEpisode = series.CurrentEpisode;
            existingSeries.CurrentSeason = series.CurrentSeason;
            existingSeries.Genre = series.Genre;
            existingSeries.IsCompleted = series.IsCompleted;

            _dbSet.Update(existingSeries);

            await _context.SaveChangesAsync();

            return series;
        }
    }
}