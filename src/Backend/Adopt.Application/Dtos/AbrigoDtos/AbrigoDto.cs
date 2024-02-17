﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.AbrigoDtos;

public class AbrigoDto
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
    [Required]
    public string State { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]

    public string PhoneNumber { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Required]
    [Compare("Password")]
    public string Repassword { get; set; } = null!;
    [Required]
    public string CNPJ { get; set; } = null!;
}
