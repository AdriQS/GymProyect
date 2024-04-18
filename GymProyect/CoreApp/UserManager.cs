using System;
using Model;
using DataAccess.CRUD;
using System.Text.RegularExpressions;

namespace CoreApp
{
	public class UserManager
	{
        public void Create(User user)
        {
            if (string.IsNullOrEmpty(user.name))
            {
                throw new Exception("Name is required");
            }
            if(string.IsNullOrEmpty(user.lastNames))
            {
                throw new Exception("Last names are required");
            }
            if (string.IsNullOrEmpty(user.email))
            {
                throw new Exception("Email is required");
            }
            if (!ValidPhone(user.phone))
            {
                throw new Exception("Phone is invalid");
            }
            if (user.rol != "client" && user.rol != "admin")
            {
                throw new Exception("The rol is invalid, you can only be admin or client");
            }
            if(!ValidPassword(user.password))
            {
                throw new Exception("The password is invalid, password must have at least one uppercase, one lowercase and one numeric digit");
            }
            var uc = new UserCRUD();
            uc.Create(user);
        }

        public void Delete(int id)
        {
            var uc = new UserCRUD();
            uc.Delete(id);
        }

        public List<User> RetriveAll()
        {
            var uc = new UserCRUD();

            var lstUsers = uc.RetrieveAll<User>();

            foreach (var user in lstUsers)
            {
                user.password = null;
            }

            return lstUsers;
        }

        public User? RetriveById(User user)
        {
            var uc = new UserCRUD();
            var retrievedUser = uc.RetrieveById<User>(user.id);

             retrievedUser.password = null;

            return retrievedUser;
        }

        public void Update(User user, int id)
        {
            if(string.IsNullOrEmpty(user.name))
            {
                throw new Exception("Name is required");
            }
            if (string.IsNullOrEmpty(user.lastNames))
            {
                throw new Exception("Last names are required");
            }
            if (string.IsNullOrEmpty(user.email))
            {
                throw new Exception("Email is required");
            }
            if (!ValidPhone(user.phone))
            {
                throw new Exception("Phone is invalid");
            }
            if (user.rol != "client" && user.rol != "admin")
            {
                throw new Exception("The rol is invalid, you can only be admin or client");
            }
            if (!ValidPassword(user.password))
            {
                throw new Exception("The password is invalid, password must have at least one uppercase, one lowercase and one numeric digit");
            }
            var uc = new UserCRUD();
            uc.Update(user, id);
        }

        public bool ValidPhone(int phone)
        {
            string phoneStr = phone.ToString();

            return phoneStr.Length == 8;
        }

        public bool ValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

            return regex.IsMatch(password);
        }

    }
}

