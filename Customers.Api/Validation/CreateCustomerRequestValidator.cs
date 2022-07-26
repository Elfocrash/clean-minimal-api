﻿using Customers.Api.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace Customers.Api.Validation;

public class CreateCustomerRequestValidator : Validator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}
