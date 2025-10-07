using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class UsuarioService
    {
        public async Task<Usuario> Get()
        {
            using (var context = new HelpDeskDbContext())
            {
                string usuarioIdentificado = UtilService.UsuarioDetectado();
                var sede = await context.Usuarios
                                .Include(u => u.Per)
                                    .ThenInclude(p => p.Sed)
                                        .ThenInclude(p => p.DependenciaJudicials)
                                            .ThenInclude(p => p.OficinaInternas)
                                .Include(u => u.Per)
                                    .ThenInclude(p => p.Sed)
                                        .ThenInclude(p => p.Personas.Where(x => x.Usuarios.Any()))
                                .Where(u => u.UsrIdentificador == usuarioIdentificado && u.UsrConectado == "S" && u.SecActivo == true)
                                .FirstOrDefaultAsync();

                return sede;
            }
        }
    }
}
