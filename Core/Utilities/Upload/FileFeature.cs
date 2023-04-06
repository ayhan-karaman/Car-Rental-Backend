using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Upload
{
    public class FileFeature
    {
        public IFormFile Files { get; set; }
        public string FolderName { get; set; }
        public ExtensionType ExtensionType { get; set; } = ExtensionType.None;
    }
}