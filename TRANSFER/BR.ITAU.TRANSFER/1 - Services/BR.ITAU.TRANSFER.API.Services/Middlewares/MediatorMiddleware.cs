using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BR.ITAU.TRANSFER.API.Services.Middlewares
{
    public class MediatorMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IHttpContextAccessor _httpContext;

        public MediatorMiddleware(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = next();
            return response;
        }
    }
}
