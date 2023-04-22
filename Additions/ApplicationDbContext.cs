using Microsoft.EntityFrameworkCore;
using TheBestQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestQuiz.Additions
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Theme> Theme { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=GRACHEV10600K;Database=TheBestQuizUsers;Trusted_Connection=True;");
        }
    }
}
