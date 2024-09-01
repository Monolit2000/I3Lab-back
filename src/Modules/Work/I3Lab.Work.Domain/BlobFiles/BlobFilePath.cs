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
        public string Value { get; }

        private BlobFilePath(string value)
        => Value = value;

        public static BlobFilePath Create(string value)
        {
            return new BlobFilePath(value);
        }
    }
}
