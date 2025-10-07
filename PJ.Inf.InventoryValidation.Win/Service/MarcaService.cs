using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class MarcaService
    {
        private IMapper mapper;

        public MarcaService()
        {
            mapper = MappingProfile.GetInstance();
        }

        public async Task<List<MarcaView>> GetAll()
        {
            var cacheMarcas = MarcaCacheService.GetInstance().GetMarcas();

            if (!cacheMarcas.Any())
            {
                using (var context = new HelpDeskDbContext())
                {
                    var marcas = await context.Marcas
                        .Include(m => m.Modelos)
                        .Where(x => x.SecActivo == true)
                        .OrderBy(x => x.MarDescripcion)
                        .ToListAsync();

                    cacheMarcas = mapper.Map<List<Model.Views.MarcaView>>(marcas);

                    MarcaCacheService.SetMarcas(cacheMarcas);
                }
            }

            return cacheMarcas;
        }
    }
}
