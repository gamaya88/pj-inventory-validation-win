using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Cache
{
    internal class DenominacionBienModeloCache
    {
        public Guid MarId { get; set; }

        public List<Model.Views.DenominacionBienModeloView> Denominaciones { get; set; }
    }
}
