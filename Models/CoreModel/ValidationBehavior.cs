using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrRailwayExample.Models.CoreModel
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : IFallible, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .SelectMany(validator => validator.Validate(request));

            if (failures.Any())
            {
                var response = new TResponse();
                response.Failure.AddRange(failures);
                return response;
            }
            return await next();
        }
    }
}
