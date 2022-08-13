using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VasilijeSIMS.Controller;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for UpdateUserView.xaml
    /// </summary>
    public partial class UpdateUserView : Window
    {
        public List<User> users;
        public User user;
        public UserRepository userRepository = new UserRepository();
        public UserController userController  = new UserController();

        public UpdateUserView(List<User> users, User user)
        {
            InitializeComponent();
            this.users = users;
            this.user = user;
            jmbg.Text = user.Jmbg;
            email.Text = user.Email;
            password.Text = user.Password;
            name.Text = user.Name;
            surname.Text = user.LastName;
            phone.Text = user.PhoneNumber;
            cbUserType.Text = user.TypeUser.ToString();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var s = new UserView();
            s.Show();
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            newUser.Jmbg = jmbg.Text;
            newUser.Email = email.Text;
            newUser.Name = name.Text;
            newUser.LastName = surname.Text;
            newUser.PhoneNumber= phone.Text;
            newUser.Password = password.Text;
            //user.TypeUser = cbUserType.Text;
            userController.UpdateUser(user, newUser);
            var s = new UserView();
            s.Show();
            Close();
        }
    }
}
