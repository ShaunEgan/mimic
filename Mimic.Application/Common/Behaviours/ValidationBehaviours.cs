using FluentValidation;
using MediatR;

namespace Mimic.Application.Common.Behaviours;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = _validator.Validate(request);

        if (validationResult.IsValid)
        {
            return await next();
        }

        if (validationResult.Errors.Any())
        {
            throw new ValidationException(validationResult.Errors);
        }

        return await next();
    }
}
