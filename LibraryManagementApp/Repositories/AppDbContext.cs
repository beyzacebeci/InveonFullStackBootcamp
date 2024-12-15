using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<UserFeature>().HasKey(x => x.UserId);

            //builder.Entity<UserFeature>().HasOne(x => x.AppUser)
            //    .WithOne(x => x.UserFeature)
            //    .HasForeignKey<UserFeature>(x => x.UserId);
        }
    }
}
