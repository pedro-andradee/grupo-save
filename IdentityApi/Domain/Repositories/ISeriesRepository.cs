using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApi.Domain;

namespace Domain.Repositories
{
    public interface ISeriesRepository
    {
        Task<List<Series>> GetAllAsync(string userId);
        Task<Series> GetByIdAsync(Guid id, string userId);
        Task<bool> CreateAsync(Series series);
        Task<Series> UpdateAsync(Series series);
        Task<bool> DeleteAsync(Guid id);
    }
}