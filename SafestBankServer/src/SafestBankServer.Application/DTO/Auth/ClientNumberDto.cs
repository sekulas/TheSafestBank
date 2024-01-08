﻿using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.DTO.Auth;

public class ClientNumberDto
{
    //TODO - zmien odpowiednio ilosc znakow
    [RegularExpression(@"^[0-9]{1}")]
    public string ClientNumber { get; set; }
}
