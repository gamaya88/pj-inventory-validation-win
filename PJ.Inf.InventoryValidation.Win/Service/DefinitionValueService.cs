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
    internal class DefinitionValueService
    {
        private IMapper mapper;
        public DefinitionValueService()
        {
            mapper = MappingProfile.GetInstance();
        }
        public async Task<List<ValordefinicionView>> GetByDefinitionAndGroupAsync(int DefNumber, int GrpNumber = DefinitionGroupEnum.SIN_GRUPO, bool AgregarTodos = false)
        {
            var cacheDefinitionValue = DefinitionValueCacheService.GetInstance().GetDefinitionValues(DefNumber, GrpNumber);

            if (!cacheDefinitionValue.Any())
            {
                using (var context = new HelpDeskDbContext())
                {
                    var query = context.DefinitionValues
                                .Include(dv => dv.Def)
                                .Include(d => d.DefinitionGroupValues)
                                    .ThenInclude(d => d.Dfg)
                                .Where(dv => dv.Def.DefNumber == DefNumber);

                    if (GrpNumber > 0)
                    {
                        query = query.Where(dv => dv.DefinitionGroupValues.Any(dgv => dgv.Dfg.DfgNumber == GrpNumber));
                    }

                    var definitionValue = await query.ToListAsync();

                    cacheDefinitionValue = mapper.Map<List<ValordefinicionView>>(definitionValue);

                    DefinitionValueCacheService.GetInstance().SetDefinitionValues(DefNumber, GrpNumber, cacheDefinitionValue);
                }
            }

            if (AgregarTodos)
            {
                var todos = new ValordefinicionView
                {
                    DfvId = Guid.Empty,
                    GrpId = Guid.Empty,
                    DefId = Guid.Empty,
                    DefNumber = 0,
                    DfvDescripcion = "TODOS",
                    DfvDescripcionCorta = "TODOS",
                    DfvValor = 255,
                    SegEstado = true,
                    DfvTexto1 = string.Empty,
                    DfvTexto2 = string.Empty
                };
                cacheDefinitionValue.Insert(0, todos);
            }

            return cacheDefinitionValue;
        }
    }
}
