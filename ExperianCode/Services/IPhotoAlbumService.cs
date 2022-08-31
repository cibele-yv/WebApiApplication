using ExperianCode.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperianCode.Services
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<dynamic>> CombinedCollection();
        Task<IEnumerable<dynamic>> CollectionByUserId(int userId);
    }
}
