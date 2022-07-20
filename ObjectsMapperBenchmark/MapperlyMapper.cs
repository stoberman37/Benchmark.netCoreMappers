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

	[Mapper(UseDeepCloning = true)]
	public partial class Case3UserModelMapper
	{
		public Case3.User Map(Case3.UserModel userModel)
		{
			return new Case3.User()
			{
				Address = Map(userModel.Location),
				BirthDate = userModel.BornAt,
				Contacts = MapList(userModel.ContactList),
				Id = userModel.Id,
				Name = userModel.Name,
				Score = userModel.Points
			};
		}

		public partial Case3.User[] MapArray(IEnumerable<Case3.UserModel> models);
		public partial List<Case3.User> MapList(IEnumerable<Case3.UserModel> models);

		public Case3.Address Map(Case3.AddressModel addressModel)
		{
			return new Case3.Address
			{
				ZipCode = addressModel.Identifier,
				Street = addressModel.Address.Split(',')[0],
				City = addressModel.Address.Split(',')[1]
			};
		}

		public Case3.Contact Map(Case3.ContactModel contactModel)
		{
			return new Case3.Contact((Case3.ContactType)contactModel.ContactType, contactModel.Contact);
		}

		public IList<Case3.Contact> MapList(List<Case3.ContactModel> models)
		{
			return models.Select(m => m.Map()).ToList();
		}
	}
}