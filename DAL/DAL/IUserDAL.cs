using DTO;
using Entities.Models;

namespace DAL
{
    public interface IUserDAL
    {
        Task<TUser> AddUser(TUser user);
        Task<TUser> GetUserById(int userId);
        Task<TUser> GetUserByEmail(string email);
        Task<TUser> AddTokens(int userId, int number);

    }
}