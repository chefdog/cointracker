using CryptoTracker.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.Services.FileService
{
    public class FileBusinessService
    {
        private string _fileLocation;
        public FileBusinessService(string fileLocation) {
            _fileLocation = fileLocation;
        }

        public void Create(FileTypeEnum fileType) {

        }
    }
}
