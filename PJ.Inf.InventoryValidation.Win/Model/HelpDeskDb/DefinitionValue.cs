using System;
using System.Collections.Generic;

namespace PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;

/// <summary>
/// Valores de definiciones del sistema, que servirán como maestros de los sistemas
/// </summary>
public partial class DefinitionValue
{
    public Guid DfvId { get; set; }

    public Guid DefId { get; set; }

    /// <summary>
    /// Usado para relacionar con tablas de sunat por ejemplo
    /// </summary>
    public string DfvAlterCode { get; set; } = null!;

    /// <summary>
    /// Descripción del valor de la definición
    /// </summary>
    public string DfvDescription { get; set; } = null!;

    /// <summary>
    /// Descripción corta del valor de la definición
    /// </summary>
    public string DfvDescriptionShort { get; set; } = null!;

    /// <summary>
    /// Texto alternativo del valor de definicion
    /// </summary>
    public string? DfvText01 { get; set; }

    /// <summary>
    /// Valor con el que se va a asociar en la tabla
    /// </summary>
    public byte DfvValue { get; set; }

    /// <summary>
    /// Determina si un registro está activo o no
    /// </summary>
    public bool? DfvActive { get; set; }

    public DateTime? SecCreateAt { get; set; }

    public DateTime? SecUpdateAt { get; set; }

    public string? SecUserCreate { get; set; }

    public string? SecUserUpdate { get; set; }

    public DateTime? SecDeleteAt { get; set; }

    public string? SecUserDelete { get; set; }

    public virtual Definition Def { get; set; } = null!;

    public virtual ICollection<DefinitionGroupValue> DefinitionGroupValues { get; set; } = new List<DefinitionGroupValue>();
}
