using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts
{
    public class BaseDbContext :DbContext
    {
        protected IConfiguration configuration { get; set; }

        public DbSet<Language> Languages { get; set; }

        public BaseDbContext(DbContextOptions contextOptions,IConfiguration configuration):base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("Languages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p=>p.Frameworks);
            });

            modelBuilder.Entity<Framework>(a =>
            {
                a.ToTable("Frameworks").HasKey(k=>k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");
                a.HasOne(p=>p.Language);
            });

            Language[] seedData = { new(1, "Python"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(seedData);

            Framework[] seedFrameworks = {new (1,1,"Django"),new (2,1,"Flask"),new (3,2,"Spring boot"),new (4,2,"JSF")};
            modelBuilder.Entity<Framework>().HasData(seedFrameworks);
        }
    }
}
