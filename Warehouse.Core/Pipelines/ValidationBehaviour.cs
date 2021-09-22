using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Requests;

namespace Warehouse.Core.Pipelines
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList().Select(x => new KeyValuePair<string, string>(x.PropertyName, x.ErrorMessage)).ToList();

                if (validationResults.Any(x => !x.IsValid))
                {
                    return new TResponse {
                        ResponseCode = ResponseCode.ValidationFailed,
                        Errors = failures
                    };
                }                
            }
            return await next();
        }
    }
}
