using AutoMapper;

using StronglyTypedKeyDemo3.Entities;
using StronglyTypedKeyDemo3.Models;

namespace StronglyTypedKeyDemo3.MappingProfiles;

public class BookMappingProfile:Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookReadModel>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
           .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId!.Value))
           .IgnoreAllPropertiesWithAnInaccessibleSetter()
           .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();


        CreateMap<Book, BookModifyModel>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
          .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId!.Value))
          .IgnoreAllPropertiesWithAnInaccessibleSetter()
          .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
    }
}
