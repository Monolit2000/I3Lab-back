using MediatR;


namespace I3Lab.Modules.BlobFailes.Api
{
    public interface IBlobFailesApi
    {
        Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request);

        Task ExecuteRequestAsync(IRequest request);

        //Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query);
    }
}
