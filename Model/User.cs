using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Enums;

namespace VasilijeSIMS.Model
{
    public class User
    {
        public string Jmbg { get; set; } //jedinstveno
        public string Email { get; set; } //jedinstveno
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserType TypeUser { get; set; }
        public Boolean IsBlocked { get; set; } = false;


        public User(string jmbg, string email, string password, string name, string lastName, string phoneNumber, UserType typeUser)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            TypeUser = typeUser;
            IsBlocked = false;
        }
        public User(string jmbg, string email, string password, string name, string lastName, string phoneNumber, UserType typeUser, Boolean isBlocked)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            TypeUser = typeUser;
            IsBlocked = isBlocked;
        }

        public User()
        {
        }

    }
}
