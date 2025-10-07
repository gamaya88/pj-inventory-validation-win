using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class BienPatrimonial
{
    public Guid BptId { get; set; }

    public Guid DbmId { get; set; }

    public Guid? PerId { get; set; }

    public Guid? PerNuevoId { get; set; }

    public Guid? UsrInventariaId { get; set; }

    public Guid OfiId { get; set; }

    public Guid? OfiNuevoId { get; set; }

    public string BptCodigoPatrimonial { get; set; } = null!;

    public string BptCodigoCatalogo { get; set; } = null!;

    public string? BptCodigoInterno { get; set; }

    public byte? BptNuevoEstadoConservacionTipo { get; set; }

    /// <summary>
    /// DefId = 8
    /// </summary>
    public byte BptEstadoConservacionTipo { get; set; }

    public byte BptColorTipo { get; set; }

    public string? BptSerie { get; set; }

    public string? BptNuevaSerie { get; set; }

    /// <summary>
    /// 1-&gt; sin inventariar, 2-&gt; inventariado, 3-&gt;Reportado por revisar
    /// </summary>
    public byte BptInventariadoTipo { get; set; }

    public string? BptObservacion { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual DenominacionBienModelo Dbm { get; set; } = null!;

    public virtual OficinaInterna Ofi { get; set; } = null!;

    public virtual OficinaInterna? OfiNuevo { get; set; }

    public virtual Persona? Per { get; set; }

    public virtual Persona? PerNuevo { get; set; }

    public virtual Usuario? UsrInventaria { get; set; }
}
