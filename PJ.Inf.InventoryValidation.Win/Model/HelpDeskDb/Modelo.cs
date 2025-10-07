using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Modelo
{
    public Guid ModId { get; set; }

    public Guid MarId { get; set; }

    public string ModDescripcion { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<DenominacionBienModelo> DenominacionBienModelos { get; set; } = new List<DenominacionBienModelo>();

    public virtual Marca Mar { get; set; } = null!;
}
