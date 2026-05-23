using DPA.SHOPPING.CORE.Core.Entities;

namespace DPA.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> SignIn(string email, string password);
        Task<int> SignUp(User user);
    }
}