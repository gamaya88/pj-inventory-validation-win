using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class PersonaService
    {
        private IMapper mapper;

        public PersonaService()
        {
            mapper = MappingProfile.GetInstance();
        }

        public async Task<PersonaView> GetByTrabajador(Guid perId)
        {
            using (var context = new HelpDeskDbContext())
            {
                var trabajador = await context.Personas
                                    .Include(s => s.Trabajador)
                                        .ThenInclude(s => s.Dep)
                                            .ThenInclude(s => s.Sed)
                                    .Include(s => s.Trabajador)
                                        .ThenInclude(s => s.Dep)
                                            .ThenInclude(s => s.DepParent)
                                    .FirstOrDefaultAsync(x => x.PerId == perId);

                return mapper.Map<PersonaView>(trabajador);
            }
        }
    }
}
