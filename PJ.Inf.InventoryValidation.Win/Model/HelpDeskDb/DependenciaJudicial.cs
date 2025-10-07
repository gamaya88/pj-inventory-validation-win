using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class DependenciaJudicial
{
    public Guid DepId { get; set; }

    public Guid SedId { get; set; }

    public Guid? InsId { get; set; }

    public string DepDescripcion { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<OficinaInterna> OficinaInternas { get; set; } = new List<OficinaInterna>();

    public virtual Sede Sed { get; set; } = null!;
}
