using CustomerApi.Repositories.Interfaces;

namespace CustomerApi.Repositories;
public class AuthTokenProvider : IAuthTokenProvider
{
    public string GetToken()
    {
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.pg-7kh_cZ0m4yDULVjR7rKPZFh7nBprKGFVYzS7Y7y0";
    }
}