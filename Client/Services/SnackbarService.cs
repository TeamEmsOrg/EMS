namespace Client.Services;

public class SnackbarService
{

    public event Action<string, string>? OnShow;
    public event Action? OnHide;

    public void ShowSnackbar(string message, string type)
    {
        OnShow!.Invoke(message, type);
    }

    public void HideSnackbar()
    {
        OnHide!.Invoke();
    }
}