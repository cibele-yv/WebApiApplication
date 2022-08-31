using ExperianCode.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperianCode.API
{
    public interface IAlbums
    {
        Task<IEnumerable<Album>> Get();
    }
}
