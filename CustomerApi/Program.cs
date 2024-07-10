using CustomerApi.Repositories;
using CustomerApi.Repositories.Interfaces;
using Refit;
using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthTokenProvider, AuthTokenProvider>();

builder.Services
    .AddRefitClient<ICustomerAdditionalInfoApi>()
    .ConfigureHttpClient((serviceProvider, c) =>
    {
        var tokenProvider = serviceProvider.GetRequiredService<IAuthTokenProvider>();
        var token = tokenProvider.GetToken();

        c.BaseAddress = new Uri("http://localhost:5080");
        c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    });

var app = builder.Build();

app.MapGet("/customers/additionalInfo/{id}", async (string id, ICustomerAdditionalInfoApi additionalInfoApi) =>
{
    try
    {
        var additionalInfo = await additionalInfoApi.GetCustomerAdditionalInfo(id);

        return Results.Ok(additionalInfo);
    }
    catch (ApiException ex) 
    when (ex.StatusCode == HttpStatusCode.NotFound)
    {
        return Results.NotFound($"Additional information not found for the customer id: {id}");
    }
    catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
    {
        return Results.Unauthorized();
    }
});

app.Run();
