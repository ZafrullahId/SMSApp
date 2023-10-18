using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;

namespace Application.Uploads
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadPicAsync(IFormFile file)
        {
            if (file == null) { return "";  }
            var imgPath = _webHostEnvironment.WebRootPath;
                var imagePath = Path.Combine(imgPath, "Images");
                Directory.CreateDirectory(imagePath);
                var imageType = file.ContentType.Split('/')[1];
            string imageName = $"{Guid.NewGuid()}.{imageType}";
            var fullPath = Path.Combine(imagePath, imageName);
                using var fileStream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(fileStream);
            return imageName;
        }
        public static bool CheckFileExtensionAsync(IFormFile file)
        {
            if ((file != null && file.Length != 0) && (Path.GetExtension(file.FileName) == ".xlsx" || Path.GetExtension(file.FileName) == ".xml"))
            {
                return true;
            }
            return false;
        }
        public static bool FileHeadFormat(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(file.OpenReadStream());
            var worksheet = package.Workbook.Worksheets[0];
            if (worksheet.Cells[1, 2].Value.ToString() == "Class" && worksheet.Cells[1, 3].Value.ToString() == "Phone" && worksheet.Cells[1, 4].Value.ToString() == "Department")
            {
                return true;
            }
            return false;
        }
    }
}
