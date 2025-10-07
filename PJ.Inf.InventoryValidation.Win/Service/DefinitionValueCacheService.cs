using PJ.Inf.InventoryValidation.Win.Model.Cache;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class DefinitionValueCacheService
    {
        private List<DefinitionCache> _definitionCache;

        private static DefinitionValueCacheService _instance;

        private DefinitionValueCacheService()
        {
            _definitionCache = new List<DefinitionCache>();
        }

        public static DefinitionValueCacheService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DefinitionValueCacheService();
            }
            return _instance;
        }

        public List<ValordefinicionView> GetDefinitionValues(int DefNumber, int GrpNumber)
        {
            var definitionValues = new List<ValordefinicionView>();

            if (_definitionCache.Any(x => x.DefNumber == DefNumber && x.GrpNumber == GrpNumber))
            {
                definitionValues.AddRange(_definitionCache.First(x => x.DefNumber == DefNumber && x.GrpNumber == GrpNumber).DefinitionValues);
            }

            return definitionValues;
        }

        public void SetDefinitionValues(int DefNumber, int GrpNumber, List<ValordefinicionView> definitionValues)
        {
            var definitionCache = new DefinitionCache
            {
                DefNumber = DefNumber,
                GrpNumber = GrpNumber,
                DefinitionValues = definitionValues
            };

            _definitionCache.Add(definitionCache);
        }
    }
}
