using Customers.Api.Contracts.Data;
using Customers.Api.Database;
using Dapper;

namespace Customers.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CustomerRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(CustomerDto customer)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Customers (Id, Username, FullName, Email, DateOfBirth) 
            VALUES (@Id, @Username, @FullName, @Email, @DateOfBirth)",
            customer);
        return result > 0;
    }

    public async Task<CustomerDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<CustomerDto>(
            "SELECT * FROM Customers WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<CustomerDto>("SELECT * FROM Customers");
    }

    public async Task<bool> UpdateAsync(CustomerDto customer)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Customers SET Username = @Username, FullName = @FullName, Email = @Email, 
                 DateOfBirth = @DateOfBirth WHERE Id = @Id",
            customer);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Customers WHERE Id = @Id",
            new {Id = id.ToString()});
        return result > 0;
    }
}
