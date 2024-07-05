using CustomerApi.Repositories.Repositories;
using Refit;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddRefitClient<ICustomerAdditionalInfoApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5080"));

var app = builder.Build();

app.MapGet("/customers/additionalInfo/{id}", async (string id, ICustomerAdditionalInfoApi additionalInfoApi) =>
{
    try
    {
        var additionalInfo = await additionalInfoApi.GetCustomerAdditionalInfo(id);

        return Results.Ok(additionalInfo);
    }
    catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
    {
        return Results.NotFound($"Additional information not found for the customer id: {id}");
    }
});

app.Run();
