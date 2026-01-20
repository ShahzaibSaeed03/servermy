using DTO;
using Entities.Models;

namespace BL
{
    public interface IUserBL
    {
        Task<int> AddUser(UserSignupDTO user);
        Task<TUser> GetUserById(int userId);
        Task<ClientUserWithToken> Login(string email, string password);
        Task<TUser> AddTokens(int userId, int number);

    }

}