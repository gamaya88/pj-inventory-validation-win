using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Trabajador
{
    public Guid TrbId { get; set; }

    public Guid PerId { get; set; }

    public Guid DepId { get; set; }

    public string TrbCargo { get; set; } = null!;

    public string? TrbCodigoSiga { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual DependenciaJudicial Dep { get; set; } = null!;

    public virtual Persona Per { get; set; } = null!;
}
