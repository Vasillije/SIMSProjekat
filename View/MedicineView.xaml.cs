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
    /// Interaction logic for MedicineView.xaml
    /// </summary>
    public partial class MedicineView : Window
    {
        public ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> ConfirmedMedicines = new ObservableCollection<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public MedicineController medicineController = new MedicineController();
        public MedicineView()
        {
            InitializeComponent();
            medicines = new ObservableCollection<Medicine>(medicineRepository.ReadFromFile());
            MedicineTable.ItemsSource = Check (medicines);
        }

        private ObservableCollection<Medicine> Check(ObservableCollection<Medicine> medicineList)
        {
            ObservableCollection<Medicine> AcceptedMedicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicineList)
                if (medicine.IsAccepted == true)
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
        private void Search(object sender, TextChangedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineRepository.Search(searchBox.Text));
            MedicineTable.ItemsSource = help;
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var s = new AddMedicineView();
            s.Show();
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var s = new UpdateMedicineView();
            s.Show();
            Close();
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
            Close();
        }

        private void Declined_Medicines_Click(object sender, RoutedEventArgs e)
        {
            var s = new DeclinedMedicinesView();
            s.Show();
            Close();
        }

        private void Procurement_Of_Medicines_Click(object sender, RoutedEventArgs e)
        {
            var s = new ProcurementOfMedicinesView();
            s.Show();
            Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            medicines.Clear();
            ObservableCollection<Medicine> help;
            help = new ObservableCollection<Medicine>(medicineRepository.Search(searchBox.Text));
            MedicineTable.ItemsSource = help;

        }
    }
}
