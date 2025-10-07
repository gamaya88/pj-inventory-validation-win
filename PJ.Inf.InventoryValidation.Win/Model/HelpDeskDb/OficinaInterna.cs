using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class OficinaInterna
{
    public Guid OfiId { get; set; }

    public Guid DepId { get; set; }

    public string OfiDescripcion { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<BienPatrimonial> BienPatrimonialOfiNuevos { get; set; } = new List<BienPatrimonial>();

    public virtual ICollection<BienPatrimonial> BienPatrimonialOfis { get; set; } = new List<BienPatrimonial>();

    public virtual DependenciaJudicial Dep { get; set; } = null!;
}
