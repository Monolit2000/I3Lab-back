using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Modules.BlobFailes.Domain.BlobFiles
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
