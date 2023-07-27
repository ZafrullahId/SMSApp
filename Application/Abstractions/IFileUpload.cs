using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IFileUpload
    {
        Task<string> UploadPicAsync(IFormFile file);
    }
}