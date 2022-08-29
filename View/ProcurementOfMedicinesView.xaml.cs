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
        public MedicineController medicineController = new MedicineController();
        public Medicine currentMedicine;
        public DateTime now = DateTime.Now;


        public ProcurementOfMedicinesView(Medicine medicine)
        {
            InitializeComponent();
            medicineName.Content=medicine.Name;
            currentAmount.Content=medicine.Quantity;
            currentMedicine=medicine;
            DatePicker.SelectedDate = DateTime.Now.Date;
        }

        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Medicine newMedicine ;
            newMedicine = currentMedicine;
            newMedicine.Quantity = currentMedicine.Quantity + Int32.Parse(desiredAmount.Text);
            newMedicine.ProcurementDate = DatePicker.SelectedDate.GetValueOrDefault();
            medicineController.UpdateMedicine(currentMedicine, newMedicine);
            Close();
            //DPTime.SelectedDate.GetValueOrDefault()
        }
    }
}
