namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class MarcaCacheService
    {
        private static List<Model.Views.MarcaView> _marcas;

        private static MarcaCacheService _instance;

        public MarcaCacheService()
        {
            _marcas = new List<Model.Views.MarcaView>();
        }

        public static MarcaCacheService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MarcaCacheService();
            }
            return _instance;
        }

        public List<Model.Views.MarcaView> GetMarcas()
        {
            return _marcas;
        }
        public static void SetMarcas(List<Model.Views.MarcaView> marcas)
        {
            _marcas = marcas;
        }
    }
}
