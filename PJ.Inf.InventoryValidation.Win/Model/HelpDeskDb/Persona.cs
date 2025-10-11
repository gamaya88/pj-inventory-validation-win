using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Persona
{
    public Guid PerId { get; set; }

    public Guid SedId { get; set; }

    public byte PerTipoDocumento { get; set; }

    public string PerNumeroDocumento { get; set; } = null!;

    public string PerApellidoPaterno { get; set; } = null!;

    public string PerApellidoMaterno { get; set; } = null!;

    public string PerNombres { get; set; } = null!;

    public DateTime PerFechaNacimiento { get; set; }

    public string? PerCelular { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<BienPatrimonial> BienPatrimonialPerNuevos { get; set; } = new List<BienPatrimonial>();

    public virtual ICollection<BienPatrimonial> BienPatrimonialPers { get; set; } = new List<BienPatrimonial>();

    public virtual Sede Sed { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
