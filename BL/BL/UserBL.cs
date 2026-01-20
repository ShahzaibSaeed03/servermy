using AutoMapper;
using DAL;
using DTO;
using Entities.Models;
using System.Data;

namespace BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IJwtTokenBL _jwtTokenBL;

        public UserBL(IUserDAL userDAL, IMapper mapper, IJwtTokenBL jwtTokenBL)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _jwtTokenBL = jwtTokenBL;
        }
        public async Task<int> AddUser(UserSignupDTO userSignup)
        {
            TUser userExists = await _userDAL.GetUserByEmail(userSignup.Email);
            if (userExists != null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }

            TUser user = _mapper.Map<TUser>(userSignup);
            user.IdRole = 2;//maybe change this line and get it from db
            user.CreationDate = DateTime.Now;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userSignup.Password);
            user.DateEndSubscription = DateTime.Now.AddYears(1);
            user.RemainingTokens = 0;
            await _userDAL.AddUser(user);//map here to userReturnDto
            return user.Id;
        }

        public async Task<TUser?> GetUserById(int userId)
        {
            return await _userDAL.GetUserById(userId);
        }

        public async Task<ClientUserWithToken> Login(string email, string password)
        {
            TUser user = await _userDAL.GetUserByEmail(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            var token = _jwtTokenBL.GenerateJwtToken(user.Id.ToString(), user.IdRole.ToString());
            ClientUserDTO clientUser = _mapper.Map<ClientUserDTO>(user);
            return new ClientUserWithToken(clientUser, token);
        }

        public async Task<TUser?> AddTokens(int userId, int number)
        {//add mapping
            return await _userDAL.AddTokens(userId, number);
        }

    }
}
