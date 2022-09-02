using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using VasilijeSIMS.Service;

namespace VasilijeSIMS.Controller
{
    public class UserController
    {
        UserService userService =new UserService();

        public bool CreateUser(User user)
        {
            return userService.CreateUser(user);
        }

        public bool UpdateUser (User user, User newUser)
        {
            return userService.UpdateUser(user, newUser);
        }

        public bool DeleteUser (User user)
        {
            return userService.DeleteUser(user);
        }
        public bool BlockUser(User user)
        {
            return userService.BlockUser(user);
        }
        public bool UnblockUser(User user)
        {
            return userService.UnblockUser(user);
        }
    }
}
