namespace MovieAPI.Application.DTOs;

public class UserRegisterContract
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string BirthDate { get; set; }
}
