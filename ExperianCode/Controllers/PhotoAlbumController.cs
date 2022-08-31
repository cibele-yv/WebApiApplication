using ExperianCode.API;
using ExperianCode.Models;
using ExperianCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumController : ControllerBase
    {   
        private readonly IPhotoAlbumService _photoAlbums;
        private readonly ILogger<PhotoAlbumController> _logger;

        public PhotoAlbumController(ILogger<PhotoAlbumController> logger,
                                    IPhotoAlbumService photoAlbums)
        {
            _logger = logger;
            _photoAlbums = photoAlbums;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            return await _photoAlbums.CombinedCollection();
            
            _logger.LogInformation("Combined Collection created succesfully.");
            //TODO - Enable app insights for troubleshooting in production and improve the logging inputs of Error and information
        }
        [HttpGet("{userId}")]
        public async Task<dynamic> GetAlbumById(int userId)
        {
            return await _photoAlbums.CollectionByUserId(userId);

            _logger.LogInformation("Collection by UserId created succesfully");

            //TODO - Enable app insights for troubleshooting in production and improve the logging inputs of Error and information
        }

    }
}
