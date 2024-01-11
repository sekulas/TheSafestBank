using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Auth.DTO;

public class ClientLoginDto
{
    //TODO - zmien odpowiednio ilosc znakow
    [RegularExpression(@"^[0-9]{1}")]
    public string ClientNumber { get; set; }

    //TODO - 12 to 128 character password requiring at least 3 out 4 (uppercase and lowercase letters, numbers and special characters) and no more than 2 equal characters in a row
    //[RegularExpression(@"^(?:(?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))(?!.*(.)\1{2,})[A-Za-z0-9!~<>,;:_=?*+#.""&§%°()\|\[\]\-\$\^\@\/]{12,128}$")]
    public string Password { get; set; }
}
