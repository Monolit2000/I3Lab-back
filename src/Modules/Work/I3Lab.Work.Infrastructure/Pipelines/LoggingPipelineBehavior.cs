
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Treatments.Infrastructure.Pipelines
{
    public class LoggingPipelineBehavior<TRequest, TResponse>(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger)
       : IPipelineBehavior<TRequest, TResponse>
       where TRequest : class
       where TResponse : ResultBase
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Starting request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            var result = await next();

            if (result.IsFailed)
            {
                _logger.LogWarning(
                    "Result Failed {@RequestName}, {@Error}  {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    result.Reasons,
                    DateTime.UtcNow);
            }

            _logger.LogInformation(
              "Completed request {@RequestName}, {@DateTimeUtc}",
              typeof(TRequest).Name,
              DateTime.UtcNow);

            return result;
        }
    }
}
