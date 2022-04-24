using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace Customers.Api.Domain.Common;

public class Username : ValueOf<string, Username>
{
    private static readonly Regex UsernameRegex =
        new("^[a-z\\d](?:[a-z\\d]|-(?=[a-z\\d])){0,38}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!UsernameRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid username";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Username), message)
            });
        }
    }
}
