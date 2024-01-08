using SecureApi.Web.Services.Cryptography;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.Configure<PasswordManagerHmacsha512Options>(options =>
{
    options.SaltSize = 32;

    // TODO: Replace this with a secure secret from a secret store.
    options.Secret = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
});

builder.Services.AddSingleton<IPasswordManager, PasswordManagerHmacsha512>();
builder.Services.AddSingleton<IPasswordManageFactory, PasswordManagerFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();