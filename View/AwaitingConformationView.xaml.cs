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
using VasilijeSIMS.Enums;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using VasilijeSIMS.Service;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for AwaitingConformationView.xaml
    /// </summary>
    public partial class AwaitingConformationView : Window
    {
        public ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public MedicineController medicineController = new MedicineController();
        public MedicineService medicineService = new MedicineService();
        Medicine CurrentMedicine;
        Medicine NewMedicine;
        public User loggedUser = new User();
        public AwaitingConformationView()
        {
            InitializeComponent();
            medicines= new ObservableCollection<Medicine>(medicineRepository.ReadFromFile());
            AwaitingMedicineTable.ItemsSource = Check(medicines);
            whoIsLogged();
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
        public ObservableCollection<Medicine> Check(ObservableCollection<Medicine> medicines)
        {
            ObservableCollection<Medicine> waitingMedicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.WaitingForConfirmation == true && medicine.IsAccepted==false && medicine.IsDeleted==false )
                {
                    waitingMedicines.Add(medicine);
                }
            }
            return waitingMedicines;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ShowIngredient(object sender, RoutedEventArgs e)
        {
            var s = new IngredientView((Medicine)AwaitingMedicineTable.SelectedItem);
            s.Show();
        }
        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            if (AwaitingMedicineTable.SelectedIndex != -1)
            {   
                var s = new DeclineMedicine((Medicine)AwaitingMedicineTable.SelectedItem);
                s.Show();
                Close();
            }
        }

        public bool checkIfApproved(Medicine medicine)
        {
            if (medicineController.ThreePeopleCheck(medicine) == true && medicineController.ApprovedByDoctorCheck(medicine) && medicineController.ApprovedByPharmacistCheck(medicine))
            {
                return true;
            }
            return false;
          
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (AwaitingMedicineTable.SelectedIndex != -1)
            {           
                CurrentMedicine = (Medicine)AwaitingMedicineTable.SelectedItem;
                medicineController.addToApprovedBy(CurrentMedicine,loggedUser);
                NewMedicine = CurrentMedicine;
                if (checkIfApproved(CurrentMedicine) == true)
                {
                    NewMedicine.WaitingForConfirmation = false;
                    NewMedicine.IsAccepted = true;
                    NewMedicine.IsDeleted = false;
                    medicineController.UpdateMedicine(CurrentMedicine, NewMedicine);
                    Close();
                }
                else
                {
                    MessageBox.Show("Not yet approved");
                    Close();
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineService.SearchAwaiting(searchBox.Text));
            AwaitingMedicineTable.ItemsSource = help;
        }
    }
}
