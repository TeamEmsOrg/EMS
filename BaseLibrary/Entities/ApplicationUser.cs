namespace BaseLibrary.Entities;

public class ApplicationUser
{
    //Managers to create and delete users
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

}