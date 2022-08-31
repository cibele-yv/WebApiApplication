using ExperianCode.Controllers;
using ExperianCode.Models;
using ExperianCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ExperianCode.Tests
{
    public class ControllerTests
    {
        private readonly Mock<ILogger<PhotoAlbumController>> _logger;
        private readonly Mock<IPhotoAlbumService> _photoAlbums;
        private readonly PhotoAlbumController _controller;

        public ControllerTests()
        {
            _logger = new Mock<ILogger<PhotoAlbumController>>();
            _photoAlbums = new Mock<IPhotoAlbumService>();
            _controller = new PhotoAlbumController(_logger.Object, _photoAlbums.Object);
        }
        [Fact]
        public async void GetCombinedCollection_ShouldReturnListofPhotoAlbums()
        {
            var photoAlbumsList = CreatePhotoAlbumList();
            _photoAlbums.Setup(p => p.CombinedCollection()).ReturnsAsync(photoAlbumsList);

            var result = await _controller.Get();
            Assert.NotNull(result);
            Assert.IsType<List<PhotoAlbum>>(result);
        }
        [Fact]
        public async void GetCombinedCollection_ShouldReturnNull()
        {
            _photoAlbums.Setup(p => p.CombinedCollection()).ReturnsAsync((List<PhotoAlbum>)null);

            var result = await _controller.Get();
            Assert.Null(result);
        }
        [Fact]
        public async void GetCombinedCollection_ShouldBeCalledOnlyOnce()
        {
            _photoAlbums.Setup(p => p.CombinedCollection()).ReturnsAsync((List<PhotoAlbum>)null);

            var result = await _controller.Get();
            _photoAlbums.Verify(mock => mock.CombinedCollection(), Times.Once);
        }
        [Fact]
        public async void GetById_ShouldReturnListofPhotoAlbums()
        {
            var photoAlbumsList = CreatePhotoAlbumList();
            _photoAlbums.Setup(p => p.CollectionByUserId(22)).ReturnsAsync(photoAlbumsList);

            var result = await _controller.GetAlbumById(22);
            Assert.NotNull(result);
            Assert.IsType<List<PhotoAlbum>>(result);
        }
        [Fact]
        public async void GetById_ShouldReturnNull()
        {
            _photoAlbums.Setup(p => p.CollectionByUserId(8)).ReturnsAsync((List<PhotoAlbum>)null);

            var result = await _controller.GetAlbumById(8);
            Assert.Null(result);
        }
        [Fact]
        public async void GetById_ShouldBeCalledOnlyOnce()
        {
            _photoAlbums.Setup(p => p.CollectionByUserId(1)).ReturnsAsync((List<PhotoAlbum>)null);

            var result = await _controller.GetAlbumById(1);
            _photoAlbums.Verify(mock => mock.CollectionByUserId(1), Times.Once);
        }

        private IEnumerable<PhotoAlbum> CreatePhotoAlbumList()
        {
            return new List<PhotoAlbum>()
            {
                new PhotoAlbum()
                {
                    PhotoId = 1,
                    PhotoTitle = "Test1",
                    AlbumId = 11,
                    UserId = 21
                },
                new PhotoAlbum()
                {
                    PhotoId = 2,
                    PhotoTitle = "Test2",
                    AlbumId = 12,
                    UserId = 22
                },
                new PhotoAlbum()
                {
                    PhotoId = 3,
                    PhotoTitle = "Test3",
                    AlbumId = 13,
                    UserId = 8
                }
            };
        }
    }
}