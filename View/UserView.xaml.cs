using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        
        public List<User> users = new List<User>();
        public UserRepository userRepository = new UserRepository();
        public UserController userController = new UserController();

        public UserView()
        {
            InitializeComponent();
            users = new List<User>(userRepository.ReadFromFile());
            UsersTable.ItemsSource = users;
        }

        public bool LoggedUser (User user)
        {
            if (user.TypeUser == 0)
            {
                create.IsEnabled = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateUserClick(object sender, RoutedEventArgs e)
        {
            AddUserView prozor = new AddUserView();
            prozor.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var s = new homepage();
            s.Show();
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (UsersTable.SelectedIndex != -1)
            {
                User user= (User)UsersTable.SelectedItem;
               
                var s = new UpdateUserView(users, user);
                s.Show();
                Close();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(UsersTable.SelectedIndex != -1)
            {
                userController.DeleteUser(UsersTable.SelectedItem as User); 
                users.Remove(UsersTable.SelectedItem as User);
            }
        }

       
        private void Block_Click(object sender, RoutedEventArgs e)
        {
            if (UsersTable.SelectedIndex != -1)
            {
                User user = (User)UsersTable.SelectedItem;
                Boolean blocked=userController.BlockUser(user);
                if (blocked == true)
                {
                    MessageBox.Show("user blocked");
                }
            }
        }

        private void UsersTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Unblock_Click(object sender, RoutedEventArgs e)
        {
            if (UsersTable.SelectedIndex != -1)
            {
                User user = (User)UsersTable.SelectedItem;
                Boolean blocked = userController.UnblockUser(user);
                if (blocked == true)
                {
                    MessageBox.Show("user unblocked");
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            users.Clear();
            ObservableCollection<User> help;
            help = new ObservableCollection<User>(userRepository.Search(searchBox.Text));
            UsersTable.ItemsSource = help;
        }
    }
}
