using AutoMapper;
using Xunit;
using Eliboo.Application.MappingProfiles;
using Eliboo.Domain.Entities;
using Eliboo.Api.Contracts.Responses;
using System;
using System.Runtime.Serialization;

namespace Eliboo.Application.Tests.Unit.MappingProfiles
{
    public class EntityToResponseMappingProfileTests
    {
        private static IMapper _mapper;

        public EntityToResponseMappingProfileTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EntityToResponseMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Theory]
        [InlineData(typeof(Book), typeof(BookResponse))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);
            _mapper.Map(instance, source, destination);
        }

        [Fact]
        public void BooksToBooksResponse_ShouldMapValuesProperly()
        {
            // Arrange
            var book = new Book
            {
                Id = 4,
                Title = "Super Title",
                Author = "Super Author",
                Genre = "Super Genre",
                Bookshelf = new Bookshelf { Description = "Super Description" }
            };

            // Act
            var response = _mapper.Map<BookResponse>(book);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(book.Id, response.Id);
            Assert.Equal(book.Title, response.Title);
            Assert.Equal(book.Author, response.Author);
            Assert.Equal(book.Genre, response.Genre);
            Assert.Equal(book.Bookshelf.Description, response.Bookshelf);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
