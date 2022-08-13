using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;

namespace VasilijeSIMS.Service
{
    public class UserService
    {

        public UserRepository userRepository = new UserRepository();
        public bool CreateUser(User newUser)
        {
            List<User> users = new List<User>();
            users = userRepository.ReadFromFile();
            foreach (User i in users)
            {
                if (i.Jmbg.Equals(newUser.Jmbg))
                {
                    MessageBox.Show("This user already exists");
                    return false;

                }
            }
            users.Add(newUser);
            userRepository.LoadIntoFile(users);
            return true;
        }

        public bool UpdateUser(User user, User newUser)
        {
            List <User> users = userRepository.ReadFromFile();
            foreach (User i in users)
            {
                if (i.Jmbg.Equals(user.Jmbg))
                {
                    users.Remove(i);
                    users.Add(newUser);
                    userRepository.LoadIntoFile(users);
                    return true;
                }
            }
            return false;
        }

        public bool BlockUser(User user)
        { 
            User newUser= new User();
            List<User> users = userRepository.ReadFromFile();
            foreach (User i in users)
            {
                if (i.Jmbg.Equals(user.Jmbg))
                {
                    if (i.IsBlocked == false)
                    {
                        i.IsBlocked = true;
                        newUser = i;
                        return UpdateUser(user,newUser);
                    }                 
                }
            }
            return false;           
        }
        public bool UnblockUser(User user)
        {
            User newUser = new User();
            List<User> users = userRepository.ReadFromFile();
            foreach (User i in users)
            {
                if (i.Jmbg.Equals(user.Jmbg))
                {
                    if (i.IsBlocked == true)
                    {
                        i.IsBlocked = false;
                        newUser = i;
                        return UpdateUser(user, newUser);
                    }
                }
            }
            return false;
        }
        public bool DeleteUser(User user)
        {
            List<User> users = userRepository.ReadFromFile();
            foreach (User i in users)
            {
                if(i.Jmbg.Equals(user.Jmbg))
                {
                    users.Remove(i);
                    userRepository.LoadIntoFile(users);
                    return true;
                }    
            }
            return false;
        }

    }
}
