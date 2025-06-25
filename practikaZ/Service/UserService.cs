using Microsoft.EntityFrameworkCore;
using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace practikaZ.Service
{
    internal class UserService
    {
        public static User? GetUser(string login, string password)
        {
            using (MyDbContext context = new MyDbContext())
            {
                return context.Users.Where(u => u.Login == login && u.Password == password)
                    .Include(u => u.Orders)
                    .Include(u => u.Post)
                    .Include(u => u.Specialization)
                    .FirstOrDefault();

            }
        }

        public static void RegUser(User user)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(User user)
        {
            using (var context = new MyDbContext())
            {
                var existing = context.Users.Find(user.Id);
                if (existing != null)
                {
                    if (UserHelper.user.RoleId == 2 && user.RoleId == 1 )
                    {
                        MessageBox.Show("Недостаточно прав для назначения роли администратора.", "Доступ запрещен");
                        return;
                    }
                    if (UserHelper.user.RoleId == 2)
                    {
                        var target = context.Users.Find(user.Id);

                        if (target != null && target.RoleId != 3)
                        {
                            MessageBox.Show("Недостаточно прав для изменения роли этого пользователя.",
                                            "Доступ запрещён", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    existing.FirstName = user.FirstName;
                    existing.LastName = user.LastName;
                    existing.Patronymic = user.Patronymic;
                    existing.Login = user.Login;
                    existing.Password = user.Password;
                    existing.PhoneNumber = user.PhoneNumber;
                    existing.JobPhoneNumber = user.JobPhoneNumber;
                    existing.RoleId = user.RoleId;
                    existing.SpecializationId = user.SpecializationId;
                    existing.PostId = user.PostId;

                    context.SaveChanges();
                }
            }
        }

        public static void DeleteUser(int userId)
        {
            using (var context = new MyDbContext())
            {
                var user = context.Users.Find(userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public static List<User> GetAccessibleUsers(int currentUserRole)
        {
            using (var context = new MyDbContext())
            {
                if (currentUserRole == 1) 
                    return context.Users.Include(u => u.Role).ToList();

                if (currentUserRole == 2) 
                    return context.Users
                        .Where(u => u.RoleId == 3 || u.RoleId == 2)
                        .Include(u => u.Role)
                        .ToList();

                return new List<User>();
            }
        }
        public static User GetUserById(int userId)
        {
            using (var context = new MyDbContext())
            {
                return context.Users
                    .Include(u => u.Post)
                    .Include(u => u.Specialization)
                    .FirstOrDefault(u => u.Id == userId);
            }
        }
        public static List<User> GetUsers()
        {
            using (var context = new MyDbContext())
            {
                return context.Users
                    .Include(u => u.Role)
                    .Include(u => u.Post)
                    .Include(u => u.Specialization)
                    .ToList();
            }
        }
    }
}