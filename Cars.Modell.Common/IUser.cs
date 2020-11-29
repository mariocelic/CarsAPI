namespace Cars.Model.Common
{
    public interface IUser
    {
        string Password { get; set; }
        string Role { get; set; }
        int UserId { get; set; }
        string Email { get; set; }
    }
}