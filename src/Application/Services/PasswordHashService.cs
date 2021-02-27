namespace Eliboo.Application.Services
{
    public interface IPasswordHashService
    {
        string CreateHash(string password);
        bool ValidatePassword(string password, string correctHash);
        bool SlowEquals(byte[] a, byte[] b);
        byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes);
    }
}
