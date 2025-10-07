using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Views;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class DenominacionBienModeloService
    {
        private IMapper mapper;

        public DenominacionBienModeloService()
        {
            mapper = MappingProfile.GetInstance();
        }

        public async Task<List<DenominacionBienModeloView>> GetDenominacionesPorMarca(Guid MarId)
        {
            var cacheDenominaciones = DenominacionBienModeloCacheService.GetInstance().GetDenominaciones(MarId);

            if (!cacheDenominaciones.Any())
            {
                using (var context = new HelpDeskDbContext())
                {
                    var denominaciones = await context.DenominacionBienModelos
                        .Include(x => x.Deb)
                        .Include(x => x.Mar)
                        .Include(x => x.Mod)
                        .Where(x => x.SecActivo == true && x.MarId == MarId)
                        .OrderBy(x => x.Deb.DebDescripcion)
                        .ToListAsync();

                    cacheDenominaciones = mapper.Map<List<Model.Views.DenominacionBienModeloView>>(denominaciones);
                    DenominacionBienModeloCacheService.GetInstance().SetDenominaciones(Guid.Empty, cacheDenominaciones);
                }
            }
            return cacheDenominaciones;
        }

        public async Task<List<DenominacionBienModeloView>> GetDenominaciones(string denominacion, string marca, string modelo)
        {
            using (var context = new HelpDeskDbContext())
            {
                var denominaciones = await context.DenominacionBienModelos
                        .Include(x => x.Deb)
                        .Include(x => x.Mar)
                        .Include(x => x.Mod)
                        .Where(x => 
                            x.SecActivo == true && 
                            x.Deb.DebDescripcion.Contains(denominacion)
                            && x.Mar.MarDescripcion.Contains(marca)
                            && (x.Mod != null ? x.Mod.ModDescripcion.Contains(modelo) : true)
                        ).ToListAsync();

                var cacheDenominaciones = mapper.Map<List<Model.Views.DenominacionBienModeloView>>(denominaciones);

                return cacheDenominaciones;
            }            
        }
    }
}
