using AutoMapper;
using Eliboo.Api.Contracts.Requests;
using Eliboo.Application.MappingProfiles;
using Eliboo.Domain.Entities;
using System;
using Xunit;

namespace Eliboo.Application.Tests.Unit.MappingProfiles
{
    public class RequestToEntityMappingProfileTests
    {
        private static IMapper _mapper;

        public RequestToEntityMappingProfileTests()
        {
            if (_mapper == null)
            {
                _mapper = TestsConfiguration.CreateMapper(new RequestToEntityMappingProfile());
            }
        }

        [Theory]
        [InlineData(typeof(BookRequest), typeof(Book))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            TestsConfiguration.ShouldSupportMapping(source, destination, _mapper);
        }

        [Fact]
        public void BooksRequestToBooks_ShouldMapValuesProperly()
        {
            // Arrange
            var bookRequest = new BookRequest
            {
                Title = "Super Title",
                Author = "Super Author",
                Genre = "Super Genre",
                Bookshelf = "Super Description"
            };

            // Act
            var result = _mapper.Map<Book>(bookRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookRequest.Title, result.Title);
            Assert.Equal(bookRequest.Author, result.Author);
            Assert.Equal(bookRequest.Genre, result.Genre);
            Assert.Equal(bookRequest.Bookshelf, result.Bookshelf.Description);
        }
    }
}
