using CustomerApi.Dtos;
using Refit;

namespace CustomerApi.Repositories.Interfaces;
public interface ICustomerAdditionalInfoApi
{
    [Get("/customerAdditionalInfos/{customerId}")]
    Task<CustomerAdditionalInfoDto> GetCustomerAdditionalInfo(string customerId);
}
