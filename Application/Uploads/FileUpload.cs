using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
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
    }
}
