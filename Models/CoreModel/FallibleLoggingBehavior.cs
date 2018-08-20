using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrRailwayExample.Models.CoreModel
{
    public class FallibleLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : IFallible
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            if (response.Failure.Any())
            {
                Console.WriteLine("ValidationErrors Logged Failures: " + response.Failure.Select(x => x.ErrorMessage).FirstOrDefault());
            }
            return response;
        }
    }
}
