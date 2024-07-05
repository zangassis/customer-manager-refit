using CustomerApi.Dtos;
using Refit;

namespace CustomerApi.Repositories.Repositories;
public interface ICustomerAdditionalInfoApi
{
    [Get("/customerAdditionalInfos/{customerId}")]
    Task<CustomerAdditionalInfoDto> GetCustomerAdditionalInfo(string customerId);
}
