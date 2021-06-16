using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiTest.Common.Domain.Entity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest.Common.Persistence.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Arl> Arl { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Contratoslaborales> Contratoslaborales { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Novedadesnomina> Novedadesnomina { get; set; }
        public virtual DbSet<Tipodocumento> Tipodocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arl>(entity =>
            {
                entity.HasKey(e => e.Idarl)
                    .HasName("arl_pkey");

                entity.Property(e => e.Fechacreacion).HasDefaultValueSql("now()");

                entity.Property(e => e.Habilitado).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.Idcargo)
                    .HasName("cargos_pkey");

                entity.Property(e => e.Fechacreacion).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Contratoslaborales>(entity =>
            {
                entity.HasKey(e => e.Idcontrato)
                    .HasName("contratoslaborales_pkey");

                entity.Property(e => e.Fechacreacion).HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdarlNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idarl)
                    .HasConstraintName("contratoslaborales_fk1");

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("contratoslaborales_fk2");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("contratoslaborales_fk");

                entity.HasOne(d => d.IdtipodocumentoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idtipodocumento)
                    .HasConstraintName("contratoslaborales_fk3");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("estados_pkey");

                entity.Property(e => e.Fechacreacion).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Novedadesnomina>(entity =>
            {
                entity.HasKey(e => e.Idnovedadnomina)
                    .HasName("novedadesnomina_pkey");

                entity.HasOne(d => d.IdcontratoNavigation)
                    .WithMany(p => p.Novedadesnomina)
                    .HasForeignKey(d => d.Idcontrato)
                    .HasConstraintName("novedadesnomina_fk");
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.Idtipodocumento)
                    .HasName("tipodocumento_pkey");

                entity.Property(e => e.Fechacreacion).HasDefaultValueSql("now()");
            });

        }

    }
}
