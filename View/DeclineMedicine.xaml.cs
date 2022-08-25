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
    /// Interaction logic for DeclineMedicine.xaml
    /// </summary>
    public partial class DeclineMedicine : Window
    {
        MedicineController medicineController = new MedicineController();
        Medicine CurrentMedicine;
        Medicine NewMedicine;
        public User loggedUser = new User();
        public DeclineMedicine( Medicine medicine)
        {
            InitializeComponent();
            whoIsLogged();
            Medicine.Content=medicine.Name;
            CurrentMedicine = medicine;
            ReasonToDecline.Text = medicine.ReasonForRejection;
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
            private void Confirm_click(object sender, RoutedEventArgs e)
        {
            NewMedicine = CurrentMedicine;
            NewMedicine.ReasonForRejection = ReasonToDecline.Text;
            NewMedicine.WaitingForConfirmation = false;
            NewMedicine.IsAccepted = false;
            NewMedicine.IsDeleted = true;
            NewMedicine.DeclinedBy = loggedUser;
            medicineController.UpdateMedicine(CurrentMedicine, NewMedicine);
            Close();
        }
    }
}
