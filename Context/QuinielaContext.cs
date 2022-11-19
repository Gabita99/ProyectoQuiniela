using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Context
{
    public partial class QuinielaContext : DbContext
    {
        public QuinielaContext()
        {
        }

        public QuinielaContext(DbContextOptions<QuinielaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleEquipo> DetalleEquipos { get; set; } = null!;
        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<Invitacione> Invitaciones { get; set; } = null!;
        public virtual DbSet<Liga> Ligas { get; set; } = null!;
        public virtual DbSet<Partido> Partidos { get; set; } = null!;
        public virtual DbSet<Premio> Premios { get; set; } = null!;
        public virtual DbSet<QuinielaPrediccione> QuinielaPredicciones { get; set; } = null!;
        public virtual DbSet<Resultado> Resultados { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipoPremio> TipoPremios { get; set; } = null!;
        public virtual DbSet<TipoResultado> TipoResultados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleEquipo>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.DetalleEquipos)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEquipos_Equipos");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.DetalleEquipos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEquipos_Grupos");

                entity.HasOne(d => d.IdLigaNavigation)
                    .WithMany(p => p.DetalleEquipos)
                    .HasForeignKey(d => d.IdLiga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEquipos_Ligas");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.Property(e => e.Grupo1)
                    .HasMaxLength(50)
                    .HasColumnName("Grupo");
            });

            modelBuilder.Entity<Invitacione>(entity =>
            {
                entity.HasKey(e => e.IdInvitacion)
                    .HasName("PK_Invitaiones");

                entity.HasOne(d => d.IdLigaNavigation)
                    .WithMany(p => p.Invitaciones)
                    .HasForeignKey(d => d.IdLiga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invitaciones_Ligas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Invitaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invitaciones_Usuarios");
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.HasKey(e => e.IdLiga);

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.IdPartido);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.EquipoANavigation)
                    .WithMany(p => p.PartidoEquipoANavigations)
                    .HasForeignKey(d => d.EquipoA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partidos_Equipos");

                entity.HasOne(d => d.EquipoBNavigation)
                    .WithMany(p => p.PartidoEquipoBNavigations)
                    .HasForeignKey(d => d.EquipoB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partidos_Equipos1");
            });

            modelBuilder.Entity<Premio>(entity =>
            {
                entity.HasKey(e => e.IdPremios);

                entity.Property(e => e.Puesto).HasMaxLength(50);

                entity.HasOne(d => d.IdLigaNavigation)
                    .WithMany(p => p.Premios)
                    .HasForeignKey(d => d.IdLiga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Premios_Ligas");

                entity.HasOne(d => d.IdTipoPremioNavigation)
                    .WithMany(p => p.Premios)
                    .HasForeignKey(d => d.IdTipoPremio)
                    .HasConstraintName("FK_Premios_TipoPremios");
            });

            modelBuilder.Entity<QuinielaPrediccione>(entity =>
            {
                entity.HasKey(e => e.IdPredicciones)
                    .HasName("PK_Quiniela_predicciones_1");

                entity.Property(e => e.IdPredicciones).ValueGeneratedNever();

                entity.Property(e => e.EquipoA).HasMaxLength(50);

                entity.Property(e => e.EquipoB).HasMaxLength(50);

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.QuinielaPredicciones)
                    .HasForeignKey(d => d.IdPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiniela_predicciones_Partidos1");
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.IdResultado);

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resultados_Partidos");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resultados_Tipo_resultado");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK_Jugadores");

                entity.Property(e => e.Activo).HasMaxLength(50);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Tipo).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoPremio>(entity =>
            {
                entity.HasKey(e => e.IdTipoPremio);

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoResultado>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK_Tipo_resultado");

                entity.ToTable("TipoResultado");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Contra).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Estatus).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
