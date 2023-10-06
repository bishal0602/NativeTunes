using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence
{
    public class FileUploadInfo
    {

        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsFailure { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public FileUploadInfo(string name, string url)
        {
            Name = name;
            Url = url;
            IsFailure = false;
        }
        private FileUploadInfo(string errorMessage)
        {
            IsFailure = true;
            ErrorMessage = errorMessage;
        }
        public static FileUploadInfo Failed(string errorMessage) => new(errorMessage);
    }
}
