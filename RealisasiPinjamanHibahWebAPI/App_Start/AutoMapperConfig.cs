using AutoMapper;
using RealisasiPinjamanHibahDataAccess;
using RealisasiPinjamanHibahWebAPI.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealisasiPinjamanHibahWebAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BusinessMappingProfile>();
            });
        }
        public class BusinessMappingProfile : Profile
        {
            public BusinessMappingProfile()
            {
                CreateMap<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result, PinjamanLuarNegeri>()
                    .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                    .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                    .ForMember(dest => dest.NamaProyek, map => map.MapFrom(src => src.NAME))
                    .ForMember(dest => dest.NilaiPaguPLN, map => map.MapFrom(src => src.pagu_all))
                    .ForMember(dest => dest.NilaiPaguRMP, map => map.MapFrom(src => src.PAGU_RMP))
                    .ForMember(dest => dest.NilaiRealisasiPLN, map => map.MapFrom(src => src.RPHREAL))
                    .ForMember(dest => dest.NilaiRealisasiRMP, map => map.MapFrom(src => src.REAL_RMP));
                CreateMap<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result, Hibah>()
                    .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                    .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                    .ForMember(dest => dest.NamaProyek, map => map.MapFrom(src => src.NAME))
                    .ForMember(dest => dest.PaguDIPA, map => map.MapFrom(src => src.pagu_all))
                    .ForMember(dest => dest.Realisasi, map => map.MapFrom(src => src.RPHREAL));
                CreateMap<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result, PinjamanDalamNegeri>()
                    .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                    .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                    .ForMember(dest => dest.NamaProyek, map => map.MapFrom(src => src.NAME))
                    .ForMember(dest => dest.PaguDIPA, map => map.MapFrom(src => src.pagu_all))
                    .ForMember(dest => dest.Realisasi, map => map.MapFrom(src => src.RPHREAL));
                CreateMap<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result, PinjamanLuarNegeriPipeline>()
                    .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                    .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                    .ForMember(dest => dest.PaguPLN, map => map.MapFrom(src => src.pagu_all))
                    .ForMember(dest => dest.RMPPLN, map => map.MapFrom(src => src.PAGU_RMP));
                CreateMap<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result, HibahPipeline>()
                   .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                   .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                   .ForMember(dest => dest.PaguDIPA, map => map.MapFrom(src => src.pagu_all))
                   .ForMember(dest => dest.Realisasi, map => map.MapFrom(src => src.PAGU_RMP));
                CreateMap<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result, PinjamanDalamNegeriPipeline>()
                   .ForMember(dest => dest.Kementerian, map => map.MapFrom(src => src.NMDEPT))
                   .ForMember(dest => dest.Register, map => map.MapFrom(src => src.REG_ALL))
                   .ForMember(dest => dest.PaguDIPA, map => map.MapFrom(src => src.pagu_all))
                   .ForMember(dest => dest.Realisasi, map => map.MapFrom(src => src.PAGU_RMP));
            }
        }
    }
}