using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    public class BienPatrimonialView
    {
        public Guid DbmId { get; set; }

        public Guid MarId { get; set; }

        public Guid? ModId { get; set; }

        public Guid DebId { get; set; }

        public string DebDescripcion { get; set; } = null!;

        public string MarDescripcion { get; set; } = null!;

        public string ModDescripcion { get; set; } = null!;

        public Guid BptId { get; set; }

        public Guid? PerId { get; set; }

        public string PerNombreLargo { get; set; }

        public Guid? PerNuevoId { get; set; }

        public string PerNuevoNombreLargo { get; set; }

        public Guid? UsrInventariaId { get; set; }

        public Guid SedId { get; set; }

        public Guid DepId { get; set; }

        public Guid OfiId { get; set; }

        public Guid? OfiNuevoId { get; set; }

        public string BptCodigoPatrimonial { get; set; } = null!;

        public string BptCodigoCatalogo { get; set; } = null!;

        public string? BptCodigoInterno { get; set; }

        public byte BptEstadoConservacionTipo { get; set; }

        public byte BptColorTipo { get; set; }

        public string? BptSerie { get; set; }

        public byte BptInventariadoTipo { get; set; }

        public string BptObservacion { get; set; }
    }
}
