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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using VasilijeSIMS.View;

namespace VasilijeSIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserRepository userRepository = new UserRepository();
        private static User LoggedUser = new User();
        int brojac=0;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static User showUser()
        {
            return LoggedUser;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = userRepository.ReadFromFile();

            if(password.Password.ToString().Equals("") || email.Text.Equals(""))
            {
                MessageBox.Show("Fill in all fields");
                return;
            }

            Boolean postoji = false;
            Boolean blokiran = false;

            foreach (User user in users)
            {
                if (user.Email.Equals(email.Text) && (user.Password.Equals(password.Password.ToString())))
                {
                    if (user.IsBlocked == true)
                    {
                        blokiran = true;
                    }
                    else 
                    {
                        blokiran = false;
                    }
                    postoji = true;
                    LoggedUser = user;
                    showUser();
                    break; 
                }
                else 
                { 
                    postoji = false;
                }
            }

            if (postoji == true && blokiran==false)
            {
               
                var s = new homepage();
                s.Show();
                Close();
            }
            else if (brojac >=2)
            {
                Close();
                MessageBox.Show("You tried 3 times");
            }
            else if (postoji == false)
            {
                brojac++;
                MessageBox.Show("invalid username or password");
            }
            else if (blokiran == true)
            {
                MessageBox.Show("blocked user");
            }
        }
    }
}
