using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentFiles
{
    public class ContentType : ValueObject
    {
        public string Value { get; set; }

        public ContentType(string value)
            => Value = value;
                
        public static ContentType Create(string value)
        {
            return new ContentType(value);   
        }
    }
}
