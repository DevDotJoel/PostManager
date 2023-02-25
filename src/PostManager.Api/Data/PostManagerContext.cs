using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostManager.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace PostManager.Api.Data
{
    public class PostManagerContext : IdentityDbContext<User,Role,int>
    {
        public PostManagerContext(DbContextOptions<PostManagerContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Storage> Storage { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UsersClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UsersTokens");

            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = 1,
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "User",
                NormalizedName = "USER",
                Id = 2,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });
            modelBuilder.Entity<Post>().HasOne(a => a.User).WithMany(c => c.Posts).HasForeignKey(ap => ap.UserId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}