using EVRentalDAL.Repositories;
using EVRentalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalBusiness.Service
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Dictionary<string, object> RegisterUser(UserModel user)
        {
            return _userRepository.AddUser(user);
        }

        public Dictionary<string, object> LoginUser(UserDTO user)
        {
            return _userRepository.LoginUser(user);
        }
    }
}
