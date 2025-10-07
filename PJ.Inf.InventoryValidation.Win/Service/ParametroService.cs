using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class ParametroService
    {
        public async Task<List<Parametro>?> Retorna(List<string> nombre)
        {
            List<Parametro>? parametro = null;

            using (var context = new HelpDeskDbContext())
            {
                parametro = await context.Parametros
                    .Where(p => nombre.Contains(p.ParIdentificador))
                    .ToListAsync();
            }

            return parametro;
        }
    }
}
