using AutoMapper;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Application.MappingProfiles;
using Eliboo.Domain.Entities;
using System;
using Xunit;

namespace Eliboo.Application.Tests.Unit.MappingProfiles
{
    public class EntityToResponseMappingProfileTests
    {
        private static IMapper _mapper;

        public EntityToResponseMappingProfileTests()
        {
            if (_mapper == null)
            {
                _mapper = TestsConfiguration.CreateMapper(new EntityToResponseMappingProfile());
            }
        }

        [Theory]
        [InlineData(typeof(Book), typeof(BookResponse))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            TestsConfiguration.ShouldSupportMapping(source, destination, _mapper);
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
    }
}
