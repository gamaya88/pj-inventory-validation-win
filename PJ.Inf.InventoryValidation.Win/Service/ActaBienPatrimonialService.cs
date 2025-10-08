using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Registrars;
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

        public async Task<ActaBienPatrimonial> Get(Guid perId)
        {
            using (var context = new HelpDeskDbContext())
            {
                var acta = await context.ActaBienPatrimonials
                            .FirstOrDefaultAsync(x => x.PerId == perId);

                return acta;
            }
        }
    }
}
