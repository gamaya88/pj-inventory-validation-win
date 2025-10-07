using PJ.Inf.InventoryValidation.Win.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Cache
{
    internal class DefinitionCache
    {
        public int DefNumber { get; set; }
        public int GrpNumber { get; set; }
        public List<ValordefinicionView> DefinitionValues { get; set; }
    }
}
