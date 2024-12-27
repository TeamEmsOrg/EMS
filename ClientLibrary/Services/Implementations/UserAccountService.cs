using System.Net.Http.Json;
using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;

namespace ClientLibrary.Services.Implementations;

public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
{
    public const string AuthUrl = "api/authentication";
    
    public async Task<GeneralResponse> CreateAsync(Register user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
        if(!result.IsSuccessStatusCode) return new GeneralResponse(false, "Failed to register user Error occured");
        return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
    }

    public async Task<LoginResponse> SignInAsync(Login user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
        if(!result.IsSuccessStatusCode) return new LoginResponse(false, "Failed to login user Error occured");
        return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
    }

    public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
    {
        var httpClient = await getHttpClient.GetPrivateHttpClient();
        var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>($"api/weatherforecast");
        return result;
    }
}