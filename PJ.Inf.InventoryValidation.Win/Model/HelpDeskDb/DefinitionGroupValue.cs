using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

/// <summary>
/// Valores de grupo de definiciones
/// </summary>
public partial class DefinitionGroupValue
{
    public Guid DgvId { get; set; }

    public Guid DfgId { get; set; }

    public Guid DfvId { get; set; }

    /// <summary>
    /// Determina si el registro está activo o no
    /// </summary>
    public bool? DfvStatus { get; set; }

    public DateTime SecCreateAt { get; set; }

    public DateTime? SecUpdateAt { get; set; }

    public string SecUserCreate { get; set; } = null!;

    public string? SecUserUpdate { get; set; }

    public DateTime? SecDeleteAt { get; set; }

    public string? SecUserDelete { get; set; }

    public virtual DefinitionGroup Dfg { get; set; } = null!;

    public virtual DefinitionValue Dfv { get; set; } = null!;
}
