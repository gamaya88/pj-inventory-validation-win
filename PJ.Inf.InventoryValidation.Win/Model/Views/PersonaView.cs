using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    internal class PersonaView
    {
        public Guid PerId { get; set; }

        public string PerNombreLargo { get; set; }

        public string PerDescripcionCorte { get; set; }

        public string DepParentDescripcion { get; set; }

        public string DepDescripcion { get; set; }

        public string SedDireccion { get; set; }

        public string SedDescripcion { get; set; }

        public string SedDepartamento { get; set; }

        public string SedProvincia { get; set; }

        public string SedDistrito { get; set; }

        public string PerNumeroDocumento { get; set; }
    }
}
