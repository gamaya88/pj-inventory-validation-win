using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

public partial class ActaBienPatrimonial
{
    public Guid AbpId { get; set; }

    public Guid PerId { get; set; }

    public DateTime? AbpUltimaImpresion { get; set; }

    public byte AbpEstadoActa { get; set; }

    public string? UsrIdentificadorImprime { get; set; }

    public string PerNombre { get; set; } = null!;

    public int AbpImpresiones { get; set; }

    public string? AbpArchivoSubido { get; set; }

    public string? AbpArchivoDescargado { get; set; }

    public string? AbpArchivoFirmado { get; set; }

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<BienPatrimonial> BienPatrimonials { get; set; } = new List<BienPatrimonial>();
}
