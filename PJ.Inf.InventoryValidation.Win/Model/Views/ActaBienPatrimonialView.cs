using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Model.Views
{
    public class ActaBienPatrimonialView
    {
        public Guid AbpId { get; set; }

        public Guid PerId { get; set; }

        public string PerNombre { get; set; } = null!;

        public byte AbpEstadoActa { get; set; }

        public string AbpDescripcionEstadoActa { get; set; }

        public DateTime? AbpUltimaImpresion { get; set; }

        public string? UsrIdentificadorImprime { get; set; }

        public int AbpImpresiones { get; set; }
    }
}
