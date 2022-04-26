using Customers.Api.Contracts.Responses;
using Customers.Api.Mapping;
using Customers.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Customers.Api.Endpoints;

[HttpGet("customers"), AllowAnonymous]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<GetAllCustomersResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var customers = await _customerService.GetAllAsync();
        var customersResponse = customers.ToCustomersResponse();
        await SendOkAsync(customersResponse, ct);
    }
}
