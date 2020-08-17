using AutoMapper;
using Moq;

namespace GhnShipping.Tests.Helpers.Mappers
{
    public class CreateMapper
    {
        private readonly MapperBuilder _builder;

        private CreateMapper()
        {
            _builder = new MapperBuilder();
        }

        public static IMapper Default => Mock.Of<IMapper>();

        public static MapperValueBuilder<TSource> WhenMap<TSource>(TSource source)
        {
            var creator = new CreateMapper();
            return creator._builder.WhenMap(source);
        }

        public sealed class MapperBuilder
        {
            private readonly Mock<IMapper> _mapperMock;

            public MapperBuilder()
            {
                _mapperMock = new Mock<IMapper>();
            }

            public MapperValueBuilder<TSource> WhenMap<TSource>(TSource source)
            {
                var valueBuilder = new MapperValueBuilder<TSource>(this, _mapperMock);
                valueBuilder.SetSource(source);

                return valueBuilder;
            }

            public Mock<IMapper> Build() => _mapperMock;
        }

        public sealed class MapperValueBuilder<TSource>
        {
            private readonly MapperBuilder _builder;
            private readonly Mock<IMapper> _mock;
            private TSource _source;

            public MapperValueBuilder(MapperBuilder builder, Mock<IMapper> mock)
            {
                _builder = builder;
                _mock = mock;
            }

            public MapperValueBuilder<TSource> SetSource(TSource source)
            {
                _source = source;
                return this;
            }

            public MapperBuilder Return<TDes>(TDes des)
            {
                _mock.Setup(mapper => mapper.Map<TDes>(_source))
                    .Returns(des)
                    .Verifiable();

                return _builder;
            }
        }
    }
}
