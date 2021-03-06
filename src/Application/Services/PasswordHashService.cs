namespace Eliboo.Application.Services
{
    public interface IPasswordHashService
    {
        string CreateHash(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}
