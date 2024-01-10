using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Services;
using Hotel.Utilities;
using Hotel.ViewModels;
using Hotel.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Hotel.Tests
{
    public class RoomControllerTests
    {

        [Fact]
        public async Task Edit_Post_ShouldUpdateRoomAndRedirectToIndex()
        {

            var mockRoomService = new Mock<IRoomService>();
            var mockHotelInfoService = new Mock<IHotelInfo>();
            var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            var controller = new RoomController(
                mockRoomService.Object,
                mockHotelInfoService.Object,
                mockWebHostEnvironment.Object
            );

            var roomViewModel = new RoomViewModel
            {
                Id = 1, 
                RoomNumber = 102,
                RoomPrice = 200,
                Type = "Deluxe",
                StatusR = StatusR.Available,
                Description = "Spacious room with a city view",
                WIFI = true,
                AC = true,
                Bathroom = true,
                HotelInfoId = 2, 
            };


            var result = controller.Edit(roomViewModel) as RedirectToActionResult;


            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

           
            mockRoomService.Verify(service => service.UpdateRoom(It.IsAny<RoomViewModel>()), Times.Once);
        }


        [Fact]
        public async Task Create_Post_ShouldInsertRoomAndRedirectToIndex()
        {
            // Arrange
            var mockRoomService = new Mock<IRoomService>();
            var mockHotelInfoService = new Mock<IHotelInfo>();
            var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            var controller = new RoomController(
                mockRoomService.Object,
                mockHotelInfoService.Object,
                mockWebHostEnvironment.Object
            );

            var roomViewModel = new RoomViewModel
            {
                RoomNumber = 101,
                RoomPrice = 150,
                Type = "Standard",
                StatusR = StatusR.Available,
                Description = "A cozy room with a view",
                PictureURL = "example.jpg",
                WIFI = true,
                AC = true,
                Bathroom = true,
                HotelInfoId = 1, 
                RoomPictureFile = new Mock<IFormFile>().Object 
            };

            var result =  controller.Create(roomViewModel) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            mockRoomService.Verify(service => service.InsertRoom(It.IsAny<RoomViewModel>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldDeleteRoomAndRedirectToIndex()
        {
            var mockRoomService = new Mock<IRoomService>();
            var mockHotelInfoService = new Mock<IHotelInfo>();
            var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            var controller = new RoomController(
                mockRoomService.Object,
                mockHotelInfoService.Object,
                mockWebHostEnvironment.Object
            );

            int roomIdToDelete = 1; 

            var result = controller.Delete(roomIdToDelete) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            mockRoomService.Verify(service => service.DeleteRoom(roomIdToDelete), Times.Once);
        }
    }
}
