using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts
{
    public class BaseDbContext :DbContext
    {
        protected IConfiguration configuration { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BaseDbContext(DbContextOptions contextOptions,IConfiguration configuration):base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.Status).HasColumnName("Status");
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.HasMany(u => u.RefreshTokens);
                u.HasMany(u=>u.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.UserId).HasColumnName("UserId");
                a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(c => c.OperationClaim);
                a.HasOne(c => c.User);
            });

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

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshToken").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.HasOne(p => p.User);
            });

            Language[] seedData = { new(1, "Python"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(seedData);

            Framework[] seedFrameworks = {new (1,1,"Django"),new (2,1,"Flask"),new (3,2,"Spring boot"),new (4,2,"JSF")};
            modelBuilder.Entity<Framework>().HasData(seedFrameworks);
        }
    }
}
