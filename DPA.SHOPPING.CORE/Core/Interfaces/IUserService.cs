using DPA.SHOPPING.CORE.Core.DTOs;

namespace DPA.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserListDTO?> SignIn(UserSignInDTO userSignInDTO);
        Task<int> SignUp(UserSignUpDTO userSignUpDTO);
    }
}