using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class DenominacionBienModelo
{
    public Guid DbmId { get; set; }

    public Guid MarId { get; set; }

    public Guid? ModId { get; set; }

    public Guid DebId { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<BienPatrimonial> BienPatrimonials { get; set; } = new List<BienPatrimonial>();

    public virtual DenominacionBien Deb { get; set; } = null!;

    public virtual Marca Mar { get; set; } = null!;

    public virtual Modelo? Mod { get; set; }
}
