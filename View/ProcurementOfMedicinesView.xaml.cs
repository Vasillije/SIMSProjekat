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
using VasilijeSIMS.Repository;

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for ProcurementOfMedicinesView.xaml
    /// </summary>
    public partial class ProcurementOfMedicinesView : Window
    {
        public List<Medicine> medicines = new List<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public ProcurementOfMedicinesView()
        {
            InitializeComponent();
            medicines = new List<Medicine>(medicineRepository.ReadFromFile());
            MedicineTable.ItemsSource = medicines;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicineView();
            s.Show();
            Close();
        }
    }
}
