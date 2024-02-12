using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostManager.Domain.Aggregates.CommentAggregate;
using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Infrastructure.Persistance.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance
{
    public class PostManagerDbContext: IdentityDbContext<User,Role,Guid>
    {
        public PostManagerDbContext(DbContextOptions<PostManagerDbContext> options):base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostManagerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UsersClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UsersTokens");

            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "User",
                NormalizedName = "USER",
                Id = Guid.NewGuid(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
,
            });
        }
    }
}
