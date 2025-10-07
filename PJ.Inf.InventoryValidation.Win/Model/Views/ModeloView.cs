using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    internal class ModeloView
    {
        public Guid ModId { get; set; }

        public Guid MarId { get; set; }

        public string ModDescripcion { get; set; } = null!;
    }
}
