namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    public class BienPatrimonialReporteView
    {
        public Guid BptId { get; set; }

        public string DebDescripcion { get; set; } = null!;

        public string MarDescripcion { get; set; } = null!;

        public string ModDescripcion { get; set; } = null!;

        public string BptCodigoPatrimonial { get; set; } = null!;

        public byte BptEstadoConservacionTipo { get; set; }

        public string BptEstadoConservacionDescripcionTipo { get; set; }

        public byte BptNuevoEstadoConservacionTipo { get; set; }

        public string BptNuevoEstadoConservacionDescripcionTipo { get; set; }

        public byte BptColorTipo { get; set; }

        public string BptColorDescripcionTipo { get; set; }

        public string? BptSerie { get; set; }

        public string? BptNuevaSerie { get; set; }
    }
}
