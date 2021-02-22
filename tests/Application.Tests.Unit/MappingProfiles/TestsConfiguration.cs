using AutoMapper;
using System;
using System.Runtime.Serialization;

namespace Eliboo.Application.Tests.Unit.MappingProfiles
{
    internal static class TestsConfiguration
    {
        public static IMapper CreateMapper(Profile MappingProfile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(MappingProfile);
            });
            return mappingConfig.CreateMapper();
        }

        public static void ShouldSupportMapping(Type source, Type destination, IMapper mapper)
        {
            try
            {
                var instance = GetInstanceOf(source);
                mapper.Map(instance, source, destination);
            }
            catch
            {
                throw;
            }
        }

        private static object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
