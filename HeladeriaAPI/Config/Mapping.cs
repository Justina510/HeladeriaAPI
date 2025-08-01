using AutoMapper;
using HeladeriaAPI.Models.Helado;
using HeladeriaAPI.Models.Helado.Dto;
using HeladeriaAPI.Models.Envase;
using HeladeriaAPI.Models.Envase.Dto;

namespace HeladeriaAPI.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<List<string>?, List<string>>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<CreateHeladoDTO, Helado>().ReverseMap();

            CreateMap<UpdateHeladoDTO, Helado>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

 
            CreateMap<CreateEnvaseDTO, Envase>().ReverseMap();

            CreateMap<UpdateEnvaseDTO, Envase>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
        }
    }
}
