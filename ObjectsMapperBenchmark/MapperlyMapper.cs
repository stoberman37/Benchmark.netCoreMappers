using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark
{
    [Mapper]
    public partial class MapperlyMapper
    {
        public partial SpotifyAlbum Map(SpotifyAlbumDto spotifyAlbumDto);
    }
}