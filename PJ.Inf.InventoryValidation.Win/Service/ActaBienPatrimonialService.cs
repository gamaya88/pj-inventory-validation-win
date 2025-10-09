using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class ActaBienPatrimonialService
    {
        private IMapper mapper;

        public ActaBienPatrimonialService()
        {
            mapper = MappingProfile.GetInstance();
        }

        public async Task Modifica(ActaBienPatrimonial actaBienPatrimonial)
        {
            using (var context = new HelpDeskDbContext())
            {
                context.Attach(actaBienPatrimonial);
                context.Entry(actaBienPatrimonial).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }

        public async Task<ActaBienPatrimonial> GetPorPersona(Guid perId)
        {
            using (var context = new HelpDeskDbContext())
            {
                var acta = await context.ActaBienPatrimonials
                            .FirstOrDefaultAsync(x => x.PerId == perId);

                return acta;
            }
        }

        public async Task<ActaBienPatrimonial> Get(Guid abpId)
        {
            using (var context = new HelpDeskDbContext())
            {
                var acta = await context.ActaBienPatrimonials
                            .FirstOrDefaultAsync(x => x.AbpId == abpId);

                return acta;
            }
        }

        public async Task<List<ActaBienPatrimonialView>> Get(byte estado = EstadoActaEnum.TODOS)
        {
            using (var context = new HelpDeskDbContext())
            {
                var query = context.ActaBienPatrimonials.AsQueryable();

                var mostrar = new List<byte>() { EstadoActaEnum.SUBIDA, EstadoActaEnum.FIRMADA_PATRIMONIO };

                if (estado != EstadoActaEnum.TODOS)
                {
                    query = query.Where(x => x.AbpEstadoActa == estado);
                }
                else
                {
                    query = query.Where(x => mostrar.Contains(x.AbpEstadoActa));
                }

                var actasEntidades = await query.ToListAsync();

                var actas = mapper.Map<List<ActaBienPatrimonialView>>(actasEntidades);

                return actas.ToList();
            }
        }
    }
}
