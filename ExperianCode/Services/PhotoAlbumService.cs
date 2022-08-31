using ExperianCode.API;
using ExperianCode.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianCode.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IPhotos _photos;
        private readonly IAlbums _albums;
        public PhotoAlbumService(IPhotos photos, IAlbums albums)
        {
            _photos = photos;
            _albums = albums;
        }
        public async Task<IEnumerable<dynamic>> CombinedCollection()
        {
            IEnumerable<Photo> photos = await _photos.Get();

            IEnumerable<Album> albums = await _albums.Get();
            var albumPhotos = photos.Join(
                                albums, photo => photo.AlbumId,
                                album => album.Id,
                                (photo, album) => new PhotoAlbum()
                                {
                                    PhotoId = photo.Id,
                                    PhotoTitle = photo.Title,
                                    PhotoUrl = photo.Url,
                                    PhotoThumbnailUrl = photo.ThumbnailUrl,
                                    AlbumId = photo.AlbumId,
                                    AlbumTitle = album.Title,
                                    UserId = album.UserId
                                });

            return albumPhotos;
        }
        public async Task<IEnumerable<dynamic>> CollectionByUserId(int userId)
        {
            var photoAlbums = await CombinedCollection();
            var photoAlbumsByUserId = photoAlbums.Where(p => p.UserId == userId);
            return photoAlbumsByUserId;
        }

    }
}
