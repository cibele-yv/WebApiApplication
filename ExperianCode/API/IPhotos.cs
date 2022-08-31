using ExperianCode.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperianCode.API
{
    public interface IPhotos
    {
        Task<IEnumerable<Photo>> Get();
    }
}
