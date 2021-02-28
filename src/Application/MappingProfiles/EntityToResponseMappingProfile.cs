using AutoMapper;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Domain.Entities;

namespace Eliboo.Application.MappingProfiles
{
    public class EntityToResponseMappingProfile : Profile
    {
        public EntityToResponseMappingProfile()
        {
            CreateMap<Book, BookResponse>()
                .ForMember(d => d.Bookshelf, o => o.MapFrom(src => src.Bookshelf.Description))
                .ForMember(d => d.BookshelfId, o => o.MapFrom(src => src.Bookshelf.Id));
        }
    }
}
