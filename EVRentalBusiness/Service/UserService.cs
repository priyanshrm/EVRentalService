using EVRentalDAL.Repositories;
using EVRentalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalBusiness.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public Dictionary<string, object> AddUser(UserModel user)
        {
            return _userRepository.AddUser(user);
        }
        public Dictionary<string, object> GetAllUser(){
            return _userRepository.GetAllUser();    
        }
        public Dictionary<string, object> GetUserById(int id)
        {
            return _userRepository.GetUserById(id); 
        }
        public Dictionary<string, object> DeletAllUser()
        {
            return _userRepository.DeletAllUser();
        }
        public Dictionary<string, object> DeletUserById(int id)
        {
            return _userRepository.DeletUserById(id);   
        }
        public Dictionary<string, object> UpdateUser(UserModel user)
        {
            return _userRepository.UpdateUser(user);    
        }
    }
}
