using System.Collections.Generic;
using System.Linq;
using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark
{
	[Mapper]
	public partial class MapperlyMapper
	{
		public partial SpotifyAlbum Map(SpotifyAlbumDto spotifyAlbumDto);
	}

	[Mapper(UseDeepCloning = true)]
	public partial class Case1UserModelMapper
	{
		public partial Case1.User Map(Case1.UserModel userModel);
		public partial Case1.User[] MapArray(IEnumerable<Case1.UserModel> models);
		public partial List<Case1.User> MapList(IEnumerable<Case1.UserModel> models);
	}

	[Mapper(UseDeepCloning = true)]
	public partial class Case2UserModelMapper
	{
		public partial Case2.User Map(Case2.UserModel userModel);
		public partial Case2.User[] MapArray(IEnumerable<Case2.UserModel> models);
		public partial List<Case2.User> MapList(IEnumerable<Case2.UserModel> models);

		public partial Case2.Address Map(Case2.AddressModel addressModel);
		public partial Case2.Contact Map(Case2.ContactModel contactModel);

		public IList<Case2.Contact> MapList(List<Case2.ContactModel> models)
		{
			return models.Select(m => m.Map()).ToList();
		}
	}

}