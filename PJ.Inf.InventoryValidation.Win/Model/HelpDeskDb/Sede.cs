using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Sede
{
    public Guid SedId { get; set; }

    public string SedCodigoAlterno { get; set; } = null!;

    public string SedDescripcion { get; set; } = null!;

    public string SedDireccion { get; set; } = null!;

    public string SedLongitud { get; set; } = null!;

    public string SedLatitud { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<DependenciaJudicial> DependenciaJudicials { get; set; } = new List<DependenciaJudicial>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
