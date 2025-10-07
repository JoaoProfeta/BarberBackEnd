using Barber.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Infra.Contexts
{
    public class BarberContext : DbContext
    {
        public BarberContext(DbContextOptions<BarberContext> options)
            : base(options)
        {
        }
        DbSet<User> Users { get; set; }
        DbSet<Professional> Professionals { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<ProfessionalServiceJoint> ProfessionalServices { get; set; }
        DbSet<Scheduling> Schedulings { get; set; }
        DbSet<SchedulingProfessionalServiceJoint> SchedulingProfessionalServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
            });

            // Professional
            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProfessionalName).IsRequired();
                entity.HasMany(e => e.Services)
                    .WithOne(e => e.Professional)
                    .HasForeignKey(e => e.ProfessionalId);
            });

            // Service
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(e => e.Professionals)
                    .WithOne(e => e.Service)
                    .HasForeignKey(e => e.ServiceId);
            });

            // ProfessionalServiceJoint
            modelBuilder.Entity<ProfessionalServiceJoint>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Professional)
                    .WithMany(p => p.Services)
                    .HasForeignKey(e => e.ProfessionalId);
                entity.HasOne(e => e.Service)
                    .WithMany(s => s.Professionals)
                    .HasForeignKey(e => e.ServiceId);
            });

            // Scheduling
            modelBuilder.Entity<Scheduling>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.SchedulingProfessionalsServices)
                    .WithOne(e => e.Scheduling)
                    .HasForeignKey(e => e.SchedulingId);
            });

            // SchedulingProfessionalServiceJoint
            modelBuilder.Entity<SchedulingProfessionalServiceJoint>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Scheduling)
                    .WithMany(s => s.SchedulingProfessionalsServices)
                    .HasForeignKey(e => e.SchedulingId);
                entity.HasOne(e => e.ProfessionalServiceJoint)
                    .WithMany()
                    .HasForeignKey(e => e.ProfessionalServiceJointId);
            });

        }
    }
}
