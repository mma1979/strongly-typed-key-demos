using AutoMapper;

using StronglyTypedKeyDemo2.Models;

namespace StronglyTypedKeyDemo2;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, AuthorModel>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
          .IgnoreAllPropertiesWithAnInaccessibleSetter()
          .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

        CreateMap<AuthorModel, Author>()
          //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => AuthorId.New(src.Id!.Value)))
          .IgnoreAllPropertiesWithAnInaccessibleSetter()
          .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

        CreateMap<Book, BookModel>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value))
           .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId!.Value))
           .IgnoreAllPropertiesWithAnInaccessibleSetter()
           .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

        CreateMap<BookModel, Book>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => BookId.New(src.Id!.Value)))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => AuthorId.New(src.AuthorId!.Value)))
            .IgnoreAllPropertiesWithAnInaccessibleSetter()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
    }
}
