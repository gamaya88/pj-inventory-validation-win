using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class Parametro
{
    public Guid ParId { get; set; }

    public string ParIdentificador { get; set; } = null!;

    public string ParDescripcion { get; set; } = null!;

    public byte ParTipo { get; set; }

    public string ParValor { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }
}
