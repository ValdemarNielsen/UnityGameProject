using System;
using System.Threading.Tasks;

public class AuthenticationManager
{
    private string authToken;
    private readonly HttpClientService httpClientService = new HttpClientService();

    public AuthenticationManager()
    {
        authToken = null;
    }

    public async Task<string> LoginAsync(LoginModel login)
    {
        // Call your login method to obtain the token
        string token = await httpClientService.LoginAsync(login);

        if (!string.IsNullOrEmpty(token))
        {
            authToken = token;
            return token;
        }
        else
        {
            return token;
        }
    }

    public string GetAuthToken()
    {
        return authToken;
    }
}
