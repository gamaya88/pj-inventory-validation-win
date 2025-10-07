using PJ.Inf.InventoryValidation.Win.Model.Cache;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class DenominacionBienModeloCacheService
    {
        private static List<DenominacionBienModeloCache> _cacheDenominaciones = new List<DenominacionBienModeloCache>();

        private static DenominacionBienModeloCacheService _instance;

        public static DenominacionBienModeloCacheService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DenominacionBienModeloCacheService();
            }
            return _instance;
        }

        public List<DenominacionBienModeloView> GetDenominaciones(Guid MarId)
        {
            var denominaciones = new List<DenominacionBienModeloView>();

            if (_cacheDenominaciones.Any(x => x.MarId == MarId))
            {
                denominaciones = _cacheDenominaciones.FirstOrDefault(x => x.MarId == MarId).Denominaciones;
            }

            return denominaciones;
        }

        public void SetDenominaciones(Guid MarId, List<DenominacionBienModeloView> denominaciones)
        {
            _cacheDenominaciones.Add(new DenominacionBienModeloCache
            {
                MarId = MarId,
                Denominaciones = denominaciones
            });
        }
    }
}
