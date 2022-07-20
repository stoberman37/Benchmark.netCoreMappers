﻿using System.Linq;

namespace ObjectsMapperBenchmark
{
    public static class ManuallyMapper
    {
        public static SpotifyAlbum Map(this SpotifyAlbumDto spotifyAlbumDto)
        {
            return new SpotifyAlbum()
            {
                AlbumType = spotifyAlbumDto.AlbumType,
                Artists = spotifyAlbumDto.Artists.Select(spotifyAlbumDtoArtist => new Artist()
                {
                    ExternalUrls = new ExternalUrls()
                    {
                        Spotify = spotifyAlbumDtoArtist.ExternalUrls.Spotify
                    },
                    Href = spotifyAlbumDtoArtist.Href,
                    Id = spotifyAlbumDtoArtist.Id,
                    Name = spotifyAlbumDtoArtist.Name,
                    Type = spotifyAlbumDtoArtist.Type,
                    Uri = spotifyAlbumDtoArtist.Uri
                }).ToArray(),
                AvailableMarkets = spotifyAlbumDto.AvailableMarkets,
                Copyrights = spotifyAlbumDto.Copyrights.Select(spotifyAlbumDtoCopyright => new Copyright()
                {
                    Text = spotifyAlbumDtoCopyright.Text,
                    Type = spotifyAlbumDtoCopyright.Type
                }).ToArray(),
                ExternalIds = new ExternalIds()
                {
                    Upc = spotifyAlbumDto.ExternalIds.Upc
                },
                ExternalUrls = new ExternalUrls()
                {
                    Spotify = spotifyAlbumDto.ExternalUrls.Spotify
                },
                Genres = spotifyAlbumDto.Genres,
                Href = spotifyAlbumDto.Href,
                Id = spotifyAlbumDto.Id,
                Images = spotifyAlbumDto.Images.Select(spotifyAlbumDtoImage => new Image()
                {
                    Height = spotifyAlbumDtoImage.Height,
                    Url = spotifyAlbumDtoImage.Url,
                    Width = spotifyAlbumDtoImage.Width
                }).ToArray(),
                Name = spotifyAlbumDto.Name,
                Popularity = spotifyAlbumDto.Popularity,
                ReleaseDate = spotifyAlbumDto.ReleaseDate,
                ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision,
                Tracks = new Tracks()
                {
                    Href = spotifyAlbumDto.Tracks.Href,
                    Items = spotifyAlbumDto.Tracks.Items.Select(spotifyAlbumDtoTracksItem => new Item()
                    {
                        Artists = spotifyAlbumDtoTracksItem.Artists.Select(spotifyAlbumDtoTracksItemArtist => new Artist()
                        {
                            ExternalUrls = new ExternalUrls()
                            {
                                Spotify = spotifyAlbumDtoTracksItemArtist.ExternalUrls.Spotify
                            },
                            Href = spotifyAlbumDtoTracksItemArtist.Href,
                            Id = spotifyAlbumDtoTracksItemArtist.Id,
                            Name = spotifyAlbumDtoTracksItemArtist.Name,
                            Type = spotifyAlbumDtoTracksItemArtist.Type,
                            Uri = spotifyAlbumDtoTracksItemArtist.Uri
                        }).ToArray(),
                        AvailableMarkets = spotifyAlbumDtoTracksItem.AvailableMarkets,
                        DiscNumber = spotifyAlbumDtoTracksItem.DiscNumber,
                        DurationMs = spotifyAlbumDtoTracksItem.DurationMs,
                        Explicit = spotifyAlbumDtoTracksItem.Explicit,
                        ExternalUrls = new ExternalUrls()
                        {
                            Spotify = spotifyAlbumDtoTracksItem.ExternalUrls.Spotify
                        },
                        Href = spotifyAlbumDtoTracksItem.Href,
                        Id = spotifyAlbumDtoTracksItem.Id,
                        Name = spotifyAlbumDtoTracksItem.Name,
                        PreviewUrl = spotifyAlbumDtoTracksItem.PreviewUrl,
                        TrackNumber = spotifyAlbumDtoTracksItem.TrackNumber,
                        Type = spotifyAlbumDtoTracksItem.Type,
                        Uri = spotifyAlbumDtoTracksItem.Uri
                    }).ToArray(),
                    Limit = spotifyAlbumDto.Tracks.Limit,
                    Next = spotifyAlbumDto.Tracks.Next,
                    Offset = spotifyAlbumDto.Tracks.Offset,
                    Previous = spotifyAlbumDto.Tracks.Previous,
                    Total = spotifyAlbumDto.Tracks.Total
                },
                Type = spotifyAlbumDto.Type,
                Uri = spotifyAlbumDto.Uri
            };
        }

        public static Case1.User Map(this Case1.UserModel model)
        {
	        return new Case1.User
	        {
		        Id = model.Id,
		        BirthDate = model.BirthDate,
		        Name = model.Name,
		        Score = model.Score
	        };
        }

        public static Case2.User Map(this Case2.UserModel model) => new()
		{
		        Address = model.Address.Map(),
		        BirthDate = model.BirthDate,
		        Contacts = model.Contacts.Select(c => c.Map()).ToList(),
		        Id = model.Id,
		        Name = model.Name,
		        Score = model.Score
	        };

        public static Case2.Address Map(this Case2.AddressModel model) => new()
	        {
		        Number = model.Number,
		        Street = model.Street,
		        ZipCode = model.ZipCode
	        };

        public static Case2.Contact Map(this Case2.ContactModel model) => new()
	        {
		        ContactType = model.ContactType, 
		        Description = model.Description
	        };

        public static Case3.Address Map(this Case3.AddressModel model) => new()
        {
	        Street = model.Address.Split(',')[0],
	        City = model.Address.Split(',')[1],
	        ZipCode = model.Identifier
        };

        public static Case3.Contact Map(this Case3.ContactModel model) => new()
        {
	        ContactType = (Case3.ContactType)model.ContactType,
	        Description = model.Contact
        };

        public static Case3.User Map(this Case3.UserModel model) => new()
        {
	        Name = model.Name,
	        Address = model.Location.Map(),
	        BirthDate = model.BornAt,
	        Contacts = model.ContactList.Select(c => c.Map()).ToList(),
	        Id = model.Id,
	        Score = model.Points
        };
    }
}
