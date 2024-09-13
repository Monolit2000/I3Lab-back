using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace I3Lab.BuildingBlocks.Infrastructure.Serialization
{
    public class AllPropertiesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = type.GetProperties(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance)
                .Select(p => this.CreateProperty(p, memberSerialization))
                .ToList();

            properties.ForEach(p =>
            {
                p.Writable = true;
                p.Readable = true;
            });

            return properties;
        }
    }
}
