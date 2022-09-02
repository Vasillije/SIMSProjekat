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
using VasilijeSIMS.Service;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for MedicineView.xaml
    /// </summary>
    public partial class MedicineView : Window
    {
        public ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> ConfirmedMedicines = new ObservableCollection<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public MedicineController medicineController = new MedicineController();
        public MedicineService medicineService = new MedicineService();
        
        public User loggedUser = new User();
        public MedicineView()
        {
            InitializeComponent();
            medicines = new ObservableCollection<Medicine>(medicineRepository.ReadFromFile());
            MedicineTable.ItemsSource = Check (medicines);
            whoIsLogged();
        }

        private void whoIsLogged()
        {
             loggedUser = MainWindow.showUser();
            switch (loggedUser.TypeUser)
            {
                case Enums.UserType.Pharmacist:
                    ProcurementOfMedicines.IsEnabled = false;
                    create.IsEnabled = false;
                    update.IsEnabled = false;
                    delete.IsEnabled = false;
                    break;
                case Enums.UserType.Doctor:
                    ProcurementOfMedicines.IsEnabled = false;
                    create.IsEnabled = false;
                    update.IsEnabled = false;
                    delete.IsEnabled = false;
                    break;
                case Enums.UserType.Director:
                    AwaitingConfirmation.IsEnabled = false;
                    DeclinedMedicines.IsEnabled=false;
                    break;
            }
        }

        private ObservableCollection<Medicine> Check(ObservableCollection<Medicine> medicineList)
        {
            ObservableCollection<Medicine> AcceptedMedicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicineList)
                if ((medicine.WaitingForConfirmation == false) && (medicine.IsAccepted == true) && (medicine.IsDeleted == false))
                {
                    AcceptedMedicines.Add(medicine);
                }
            return AcceptedMedicines;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var s = new homepage();
            s.Show();
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var s = new AddMedicineView();
            s.Show();          
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (MedicineTable.SelectedIndex != -1)
            {
                var s = new UpdateMedicineView((Medicine)MedicineTable.SelectedItem);
                s.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MedicineTable.SelectedIndex != -1)
            {
                medicineController.DeleteMedicine(MedicineTable.SelectedItem as Medicine);
                medicines.Remove(MedicineTable.SelectedItem as Medicine);
            }
        }

        private void Awaiting_Conformation_Click(object sender, RoutedEventArgs e)
        {
            var s = new AwaitingConformationView();
            s.Show();
           
        }

        private void Declined_Medicines_Click(object sender, RoutedEventArgs e)
        {
            var s = new DeclinedMedicinesView();
            s.Show();
          
        }

        private void Procurement_Of_Medicines_Click(object sender, RoutedEventArgs e)
        {
            if (MedicineTable.SelectedIndex != -1)
            {
                var s = new ProcurementOfMedicinesView((Medicine)MedicineTable.SelectedItem);
                s.Show();
            }
           
        }
        private void ShowIngredient(object sender, RoutedEventArgs e)
        {
            var s = new IngredientView((Medicine)MedicineTable.SelectedItem);
            s.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MedicineTable.ItemsSource = null;
            medicines = new ObservableCollection<Medicine>(medicineRepository.ReadFromFile());
            MedicineTable.ItemsSource = Check(medicines);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineService.SearchAccepted(searchBox.Text/*, searchBox1.Text, searchBox2.Text*/));
            MedicineTable.ItemsSource = help;
        }

        private void Search_Quantity_Click(object sender, RoutedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineService.SearchAcceptedQuantity(searchBox1.Text, searchBox2.Text));
            MedicineTable.ItemsSource = help;
        }

        private void Search_Ingredient_Click(object sender, RoutedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineService.SearchAcceptedIngredient(searchBox.Text));
            MedicineTable.ItemsSource = help;
        }
    }
}
