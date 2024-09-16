using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.BlobFiles
{
    public class BlobFilePath : ValueObject
    {
        public string ContainerName { get; private set; }

        // FileName it's a BlobFileId value
        public string FileName { get; private set; }
        public string BlobDirectoryName { get; private set; }

        private BlobFilePath(
            string containerName,
            string blobDirectoryName,
            string fileName)
        {
            ContainerName = containerName;
            FileName = fileName;
            BlobDirectoryName = blobDirectoryName;
        }

        public static BlobFilePath Create(string containerName, string fileName, string blobDirectoryName = default)
        {
            return new BlobFilePath(containerName, fileName, blobDirectoryName);
        }
    }
}
