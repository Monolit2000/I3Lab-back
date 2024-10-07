using FluentResults;

namespace I3Lab.Treatments.Application.Configuration.Errors
{
    public static class StatusCodeErrors
    {
        public static IError Unauthorized => new Error("Unauthorized")
            .WithMetadata("StatusCode", 401);

        public static IError Forbidden => new Error("Forbidden")
            .WithMetadata("StatusCode", 403);

        public static IError InternalServerError => new Error("InternalServerError")
            .WithMetadata("StatusCode", 500);

        public static IError BadRequest(string message = "BadRequest") => new Error(message)
          .WithMetadata("StatusCode", 400);

        public static IError NotUnique(string message) => new Error(message)
            .WithMetadata("StatusCode", 409);
        public static IError ResourceNotFound(string message = "ResourceNotFound") => new Error(message)
         .WithMetadata("StatusCode", 404);

    }
}
