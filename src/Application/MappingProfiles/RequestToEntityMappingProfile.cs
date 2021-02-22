using AutoMapper;
using Eliboo.Api.Contracts.Requests;
using Eliboo.Domain.Entities;

namespace Eliboo.Application.MappingProfiles
{
    public class RequestToEntityMappingProfile : Profile
    {
        public RequestToEntityMappingProfile()
        {
            CreateMap<BookRequest, Book>()
                .ForMember(x => x.Bookshelf, opt => opt.Ignore());
            //.ForMember(dest => dest.Bookshelf, act => act.MapFrom(src => new Bookshelf { Description = src.Bookshelf }));
        }
    }
}
