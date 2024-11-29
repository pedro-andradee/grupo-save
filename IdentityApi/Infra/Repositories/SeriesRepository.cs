using Domain.Repositories;
using IdentityApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infra.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Disciplina> _dbSet;

        public DisciplinaRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Disciplina>();
        }

        public async Task<bool> CreateAsync(Disciplina disciplina)
        {
            _dbSet.Add(disciplina);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var disciplina = await _dbSet.FindAsync(id);
            if (disciplina == null)
            {
                return false;
            }
            _dbSet.Remove(disciplina);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Disciplina>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Disciplina> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Disciplina> UpdateAsync(Disciplina disciplina)
        {
            if (disciplina == null)
            {
                return null;
            }

            // Tenta atualizar diretamente
            var existingDisciplina = await _dbSet.FindAsync(disciplina.Id);
            if (existingDisciplina == null)
            {
                return null;
            }

            existingDisciplina.Title = disciplina.Title;
            existingDisciplina.Semestre = disciplina.Semestre;
            existingDisciplina.Curso = disciplina.Curso;
            existingDisciplina.Professor = disciplina.Professor;

            _dbSet.Update(existingDisciplina);

            await _context.SaveChangesAsync();

            return existingDisciplina;
        }
    }
}