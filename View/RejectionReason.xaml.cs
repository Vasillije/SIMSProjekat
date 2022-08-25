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
using VasilijeSIMS.Model;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for RejectionReason.xaml
    /// </summary>
    public partial class RejectionReason : Window
    {
        public User loggedUser = new User();

        public RejectionReason(Medicine medicine)
        {
            InitializeComponent();
            MedicineName.Content = medicine.Name;
            whoIsLogged();
            Doctor.Content = medicine.DeclinedBy.Name; 
            reasonForRejection.Text=medicine.ReasonForRejection;
        }
        private void whoIsLogged()
        {
            loggedUser = MainWindow.showUser();
            switch (loggedUser.TypeUser)
            {
                case Enums.UserType.Pharmacist:
                    break;
                case Enums.UserType.Doctor:
                    break;
                case Enums.UserType.Director:
                    
                    break;
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
