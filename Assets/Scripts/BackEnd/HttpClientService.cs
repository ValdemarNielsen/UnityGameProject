using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class HttpClientService
{
    private readonly HttpClient httpClient;

    public HttpClientService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5009"); // Replace with our API base URL
    }

    // Example method to register a new user
    public async Task<bool> RegisterAsync(CreateUserModel createUser)
    {
        var json = JsonSerializer.Serialize(createUser);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("api/authentication/register", content);
        return response.IsSuccessStatusCode;
    }

    // Example method to login
    public async Task<string> LoginAsync(LoginModel login)
    {
        var json = JsonSerializer.Serialize(login);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("api/authentication/login", content);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            // Parse the token from the response
            return result;
        }
        else
        {
            return null;
        }
    }
}

// Model classes

public class CreateUserModel
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
}
