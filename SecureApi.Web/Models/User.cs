﻿namespace SecureApi.Web.Models;

public class User
{
    public Guid Id { get; init; }
    public required string UserName { get; init; }
    public EmailAddress Email { get; set; }
    public EmailAddress? RecoveryEmail { get; set; }
    public Password Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
