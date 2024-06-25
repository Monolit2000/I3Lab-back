using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;


namespace I3Lab.BuildingBlocks.Infrastructure.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse>
      : IPipelineBehavior<TRequest, TResponse>
      where TRequest : class
      where TResponse : ResultBase
    {

        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

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
