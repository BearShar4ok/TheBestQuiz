using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestQuiz.Models;

namespace TheBestQuiz
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Theme> Theme { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-15H02TIQ\\SQLEXPRESS;Database=TheBestQuiz;Trusted_Connection=True;");
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
