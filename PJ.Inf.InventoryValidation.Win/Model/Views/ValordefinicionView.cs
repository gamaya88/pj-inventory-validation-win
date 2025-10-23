namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    public class ValordefinicionView
    {
        public Guid DfvId { get; set; }
        public Guid GrpId { get; set; }
        public Guid DefId { get; set; }
        public int DefNumber { get; set; }
        public string DfvDescripcion { get; set; }
        public string DfvDescripcionCorta { get; set; }
        public byte DfvValor { get; set; }
        public bool SegEstado { get; set; }
        public string DfvTexto1 { get; set; }
        public string DfvTexto2 { get; set; }
    }
}
