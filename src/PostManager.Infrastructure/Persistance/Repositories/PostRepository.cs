using Microsoft.EntityFrameworkCore;
using PostManager.Application.Common.Repositories;
using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostManagerDbContext _context;
        public PostRepository(PostManagerDbContext context)
        {
            _context = context;
            
        }
        public async Task AddAsync(Post entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task AddMultipleAsync(List<Post> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PostId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAllAsync()
        {
          return await _context.Posts.AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetByIdAsync(PostId id)
        {
            return await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task GetByIdsAsync(List<PostId> ids)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Post entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateMultipleAsync(List<Post> entities)
        {
            throw new NotImplementedException();
        }
    }
}
