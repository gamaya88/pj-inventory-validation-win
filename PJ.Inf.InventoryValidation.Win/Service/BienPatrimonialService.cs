using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Utils.Enums;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    internal class BienPatrimonialService
    {
        private IMapper mapper;

        public BienPatrimonialService()
        {
            mapper = MappingProfile.GetInstance();
        }

        public async Task Modifica(BienPatrimonial bienPatrimonial)
        {
            using (var context = new HelpDeskDbContext())
            {
                if(bienPatrimonial.Abp != null && bienPatrimonial.Abp.AbpId == Guid.Empty)
                {
                    context.Attach(bienPatrimonial.Abp);
                    context.Entry(bienPatrimonial.Abp).State = EntityState.Added;
                }

                context.Attach(bienPatrimonial);
                context.Entry(bienPatrimonial).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }

        public async Task<BienPatrimonial> Get(Guid bptId)
        {
            using (var context = new HelpDeskDbContext())
            {
                var bien = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .FirstOrDefaultAsync(x => x.BptId == bptId);

                return bien;
            }
        }

        public async Task<List<BienPatrimonialView>> GetBySerie(string serie)
        {
            using (var context = new HelpDeskDbContext())
            {
                var bienes = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .Where(x => 
                        ((x.BptNuevaSerie != null && x.BptNuevaSerie.Contains(serie)) || (x.BptSerie != null && 
                        x.BptSerie.Contains(serie))) && x.BptInventariadoTipo == InventariadoTipoEnum.SIN_INVENTARIAR
                    )
                    .ToListAsync();

                var bienesPatrimonial = mapper.Map<List<BienPatrimonialView>>(bienes);

                return bienesPatrimonial;
            }
        }

        public async Task<BienPatrimonialView> GetByCodigoPatrimonial(string bptCodigoPatrimonial)
        {
            using (var context = new HelpDeskDbContext())
            {
                var bienes = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .FirstOrDefaultAsync(x => x.BptCodigoPatrimonial == bptCodigoPatrimonial);

                var bienesPatrimonial = mapper.Map<BienPatrimonialView>(bienes);

                return bienesPatrimonial;
            }
        }

        public async Task<List<BienPatrimonialView>> GetByObservados()
        {
            using (var context = new HelpDeskDbContext())
            {
                var bienesInvetariadoPor = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .Where(x => x.BptInventariadoTipo == InventariadoTipoEnum.REPORTADO_POR_REVISAR && x.SecActivo == true)
                    .ToListAsync();

                var bienesPatrimonial = mapper.Map<List<BienPatrimonialView>>(bienesInvetariadoPor);

                return bienesPatrimonial;
            }
        }

        public async Task<List<BienPatrimonialView>> GetBySerie(Guid BptId, string BptSerie)
        {
            using (var context = new HelpDeskDbContext())
            {
                var bienesInvetariadoPor = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .Where(x => x.BptId != BptId && x.BptSerie == BptSerie && x.SecActivo == true)
                    .ToListAsync();

                var bienesPatrimonial = mapper.Map<List<BienPatrimonialView>>(bienesInvetariadoPor);

                return bienesPatrimonial;
            }
        }

        public async Task<List<BienPatrimonialView>> GetByUsuarioQueInventario(Usuario usuario)
        {
            using (var context = new HelpDeskDbContext())
            {
                var trabajadoresInventariadosPorUsuario = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .Where(x => x.UsrInventariaId == usuario.UsrId && x.SecActivo == true && x.BptInventariadoTipo == InventariadoTipoEnum.INVENTARIADO)
                    .Select(x => x.PerNuevoId)
                    .Distinct()
                    .ToListAsync();

                if (!trabajadoresInventariadosPorUsuario.Contains(usuario.PerId))
                {
                    trabajadoresInventariadosPorUsuario.Add(usuario.PerId);
                }

                var bienesInvetariadoPor = await context.BienPatrimonials
                    .Include(x => x.Per)
                    .Include(x => x.PerNuevo)
                    .Include(x => x.Ofi)
                        .ThenInclude(x => x.Dep)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mar)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Mod)
                    .Include(x => x.Dbm)
                        .ThenInclude(x => x.Deb)
                    .Where(x => trabajadoresInventariadosPorUsuario.Contains(x.PerNuevoId) && x.SecActivo == true && x.BptInventariadoTipo == InventariadoTipoEnum.INVENTARIADO)
                    .ToListAsync();

                var bienesPatrimonial = mapper.Map<List<BienPatrimonialView>>(bienesInvetariadoPor);

                return bienesPatrimonial;
            }
        }
    }
}
