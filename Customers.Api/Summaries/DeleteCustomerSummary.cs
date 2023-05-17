using Customers.Api.Endpoints;
using FastEndpoints;

namespace Customers.Api.Summaries;

public class DeleteCustomerSummary : Summary<DeleteCustomerEndpoint>
{
    public DeleteCustomerSummary()
    {
        Summary = "Deletes a customer from the system";
        Description = "Deletes a customer from the system";
        Response(204, "The customer was deleted successfully");
        Response(404, "The customer was not found in the system");
    }
}
