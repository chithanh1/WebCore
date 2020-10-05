using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Support;

namespace VegeFood.Services.SQLService
{
    public class UserService: SQLBaseService
    {
        public UserService(IConfiguration configuration) : base(configuration) { }

        public Result InsertNewUser(InsertUserInfo insertUser)
        {
            User checkUser = SqlData.Users.SingleOrDefault(x => x.Username == insertUser.Username);
            if (checkUser != null) return new Result
            {
                status = false,
                data = $"the user with username: {insertUser.Username} is exsist"
            };
            User user = new User()
            {
                Name = insertUser.Name,
                Age = insertUser.Age,
                Username = insertUser.Username,
                Password = Secret.SHA256Hash(insertUser.Password),
                Sex = insertUser.Sex,
                Phone = insertUser.Phone,
                Address = insertUser.Address,
                Email = insertUser.Email,
                Type = "user",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                LastLogin = DateTime.Now
            };
            if (insertUser.Image != null) user.Image = insertUser.Image;
            if (insertUser.Birthday != null) user.Birthday = insertUser.Birthday;
            if (insertUser.Node != null) user.Node = insertUser.Node;
            SqlData.Users.Add(user);
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"do not insert new user"
            };
        }

        public async Task<Result> InsertNewUserAsync(InsertUserInfo insertUser)
        {
            User checkUser = await SqlData.Users.SingleOrDefaultAsync(x => x.Username == insertUser.Username);
            if (checkUser != null) return new Result
            {
                status = false,
                data = $"the user with username: {insertUser.Username} is exsist"
            };
            User user = new User()
            {
                Name = insertUser.Name,
                Age = insertUser.Age,
                Username = insertUser.Username,
                Password = Secret.SHA256Hash(insertUser.Password),
                Sex = insertUser.Sex,
                Phone = insertUser.Phone,
                Address = insertUser.Address,
                Email = insertUser.Email,
                Type = "user",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                LastLogin = DateTime.Now
            };
            if (insertUser.Image != null) user.Image = insertUser.Image;
            if (insertUser.Birthday != null) user.Birthday = insertUser.Birthday;
            if (insertUser.Node != null) user.Node = insertUser.Node;
            await SqlData.Users.AddAsync(user);
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"do not insert new user"
            };
        }

        public User GetUserById(int userId)
        {
            User user = SqlData.Users.Find(userId);
            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            User user = await SqlData.Users.FindAsync(userId);
            return user;
        }

        public List<User> GetListUsers()
        {
            List<User> userList = SqlData.Users.ToList();
            return userList;
        }

        public async Task<List<User>> GetListUsersAsync()
        {
            List<User> userList = await SqlData.Users.ToListAsync();
            return userList;
        }

        public Result UpdateUser(User updateUser)
        {
            User user = SqlData.Users.Find(updateUser.Id);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {updateUser.Id} do not exsist"
            };
            if(updateUser.Username != null)
            {
                User checkUser = SqlData.Users.SingleOrDefault(x => x.Username == updateUser.Username);
                if (checkUser != null) return new Result
                {
                    status = false,
                    data = $"the user with username: {updateUser.Username} is exsist"
                };
                user.Username = updateUser.Username;
            }
            if (updateUser.Name != null) user.Name = updateUser.Name;
            if (updateUser.Age > 0) user.Age = updateUser.Age;
            if (updateUser.Password != null) user.Password = Secret.SHA256Hash(updateUser.Password);
            if (updateUser.Image != null) user.Image = updateUser.Image;
            if (updateUser.Birthday != null) user.Birthday = updateUser.Birthday;
            if (updateUser.Sex != null) user.Sex = updateUser.Sex;
            if (updateUser.Phone != null) user.Phone = updateUser.Phone;
            if (updateUser.Address != null) user.Address = updateUser.Address;
            if (updateUser.Email != null) user.Email = updateUser.Email;
            if (updateUser.Node != null) user.Node = updateUser.Node;
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {updateUser.Id}"
            };
        }

        public async Task<Result> UpdateUserAsync(User updateUser)
        {
            User user = await SqlData.Users.FindAsync(updateUser.Id);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {updateUser.Id} do not exsist"
            };
            if (updateUser.Username != null)
            {
                User checkUser = await SqlData.Users.SingleOrDefaultAsync(x => x.Username == updateUser.Username);
                if (checkUser != null) return new Result
                {
                    status = false,
                    data = $"the user with username: {updateUser.Username} is exsist"
                };
                user.Username = updateUser.Username;
            }
            if (updateUser.Name != null) user.Name = updateUser.Name;
            if (updateUser.Age > 0) user.Age = updateUser.Age;
            if (updateUser.Password != null) user.Password = Secret.SHA256Hash(updateUser.Password);
            if (updateUser.Image != null) user.Image = updateUser.Image;
            if (updateUser.Birthday != null) user.Birthday = updateUser.Birthday;
            if (updateUser.Sex != null) user.Sex = updateUser.Sex;
            if (updateUser.Phone != null) user.Phone = updateUser.Phone;
            if (updateUser.Address != null) user.Address = updateUser.Address;
            if (updateUser.Email != null) user.Email = updateUser.Email;
            if (updateUser.Node != null) user.Node = updateUser.Node;
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {updateUser.Id}"
            };
        }

        public Result UpdateRoleUser(UpdateAdminUser updateAdminUser)
        {
            User user = SqlData.Users.Find(updateAdminUser.Id);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {updateAdminUser.Id} do not exsist"
            };
            if (updateAdminUser.Status != null) user.Status = updateAdminUser.Status;
            if (updateAdminUser.Type != null) user.Type = updateAdminUser.Type;
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {updateAdminUser.Id}"
            };
        }

        public async Task<Result> UpdateRoleUserAsync(UpdateAdminUser updateAdminUser)
        {
            User user = await SqlData.Users.FindAsync(updateAdminUser.Id);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {updateAdminUser.Id} do not exsist"
            };
            if (updateAdminUser.Status != null) user.Status = updateAdminUser.Status;
            if (updateAdminUser.Type != null) user.Type = updateAdminUser.Type;
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {updateAdminUser.Id}"
            };
        }

        public Result DeleteUser(int userId)
        {
            User user = SqlData.Users.Find(userId);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {userId} do not exist"
            };
            SqlData.Users.Remove(user);
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {userId}"
            };
        }

        public async Task<Result> DeleteUserAsync(int userId)
        {
            User user = await SqlData.Users.FindAsync(userId);
            if (user == null) return new Result
            {
                status = false,
                data = $"the user with id: {userId} do not exist"
            };
            SqlData.Users.Remove(user);
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = user
            };
            else return new Result
            {
                status = false,
                data = $"Do not update user with id: {userId}"
            };
        }

        public Result Login(string username, string password)
        {
            User user = SqlData.Users.SingleOrDefault(x => x.Username == username);
            if (user == null) return new Result
            {
                status = false,
                data = "Wrong username or password"
            };
            string checkPassword = Secret.SHA256Hash(password);
            if (checkPassword != user.Password) return new Result
            {
                status = false,
                data = "Wrong username or password"
            };
            if (user.Status == "disable") return new Result
            {
                status = false,
                data = "this account is not enable"
            };
            return new Result
            {
                status = true,
                data = null
            };
        }

        public async Task<Result> LoginAsync(string username, string password)
        {
            User user = await SqlData.Users.SingleOrDefaultAsync(x => x.Username == username);
            if (user == null) return new Result
            {
                status = false,
                data = "Wrong username or password"
            };
            string checkPassword = Secret.SHA256Hash(password);
            if (checkPassword != user.Password) return new Result
            {
                status = false,
                data = "Wrong username or password"
            };
            if (user.Status == "disable") return new Result
            {
                status = false,
                data = "this account is not enable"
            };
            return new Result
            {
                status = true,
                data = null
            };
        }
    }
}
