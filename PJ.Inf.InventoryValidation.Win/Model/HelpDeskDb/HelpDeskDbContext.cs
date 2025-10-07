using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class HelpDeskDbContext : DbContext
{
    public HelpDeskDbContext()
    {
    }

    public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BienPatrimonial> BienPatrimonials { get; set; }

    public virtual DbSet<Definition> Definitions { get; set; }

    public virtual DbSet<DefinitionGroup> DefinitionGroups { get; set; }

    public virtual DbSet<DefinitionGroupValue> DefinitionGroupValues { get; set; }

    public virtual DbSet<DefinitionValue> DefinitionValues { get; set; }

    public virtual DbSet<DenominacionBien> DenominacionBiens { get; set; }

    public virtual DbSet<DenominacionBienModelo> DenominacionBienModelos { get; set; }

    public virtual DbSet<DependenciaJudicial> DependenciaJudicials { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<OficinaInterna> OficinaInternas { get; set; }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS2022;Database=HELPDESK;Trusted_Connection=False;uid=sa;password=123..abc;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BienPatrimonial>(entity =>
        {
            entity.HasKey(e => e.BptId);

            entity.ToTable("BienPatrimonial", "Inv");

            entity.HasIndex(e => e.BptCodigoPatrimonial, "IX_BienPatrimonial").IsUnique();

            entity.Property(e => e.BptId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BptCodigoCatalogo).HasMaxLength(16);
            entity.Property(e => e.BptCodigoInterno).HasMaxLength(16);
            entity.Property(e => e.BptCodigoPatrimonial).HasMaxLength(16);
            entity.Property(e => e.BptEstadoConservacionTipo).HasComment("DefId = 8");
            entity.Property(e => e.BptInventariadoTipo)
                .HasDefaultValueSql("((1))")
                .HasComment("1-> sin inventariar, 2-> inventariado, 3->Reportado por revisar");
            entity.Property(e => e.BptNuevaSerie).HasMaxLength(32);
            entity.Property(e => e.BptObservacion).HasMaxLength(512);
            entity.Property(e => e.BptSerie).HasMaxLength(32);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Dbm).WithMany(p => p.BienPatrimonials)
                .HasForeignKey(d => d.DbmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BienPatrimonial_DenominacionBienModelo");

            entity.HasOne(d => d.Ofi).WithMany(p => p.BienPatrimonialOfis)
                .HasForeignKey(d => d.OfiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BienPatrimonial_OficinaInterna");

            entity.HasOne(d => d.OfiNuevo).WithMany(p => p.BienPatrimonialOfiNuevos)
                .HasForeignKey(d => d.OfiNuevoId)
                .HasConstraintName("FK_BienPatrimonial_OficinaInterna1");

            entity.HasOne(d => d.Per).WithMany(p => p.BienPatrimonialPers)
                .HasForeignKey(d => d.PerId)
                .HasConstraintName("FK_BienPatrimonial_Persona");

            entity.HasOne(d => d.PerNuevo).WithMany(p => p.BienPatrimonialPerNuevos)
                .HasForeignKey(d => d.PerNuevoId)
                .HasConstraintName("FK_BienPatrimonial_Persona1");

            entity.HasOne(d => d.UsrInventaria).WithMany(p => p.BienPatrimonials)
                .HasForeignKey(d => d.UsrInventariaId)
                .HasConstraintName("FK_BienPatrimonial_Usuario");
        });

        modelBuilder.Entity<Definition>(entity =>
        {
            entity.HasKey(e => e.DefId).HasName("PK__Definiti__D4F2C4E914E23A5D");

            entity.ToTable("Definition", "Gen", tb => tb.HasComment("Definiciones del sistema"));

            entity.Property(e => e.DefId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DefDescription)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Descripción de la definición");
            entity.Property(e => e.DefNumber).HasComment("Número de definicion, que servirá para relacionarlos con la tabla respectiva");
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
        });

        modelBuilder.Entity<DefinitionGroup>(entity =>
        {
            entity.HasKey(e => e.DfgId);

            entity.ToTable("DefinitionGroup", "Gen", tb => tb.HasComment("Grupo de definiciones"));

            entity.Property(e => e.DfgId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DfgActive).HasComment("Determina si el registro está activo o no");
            entity.Property(e => e.DfgDescription)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Descripcion abreviada del grupo");
            entity.Property(e => e.DfgDescriptionLarge)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasComment("Descripción larga del grupo");
            entity.Property(e => e.DfgNumber).HasComment("Número de grupo dedefinición que servirá para agrupar las definiciones");
            entity.Property(e => e.SecCreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecDeleteAt).HasColumnType("datetime");
            entity.Property(e => e.SecUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.SecUserCreate)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUserDelete)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.SecUserUpdate)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Def).WithMany(p => p.DefinitionGroups)
                .HasForeignKey(d => d.DefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefinitionGroup_Definition");
        });

        modelBuilder.Entity<DefinitionGroupValue>(entity =>
        {
            entity.HasKey(e => e.DgvId);

            entity.ToTable("DefinitionGroupValue", "Gen", tb => tb.HasComment("Valores de grupo de definiciones"));

            entity.Property(e => e.DgvId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DfvStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Determina si el registro está activo o no");
            entity.Property(e => e.SecCreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecDeleteAt).HasColumnType("datetime");
            entity.Property(e => e.SecUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.SecUserCreate)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUserDelete)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.SecUserUpdate)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Dfg).WithMany(p => p.DefinitionGroupValues)
                .HasForeignKey(d => d.DfgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefinitionGroupValue_DefinitionGroup");

            entity.HasOne(d => d.Dfv).WithMany(p => p.DefinitionGroupValues)
                .HasForeignKey(d => d.DfvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefinitionGroupValue_DefinitionValue");
        });

        modelBuilder.Entity<DefinitionValue>(entity =>
        {
            entity.HasKey(e => e.DfvId);

            entity.ToTable("DefinitionValue", "Gen", tb => tb.HasComment("Valores de definiciones del sistema, que servirán como maestros de los sistemas"));

            entity.Property(e => e.DfvId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DfvActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Determina si un registro está activo o no");
            entity.Property(e => e.DfvAlterCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("Usado para relacionar con tablas de sunat por ejemplo");
            entity.Property(e => e.DfvDescription)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasComment("Descripción del valor de la definición");
            entity.Property(e => e.DfvDescriptionShort)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Descripción corta del valor de la definición");
            entity.Property(e => e.DfvText01)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasComment("Texto alternativo del valor de definicion");
            entity.Property(e => e.DfvValue).HasComment("Valor con el que se va a asociar en la tabla");
            entity.Property(e => e.SecCreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecDeleteAt).HasColumnType("datetime");
            entity.Property(e => e.SecUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.SecUserCreate)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUserDelete)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.SecUserUpdate)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Def).WithMany(p => p.DefinitionValues)
                .HasForeignKey(d => d.DefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefinitionValue_Definition");
        });

        modelBuilder.Entity<DenominacionBien>(entity =>
        {
            entity.HasKey(e => e.DebId);

            entity.ToTable("DenominacionBien", "Inv");

            entity.Property(e => e.DebId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DebDescripcion).HasMaxLength(64);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
        });

        modelBuilder.Entity<DenominacionBienModelo>(entity =>
        {
            entity.HasKey(e => e.DbmId);

            entity.ToTable("DenominacionBienModelo", "Inv");

            entity.Property(e => e.DbmId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Deb).WithMany(p => p.DenominacionBienModelos)
                .HasForeignKey(d => d.DebId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DenominacionBienModelo_DenominacionBien");

            entity.HasOne(d => d.Mar).WithMany(p => p.DenominacionBienModelos)
                .HasForeignKey(d => d.MarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DenominacionBienModelo_Marca");

            entity.HasOne(d => d.Mod).WithMany(p => p.DenominacionBienModelos)
                .HasForeignKey(d => d.ModId)
                .HasConstraintName("FK_DenominacionBienModelo_Modelo");
        });

        modelBuilder.Entity<DependenciaJudicial>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PK_DepedenciaJudicial");

            entity.ToTable("DependenciaJudicial", "Inv");

            entity.Property(e => e.DepId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DepDescripcion).HasMaxLength(128);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Sed).WithMany(p => p.DependenciaJudicials)
                .HasForeignKey(d => d.SedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepedenciaJudicial_Sede");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarId);

            entity.ToTable("Marca", "Gen");

            entity.Property(e => e.MarId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MarDescripcion).HasMaxLength(64);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.ModId);

            entity.ToTable("Modelo", "Gen");

            entity.Property(e => e.ModId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModDescripcion).HasMaxLength(64);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Mar).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.MarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modelo_Marca");
        });

        modelBuilder.Entity<OficinaInterna>(entity =>
        {
            entity.HasKey(e => e.OfiId);

            entity.ToTable("OficinaInterna", "Inv");

            entity.Property(e => e.OfiId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.OfiDescripcion).HasMaxLength(128);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Dep).WithMany(p => p.OficinaInternas)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OficinaInterna_DepedenciaJudicial");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.ParId);

            entity.ToTable("Parametro", "Gen");

            entity.Property(e => e.ParId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ParDescripcion).HasMaxLength(128);
            entity.Property(e => e.ParIdentificador).HasMaxLength(32);
            entity.Property(e => e.ParValor)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PerId);

            entity.ToTable("Persona", "Gen");

            entity.HasIndex(e => new { e.PerTipoDocumento, e.PerNumeroDocumento }, "IX_Persona").IsUnique();

            entity.HasIndex(e => new { e.PerTipoDocumento, e.PerNumeroDocumento }, "IX_Persona_1").IsUnique();

            entity.Property(e => e.PerId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PerApellidoMaterno).HasMaxLength(128);
            entity.Property(e => e.PerApellidoPaterno).HasMaxLength(128);
            entity.Property(e => e.PerCelular).HasMaxLength(16);
            entity.Property(e => e.PerFechaNacimiento).HasColumnType("date");
            entity.Property(e => e.PerNombres).HasMaxLength(128);
            entity.Property(e => e.PerNumeroDocumento).HasMaxLength(16);
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);

            entity.HasOne(d => d.Sed).WithMany(p => p.Personas)
                .HasForeignKey(d => d.SedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Sede");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedId);

            entity.ToTable("Sede", "Gen");

            entity.Property(e => e.SedId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
            entity.Property(e => e.SedCodigoAlterno).HasMaxLength(16);
            entity.Property(e => e.SedDescripcion).HasMaxLength(128);
            entity.Property(e => e.SedDireccion).HasMaxLength(128);
            entity.Property(e => e.SedLatitud).HasMaxLength(16);
            entity.Property(e => e.SedLongitud).HasMaxLength(16);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsrId);

            entity.ToTable("Usuario", "Gen");

            entity.HasIndex(e => e.UsrIdentificador, "IX_Usuario").IsUnique();

            entity.Property(e => e.UsrId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SecActivo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SecFechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.SecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecFechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.SecUsuarioActualizacionId).HasMaxLength(64);
            entity.Property(e => e.SecUsuarioCreacionId)
                .HasMaxLength(64)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.SecUsuarioEliminacionId).HasMaxLength(64);
            entity.Property(e => e.UsrActivo).HasMaxLength(8);
            entity.Property(e => e.UsrConectado).HasMaxLength(8);
            entity.Property(e => e.UsrIdentificador).HasMaxLength(32);

            entity.HasOne(d => d.Per).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
