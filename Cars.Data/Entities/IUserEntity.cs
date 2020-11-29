namespace Cars.DAL.Entities
{
    public interface IUserEntity
    {
        string Email { get; set; }
        string Password { get; set; }
        string Role { get; set; }
        int UserId { get; set; }
    }
}