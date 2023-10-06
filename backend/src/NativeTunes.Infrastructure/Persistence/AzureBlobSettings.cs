using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Persistence
{
    public class AzureBlobSettings
    {
        public const string SectionName = "AzureBlobService";
        public string StorageAccount { get; set; } = null!;
        public string Key { get; set; } = null!;
    }
}
