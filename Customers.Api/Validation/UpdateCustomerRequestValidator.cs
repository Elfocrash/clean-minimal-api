using Customers.Api.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace Customers.Api.Validation;

public class UpdateCustomerRequestValidator : Validator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}
