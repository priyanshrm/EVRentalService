using EVRentalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL.Repositories
{
    public interface IUserRepository
    {
        Dictionary<string, object> AddUser(UserModel user);
        Dictionary<string, object> GetAllUser();
        Dictionary<string, object> GetUserById(int id);
        Dictionary<string, object> DeletAllUser();
        Dictionary<string, object> DeletUserById(int id);
        Dictionary<string, object> UpdateUser(UserModel user);  




    }
}
