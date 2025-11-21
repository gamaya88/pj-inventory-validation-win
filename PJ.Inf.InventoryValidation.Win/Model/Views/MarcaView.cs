namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    internal class MarcaView
    {
        public Guid MarId { get; set; }

        public string MarDescripcion { get; set; } = null!;

        public virtual ICollection<ModeloView> Modelos { get; set; } = new List<ModeloView>();
    }
}
