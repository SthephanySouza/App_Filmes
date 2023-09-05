using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoveHome.Model;

namespace MoveHome.DataContext;

public partial class FilmesDbContext : DbContext
{
    public FilmesDbContext()
    {
    }

    public FilmesDbContext(DbContextOptions<FilmesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAtor> TbAtors { get; set; }

    public virtual DbSet<TbDiretor> TbDiretors { get; set; }

    public virtual DbSet<TbFilme> TbFilmes { get; set; }

    public virtual DbSet<TbGenero> TbGeneros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER01;Initial Catalog=FilmesDb;Encrypt=False;Integrated Security = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAtor>(entity =>
        {
            entity.HasKey(e => e.IdAtor).HasName("PK__tbAtor__2C494D7B4FD0AC1A");
        });

        modelBuilder.Entity<TbDiretor>(entity =>
        {
            entity.HasKey(e => e.IdDiretor).HasName("PK__tbDireto__DBC7C9AC72FC2629");
        });

        modelBuilder.Entity<TbFilme>(entity =>
        {
            entity.HasKey(e => e.IdFilme).HasName("PK__tbFilme__6E8F2A7639291753");

            entity.HasOne(d => d.IdAtorNavigation).WithMany(p => p.TbFilmes).HasConstraintName("FK__tbFilme__IdAtor__3F466844");

            entity.HasOne(d => d.IdDiretorNavigation).WithMany(p => p.TbFilmes).HasConstraintName("FK__tbFilme__IdDiret__3E52440B");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.TbFilmes).HasConstraintName("FK__tbFilme__IdGener__3D5E1FD2");
        });

        modelBuilder.Entity<TbGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__tbGenero__0F834988E2F43337");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
