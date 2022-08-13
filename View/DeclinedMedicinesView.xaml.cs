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
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for DeclinedMedicinesView.xaml
    /// </summary>
    public partial class DeclinedMedicinesView : Window
    {
        public ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public DeclinedMedicinesView()
        {
            InitializeComponent();
            medicines =new ObservableCollection<Medicine>(medicineRepository.ReadFromFile());
            MedicineTable.ItemsSource = Check(medicines);
        }

        public ObservableCollection<Medicine> Check(ObservableCollection<Medicine> medicines)
        {
            ObservableCollection<Medicine> declinedMedicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.IsAccepted == false)
                {
                    declinedMedicines.Add(medicine);
                }
            }
            return declinedMedicines;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicineView();
            s.Show();
            Close();
        }
    }
}
