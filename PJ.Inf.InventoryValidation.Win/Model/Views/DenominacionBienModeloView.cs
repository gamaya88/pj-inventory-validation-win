using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    public class DenominacionBienModeloView
    {
        public Guid DbmId { get; set; }

        public Guid MarId { get; set; }

        public Guid? ModId { get; set; }

        public Guid DebId { get; set; }

        public string DebDescripcion { get; set; } = null!;

        public string MarDescripcion { get; set; } = null!;

        public string ModDescripcion { get; set; } = null!;
    }
}
