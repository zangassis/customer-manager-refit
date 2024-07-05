using CustomerAdditionalInfoApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/customerAdditionalInfos/{customerId}", async (string customerId) =>
{
    var customerAdditionalInfo = GetCustomerAdditionalInfos().FirstOrDefault(a => a.CustomerId == customerId);

    return customerAdditionalInfo is CustomerAdditionalInfo info ? Results.Ok(info) : Results.NotFound();
});

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
