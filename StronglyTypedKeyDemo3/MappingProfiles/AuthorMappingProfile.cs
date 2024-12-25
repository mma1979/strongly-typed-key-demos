using AutoMapper;

using StronglyTypedKeyDemo3.Entities;
using StronglyTypedKeyDemo3.Models;

namespace StronglyTypedKeyDemo3.MappingProfiles;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<Author, AuthorReadModel>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
          .IgnoreAllPropertiesWithAnInaccessibleSetter()
          .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

        CreateMap<Author, AuthorModifyModel>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
          .IgnoreAllPropertiesWithAnInaccessibleSetter()
          .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();



        


    }
}