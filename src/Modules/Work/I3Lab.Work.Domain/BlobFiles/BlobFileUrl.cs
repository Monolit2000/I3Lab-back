//using FluentResults;
//using System.Text.RegularExpressions;

//namespace I3Lab.Treatments.Domain.BlobFiles
//{
//    public class BlobFileUrl
//    {
//        private static readonly Regex UrlPattern = new Regex(
//            @"^https?:\/\/[^\s/$.?#].[^\s]*$", 
//            RegexOptions.Compiled | RegexOptions.IgnoreCase
//        );

//        public string Value { get; }

//        private BlobFileUrl(string value)
//        {
//            Value = value;
//        }

//        public static Result<BlobFileUrl> Create(string value)
//        {
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return Result.Fail<BlobFileUrl>("URL cannot be empty.");
//            }

//            if (!UrlPattern.IsMatch(value))
//            {
//                return Result.Fail<BlobFileUrl>("Invalid URL format.");
//            }

//            return Result.Ok(new BlobFileUrl(value));
//        }

//        public Result Validate()
//        {
//            if (string.IsNullOrWhiteSpace(Value))
//            {
//                return Result.Fail("URL cannot be empty.");
//            }

//            if (!UrlPattern.IsMatch(Value))
//            {
//                return Result.Fail("Invalid URL format.");
//            }

//            return Result.Ok();
//        }
//    }
//}





namespace I3Lab.Treatments.Domain.BlobFiles
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
