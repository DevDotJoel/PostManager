using Microsoft.EntityFrameworkCore;
using PostManager.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance
{
    public class PostManagerDbContext:DbContext
    {
        public PostManagerDbContext(DbContextOptions<PostManagerDbContext> options):base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }
}
