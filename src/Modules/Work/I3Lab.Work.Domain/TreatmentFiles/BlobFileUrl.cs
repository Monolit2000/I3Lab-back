using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentFiles
{
    public class BlobFileUrl
    {
        public string Value { get; }

        private BlobFileUrl(string value)
        => Value = value;

        public static BlobFileUrl Create(string value)
            => new BlobFileUrl(value);
    }
}
