using CustomerAdditionalInfoApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIICWwIBAAKBgHZO8IQouqjDyY47ZDGdw9jP"))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/customerAdditionalInfos/{customerId}", async (string customerId) =>
{
    var customerAdditionalInfo = GetCustomerAdditionalInfos().FirstOrDefault(a => a.CustomerId == customerId);

    return customerAdditionalInfo is CustomerAdditionalInfo info ? Results.Ok(info) : Results.NotFound();
}).RequireAuthorization();

List<CustomerAdditionalInfo> GetCustomerAdditionalInfos()
{
    return new List<CustomerAdditionalInfo>
        {
            new CustomerAdditionalInfo
            {
                Id = "6FE892BB",
                CustomerId = "35A51B05",
                Address = "200 John Wesley Blvd, Bossier City, Louisiana, USA",
                PhoneNumber = "555-1234"
            },
            new CustomerAdditionalInfo
            {
                Id = "189DF59F",
                CustomerId = "4D8AD7B2",
                Address = "103100 Overseas Hwy, Key Florida, USA",
                PhoneNumber = "555-5678"
            },
            new CustomerAdditionalInfo
            {
                Id = "A9374B16",
                CustomerId = "23D4FCC2",
                Address = "6175 Brandt Pike, Huber Heights, Ohio, USA",
                PhoneNumber = "555-8765"
            }
        };
}

app.Run();
