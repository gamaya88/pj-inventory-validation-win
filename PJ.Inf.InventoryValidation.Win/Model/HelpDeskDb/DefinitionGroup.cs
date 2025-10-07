using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

/// <summary>
/// Grupo de definiciones
/// </summary>
public partial class DefinitionGroup
{
    public Guid DfgId { get; set; }

    public Guid DefId { get; set; }

    /// <summary>
    /// Número de grupo dedefinición que servirá para agrupar las definiciones
    /// </summary>
    public int DfgNumber { get; set; }

    /// <summary>
    /// Descripcion abreviada del grupo
    /// </summary>
    public string DfgDescription { get; set; } = null!;

    /// <summary>
    /// Descripción larga del grupo
    /// </summary>
    public string DfgDescriptionLarge { get; set; } = null!;

    /// <summary>
    /// Determina si el registro está activo o no
    /// </summary>
    public bool DfgActive { get; set; }

    public DateTime SecCreateAt { get; set; }

    public DateTime? SecUpdateAt { get; set; }

    public string SecUserCreate { get; set; } = null!;

    public string? SecUserUpdate { get; set; }

    public DateTime? SecDeleteAt { get; set; }

    public string? SecUserDelete { get; set; }

    public virtual Definition Def { get; set; } = null!;

    public virtual ICollection<DefinitionGroupValue> DefinitionGroupValues { get; set; } = new List<DefinitionGroupValue>();
}
