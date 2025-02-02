using Microsoft.JSInterop;

namespace Client;
public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    public event Action? OnThemeChange;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ToggleTheme()
    {
        await _jsRuntime.InvokeVoidAsync("toggleTheme");
        OnThemeChange?.Invoke();
    }

    public async Task InitializeTheme()
    {
        await _jsRuntime.InvokeVoidAsync("initializeTheme");
    }
}