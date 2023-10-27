using Hotel.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Utilities
{
    public class ImageOperation
    {
        private IWebHostEnvironment _webHostEnvironment;
        public ImageOperation(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadImage(RoomViewModel vm)
        {
            string filename = null;
            if (vm.RoomPictureFile != null && vm.RoomPictureFile.Length > 0)
            {
                string UploadFile = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid().ToString() + "_"+ vm.RoomPictureFile.FileName;
                string filePath = Path.Combine(UploadFile, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    vm.RoomPictureFile.CopyToAsync(stream);
                }

            }
            return filename;
        }

       
    }
}
