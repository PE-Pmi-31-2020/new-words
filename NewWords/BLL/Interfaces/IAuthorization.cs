namespace BLL
{
    public interface IAuthorization
    {
        void TryLogin(string email, string password);
        void TrySignup(string email, string password);
    }
}