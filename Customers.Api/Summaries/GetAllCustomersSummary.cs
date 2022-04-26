using Customers.Api.Contracts.Responses;
using Customers.Api.Endpoints;
using FastEndpoints;

namespace Customers.Api.Summaries;

public class GetAllCustomersSummary : Summary<GetAllCustomersEndpoint>
{
    public GetAllCustomersSummary()
    {
        Summary = "Returns all the customers in the system";
        Description = "Returns all the customers in the system";
        Response<GetAllCustomersResponse>(200, "All customers in the system are returned");
    }
}
