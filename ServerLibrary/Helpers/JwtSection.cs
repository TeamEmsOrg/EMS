namespace ServerLibrary.Helpers;

public class JwtSection
{
    // "Key":"",
    // "Issuer":"https://localhost:7098",
    // "Audience":"https://localhost:7098"

    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}