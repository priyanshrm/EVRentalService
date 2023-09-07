using EVRentalEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly EVRentalDbContext _db;

        public UserRepository(EVRentalDbContext dbContext)
        {
            _db = dbContext;
        }

        public Dictionary<string, object> AddUser(UserModel user)
        {
            var response = new Dictionary<string, object>();

            try
            {
                _db.user.Add(user);
                _db.SaveChanges();
                response["message"] = "inserted";
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }
        public Dictionary<string, object> GetAllUser()
        {
            var response = new Dictionary<string,object>();
            try
            {
                List<UserModel> users = _db.user.ToList();
                response["message"] = users;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }
        public Dictionary<string, object> GetUserById(int id)
        {
            var response = new Dictionary<string, object>();
            try
            {
                UserModel usr = _db.user.Find(id);
                response["message"] = usr;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }
        public Dictionary<string, object> DeletAllUser()
        {
            var response = new Dictionary<string, object>();
            try
            {
                var usrs = _db.user.ToList();
                foreach (var user in usrs)
                {
                    _db.user.Remove(user);    
                }
                _db.SaveChanges();  
                var newUsrs = _db.user.ToList();
                response["message"] = newUsrs;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }
        public Dictionary<string, object> DeletUserById(int id)
        {
            var response = new Dictionary<string, object>();
            try
            {
                UserModel usr = _db.user.Find(id);
                if (usr != null)
                {
                    _db.user.Remove(usr);
                    _db.SaveChanges();
                    response["message"] = usr;
                } else
                {
                    response["message"] = "User Id not found";
                }
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }
        public Dictionary<string, object> UpdateUser(UserModel user)
        {
            var response = new Dictionary<string, object>();
            try
            {
                UserModel usr = _db.user.Find(user.userId);
                if (usr != null)
                {
                    _db.Entry(usr).State = EntityState.Modified; //update statement
                    _db.SaveChanges();
                    response["message"] = usr;
                }
                else
                {
                    response["message"] = "User Id not found";
                }
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }
    }
}
