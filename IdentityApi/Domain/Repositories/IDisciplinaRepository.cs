using IdentityApi.Domain;

namespace Domain.Repositories
{
    public interface IDisciplinaRepository
    {
        Task<List<Disciplina>> GetAllAsync();
        Task<Disciplina> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Disciplina disciplina);
        Task<Disciplina> UpdateAsync(Disciplina disciplina);
        Task<bool> DeleteAsync(Guid id);
    }
}