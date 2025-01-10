using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.EF.AppDb
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity =>
            {
                
                entity.HasKey(e => e.Id);

                // FirstName
                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                // LastName
                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                // RegistrationDate
                entity.Property(e => e.RegistrationDate)
                      .IsRequired();

                // BirthDate
                entity.Property(e => e.BirthDate)
                      .IsRequired();

                // NationalCode
                entity.Property(e => e.NationalCode)
                      .IsRequired()
                      .HasMaxLength(10)
                      .IsFixedLength()
                      .IsUnicode(false);

                // PhoneNumber
                entity.Property(e => e.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(15)
                      .IsUnicode(false);

                //MembershipType
                entity.Property(e => e.MembershipType)
                      .IsRequired()
                      .HasConversion<int>();

                // Gender
                entity.Property(e => e.Gender)
                      .IsRequired()
                      .HasConversion<int>();
            });
        }

        public DbSet<Member> Members { get; set; }

    }
}
