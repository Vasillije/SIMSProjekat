using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
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
        public DispatcherTimer timer;
        Medicine newMedicine;
        public DateTime now = DateTime.Now;
        public DateTime procurementDate { get; set; }
        
        public ProcurementOfMedicinesView(Medicine medicine)
        {
            InitializeComponent();
            medicineName.Content=medicine.Name;
            currentAmount.Content=medicine.Quantity;
            currentMedicine=medicine;
            DatePicker.SelectedDate = DateTime.Now.Date;
           // timerInit();
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private  void timerInit()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(40);
            
           //timer.Interval = (procurementDate - DateTime.Now); 
           //MessageBox.Show(timer.Interval.TotalMinutes.ToString());
          // MessageBox.Show(timer.Interval.TotalHours.ToString());
            timer.Start();
            timer.Tick += new EventHandler(timerTick);
        }
        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            medicineController.UpdateMedicine(currentMedicine, newMedicine);
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        { 
            newMedicine = currentMedicine;
            newMedicine.Quantity = currentMedicine.Quantity + Int32.Parse(desiredAmount.Text);
            newMedicine.ProcurementDate = DatePicker.SelectedDate.GetValueOrDefault();
            procurementDate = DatePicker.SelectedDate.GetValueOrDefault();
            if (procurementDate == DateTime.Now.Date)
            {
                medicineController.UpdateMedicine(currentMedicine, newMedicine);
            }
            else 
            {
                timerInit();
            }
            Close();
        }
    }
}
