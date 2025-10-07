using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Usuario
{
    public Guid UsrId { get; set; }

    public Guid PerId { get; set; }

    public Guid SedId { get; set; }

    public byte UsrPerfilType { get; set; }

    public string UsrIdentificador { get; set; } = null!;

    public string UsrConectado { get; set; } = null!;

    public string UsrActivo { get; set; } = null!;

    public bool UsrDepositoJudicial { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<BienPatrimonial> BienPatrimonials { get; set; } = new List<BienPatrimonial>();

    public virtual Persona Per { get; set; } = null!;
}
