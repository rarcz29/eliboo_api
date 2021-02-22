using AutoMapper;

namespace Eliboo.Application.MappingProfiles
{
    class RequestToEntityMappingProfile : Profile
    {
        public EntityToResponseMappingProfile()
        {
            CreateMap<BookRequest, BookResponse>()
                .ForMember(d => d.Bookshelf, o => o.MapFrom(src => src.Bookshelf.Description));
        }
    }
}
