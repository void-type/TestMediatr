using AutoMapper;
using MediatrRailwayExample.Models.CoreModel;
using MediatrRailwayExample.Models.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrRailwayExample.Models
{
    public class GetLoanee
    {
        public class Handler : IRequestHandler<Request, Response>
        {
            public Handler(LoaneeData data, IMapper mapper)
            {
                _data = data;
                _mapper = mapper;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var loanee = await Task.FromResult(_data.Loanees
                    .Where(l => l.Name == request.Name)
                    .FirstOrDefault());

                if (loanee == null)
                {
                    var failure = new Response();
                    failure.AddFailure("Loanee not found.");
                    return failure;
                }

                var succcess = new Response
                {
                    Success = _mapper.Map<Loanee, LoaneeDto>(loanee)
                };
                return succcess;
            }

            private readonly LoaneeData _data;
            private readonly IMapper _mapper;
        }
        public class Request : IRequest<Response>
        {
            public string Name { get; set; }
        }

        public class Response : ActionResponse<LoaneeDto> { }

        public class LoaneeDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class RequestValidator : IValidator<Request>
        {
            public IEnumerable<IValidationError> Validate(Request validatable)
            {
                if (string.IsNullOrEmpty(validatable.Name))
                {
                    return new List<IValidationError>()
                    {
                        new ValidationError { ErrorMessage = "Name is required.", FieldName = "nameField" }
                    };
                }
                return new List<ValidationError>();
            }
        }

        public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : ActionResponse<LoaneeDto>
        {
            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                var response = await next();

                if (!response.Failure.Any())
                {
                    Console.WriteLine("Dto Logged Success: " + response.Success.Email);
                }
                return response;
            }
        }
    }
}
