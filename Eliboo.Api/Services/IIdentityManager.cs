namespace Eliboo.Api.Services
{
    interface IIdentityManager
    {
        string Authenticate(string email, string password);

        void Register(string username, string email, string password);
    }
}
