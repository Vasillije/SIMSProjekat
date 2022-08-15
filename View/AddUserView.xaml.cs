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

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window
    {

        UserController userController =new UserController();    
        public AddUserView()
        {
            InitializeComponent();
        }

        public bool validation()
        {
            if (jmbg.Text == null || email.Text == null || password.Text== null || name.Text == null || surname.Text== null || phone.Text == null || cbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("you must fill in all fields");
                return false;
            }
            return true;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {   
            if (validation() == true)
            {
                User newUser = new User(jmbg.Text, email.Text, password.Text, name.Text, surname.Text, phone.Text, (Enums.UserType)cbUserType.SelectedIndex);
                userController.CreateUser(newUser);
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var s = new UserView();
            s.Show();
            Close();
        }
    }
}

