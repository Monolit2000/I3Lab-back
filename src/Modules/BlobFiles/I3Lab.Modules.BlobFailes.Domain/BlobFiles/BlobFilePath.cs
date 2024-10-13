using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Domain.BlobFiles
{
    public class BlobFilePath : ValueObject
    {
        public string ContainerName { get; private set; }
        public string FileName { get; private set; }
        public string BlobDirectoryName { get; private set; }

        // Azure blob container name validation regex
        private static readonly Regex ContainerNamePattern = new Regex(
            @"^[a-z0-9](?!.*--)[a-z0-9-]{1,61}[a-z0-9]$",
            RegexOptions.Compiled
        );

        private BlobFilePath(
            string containerName,
            string blobDirectoryName,
            string fileName)
        {
            ContainerName = containerName;
            FileName = fileName;
            BlobDirectoryName = blobDirectoryName;
        }

        // Factory method to create BlobFilePath with validation
        public static Result<BlobFilePath> Create(string containerName, string fileName, string blobDirectoryName = "sdfdf")
        {
            var validateResult = Validate(containerName, fileName, blobDirectoryName);
            if (validateResult.IsFailed)
                return validateResult;

            return Result.Ok(new BlobFilePath(containerName, blobDirectoryName, fileName));
        }

        // Method to validate the current BlobFilePath instance
        public static Result Validate(string containerName, string fileName, string blobDirectoryName = default)
        {
            if (string.IsNullOrWhiteSpace(containerName))
                return Result.Fail("Container name cannot be empty.");

            if (!ContainerNamePattern.IsMatch(containerName))
                return Result.Fail("Invalid container name. Must follow Azure blob naming conventions.");

            if (string.IsNullOrWhiteSpace(fileName))
                return Result.Fail("File name cannot be empty.");

            if (!string.IsNullOrWhiteSpace(blobDirectoryName) && blobDirectoryName.Length > 1024)
                return Result.Fail("Blob directory name must be less than 1024 characters.");

            return Result.Ok();
        }
    }
}