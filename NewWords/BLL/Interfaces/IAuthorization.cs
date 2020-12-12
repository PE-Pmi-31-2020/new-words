namespace BLL
{
    public interface IAuthorization
    {
        bool TryLogin(string email, string password);
        bool TrySignup(string email, string password);
    }
}