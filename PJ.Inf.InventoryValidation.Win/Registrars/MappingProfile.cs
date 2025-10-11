using AutoMapper;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Registrars
{
    public class MappingProfile : Profile
    {
        private static IMapper _instance;

        public static IMapper GetInstance()
        {
            if (_instance == null)
            {
                // Auto Mapper Configurations
                var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();

                _instance = mapper;
            }
            return _instance;
        }

        private MappingProfile()
        {
            CreateMap<ActaBienPatrimonial, ActaBienPatrimonialView>()
                .ReverseMap()
                .ForAllMembersOfType(typeof(ICollection<>), x => x.UseDestinationValue());

            CreateMap<BienPatrimonialView, BienPatrimonialReporteView>()
                .ReverseMap();

            CreateMap<BienPatrimonial, BienPatrimonialView>()
                .ForMember(dest => dest.PerNombreLargo, opt => opt.MapFrom(src => src.Per != null ? $"{src.Per.PerApellidoPaterno} {src.Per.PerApellidoMaterno}, {src.Per.PerNombres}" : ""))
                .ForMember(dest => dest.PerNuevoNombreLargo, opt => opt.MapFrom(src => src.PerNuevo != null ? $"{src.PerNuevo.PerApellidoPaterno} {src.PerNuevo.PerApellidoMaterno}, {src.PerNuevo.PerNombres}" : ""))
                .ForMember(dest => dest.SedId, opt => opt.MapFrom(src => src.Ofi.Dep.SedId))
                .ForMember(dest => dest.DepId, opt => opt.MapFrom(src => src.Ofi.DepId))
                .ForMember(dest => dest.MarId, opt => opt.MapFrom(src => src.Dbm.MarId))
                .ForMember(dest => dest.ModId, opt => opt.MapFrom(src => src.Dbm.ModId))
                .ForMember(dest => dest.DebId, opt => opt.MapFrom(src => src.Dbm.DebId))
                .ForMember(dest => dest.ModDescripcion, opt => opt.MapFrom(src => src.Dbm.Mod != null ? src.Dbm.Mod.ModDescripcion : "**"))
                .ForMember(dest => dest.MarDescripcion, opt => opt.MapFrom(src => src.Dbm.Mar.MarDescripcion))
                .ForMember(dest => dest.DebDescripcion, opt => opt.MapFrom(src => src.Dbm.Deb.DebDescripcion))
                .ReverseMap();

            CreateMap<DefinitionValue, ValordefinicionView>()
                .ForMember(dest => dest.GrpId, opt => opt.MapFrom(src => src.DefinitionGroupValues.FirstOrDefault() != null ? src.DefinitionGroupValues.FirstOrDefault().Dfg.DfgId : Guid.Empty))
                .ForMember(dest => dest.DfvDescripcion, opt => opt.MapFrom(src => src.DfvDescription))
                .ForMember(dest => dest.DfvDescripcionCorta, opt => opt.MapFrom(src => src.DfvDescriptionShort))
                .ForMember(dest => dest.DfvValor, opt => opt.MapFrom(src => src.DfvValue))
                .ForMember(dest => dest.SegEstado, opt => opt.MapFrom(src => src.DfvActive ?? false))
                .ForMember(dest => dest.DfvTexto1, opt => opt.MapFrom(src => src.DfvText01 ?? string.Empty))
                .ReverseMap();

            // Mapeo de Modelo a ModeloView
            CreateMap<Modelo, ModeloView>()
                .ReverseMap();

            CreateMap<Persona, PersonaView>()
                .ForMember(dest => dest.PerDescripcionCorte, opt => opt.MapFrom(src => "Corte Superior de San Martín"))
                .ForMember(dest => dest.DepParentDescripcion, opt => opt.MapFrom(src => src.Trabajador != null && src.Trabajador.Dep.DepParent != null ? src.Trabajador.Dep.DepParent.DepDescripcion : ""))
                .ForMember(dest => dest.DepDescripcion, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.DepDescripcion : ""))
                .ForMember(dest => dest.SedDireccion, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.Sed.SedDireccion : ""))
                .ForMember(dest => dest.SedDescripcion, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.Sed.SedDescripcion : ""))
                .ForMember(dest => dest.SedDepartamento, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.Sed.SedDepartamento : ""))
                .ForMember(dest => dest.SedProvincia, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.Sed.SedProvincia : ""))
                .ForMember(dest => dest.SedDistrito, opt => opt.MapFrom(src => src.Trabajador != null ? src.Trabajador.Dep.Sed.SedDistrito : ""))
                .ForMember(dest => dest.PerNumeroDocumento, opt => opt.MapFrom(src => src.PerNumeroDocumento))
                .ForMember(dest => dest.PerNombreLargo, opt => opt.MapFrom(src => $"{src.PerApellidoPaterno} {src.PerApellidoMaterno}, {src.PerNombres}"))
                .ReverseMap();

            // Mapeo de Marca a MarcaView (incluye Modelos)
            CreateMap<Marca, MarcaView>()
                .ReverseMap()
                .ForAllMembersOfType(typeof(ICollection<>), x => x.UseDestinationValue());

            CreateMap<DenominacionBienModelo, DenominacionBienModeloView>()
                .ForMember(dest => dest.ModDescripcion, opt => opt.MapFrom(src => src.Mod != null ? src.Mod.ModDescripcion : "**"))
                .ForMember(dest => dest.MarDescripcion, opt => opt.MapFrom(src => src.Mar.MarDescripcion))
                .ForMember(dest => dest.DebDescripcion, opt => opt.MapFrom(src => src.Deb.DebDescripcion))
                .ReverseMap()
                .ForAllMembersOfType(typeof(ICollection<>), x => x.UseDestinationValue());
        }
    }
}
