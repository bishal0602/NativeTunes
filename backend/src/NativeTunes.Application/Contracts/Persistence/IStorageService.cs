using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence
{
    public interface IStorageService
    {
        Task<bool> DeleteAsync(string fileUrl);
        Task<FileUploadInfo> UploadFileAsync(string folder, IFormFile file);
    }
}
