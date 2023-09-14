using EVRentalEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public Dictionary<string, object> LoginUser(UserDTO user)
        {
            var response = new Dictionary<string, object>();
            var token = new Dictionary<string, object>();
            try
            {
                UserModel usr = _db.user.FirstOrDefault(u => u.username == user.username);
                if (usr != null)
                {
                    if (usr.password == user.password)
                    {
                        token["message"] = usr;
                        token["token"] = GenerateToken(usr);
                        response["message"] = token;
                        return response;
                    }
                    response["message"] = "Incorrect password";
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


        private string GenerateToken(UserModel user)
        {
            try
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Role, "user")
                };

                string myKey =
                    "22434D93E000260FE3D5694E95A53027554751F74C1CCB0007D778E0530C30E23F1B3168F7B5BE2490EA73A2407D5FD4CEA5CD73F5FE913EB6FB2FE6A4599489";
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(myKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddDays(1));

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR -> ", e.Message);
                Console.WriteLine(e.Message.ToString());
                return "Some error in generating token";
            }

        }
    }
}
