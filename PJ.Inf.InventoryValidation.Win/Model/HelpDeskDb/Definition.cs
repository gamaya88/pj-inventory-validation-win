using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

/// <summary>
/// Definiciones del sistema
/// </summary>
public partial class Definition
{
    public Guid DefId { get; set; }

    /// <summary>
    /// Número de definicion, que servirá para relacionarlos con la tabla respectiva
    /// </summary>
    public int DefNumber { get; set; }

    /// <summary>
    /// Descripción de la definición
    /// </summary>
    public string DefDescription { get; set; } = null!;

    public bool? SecActivo { get; set; }

    public string SecUsuarioCreacionId { get; set; } = null!;

    public string? SecUsuarioActualizacionId { get; set; }

    public string? SecUsuarioEliminacionId { get; set; }

    public DateTime SecFechaCreacion { get; set; }

    public DateTime? SecFechaActualizacion { get; set; }

    public DateTime? SecFechaEliminacion { get; set; }

    public virtual ICollection<DefinitionGroup> DefinitionGroups { get; set; } = new List<DefinitionGroup>();

    public virtual ICollection<DefinitionValue> DefinitionValues { get; set; } = new List<DefinitionValue>();
}
