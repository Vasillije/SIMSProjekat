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
    /// Interaction logic for AddMedicineView.xaml
    /// </summary>
    public partial class AddMedicineView : Window
    {
        public MedicineController medicineController = new MedicineController();
        public AddMedicineView()
        {
            InitializeComponent();
        }

        public bool validation()
        {
            if (id.Text == null || name.Text == null || manufacturer.Text == null || quantity.Text == null || ingredientName.Text == null || description.Text == null)
            {
                MessageBox.Show("you must fill in all fields");
                return false;
            }
            return true;
        }

        //public bool quantityValidation()
        //{
        //    byte[] asciiBytes = Encoding.ASCII.GetBytes(quantity.Text);
        //    for (int i = 0;i< asciiBytes.Length;i++)
        //        {
        //        if (asciiBytes[i] >= 48 && asciiBytes[i] <= 57)
        //        {
        //            MessageBox.Show("quantity must be a number");
        //            return false;
        //        }
        //        }
        //    return true;   
        //}

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (validation() == true /*&& quantityValidation()==true*/)
            {
                Medicine newMedicine = new Medicine(id.Text, name.Text, manufacturer.Text, Int32.Parse( quantity.Text), ingredientName.Text, description.Text);
                medicineController.CreateMedicine(newMedicine);
            }
            Close();
        }
    }
}
