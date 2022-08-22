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
    /// Interaction logic for UpdateMedicineView.xaml
    /// </summary>
    public partial class UpdateMedicineView : Window
    {
        MedicineController medicineController = new MedicineController();
        Medicine oldMedicine = new Medicine();
        public UpdateMedicineView(Medicine medicine)
        {
            InitializeComponent();
            oldMedicine = medicine;
            id.Text=medicine.Id;
            name.Text = medicine.Name;
            manufacturer.Text = medicine.Manufacturer;
            quantity.Text = medicine.Quantity.ToString();
            ingredients.Text = medicine.IngredientV.Name;
            ingredients_description.Text = medicine.IngredientV.Description;
            if (medicine.IsAccepted)
                yes1.IsChecked = true;
            else
                no1.IsChecked = true;

            if (medicine.IsDeleted)
                yes2.IsChecked = true;
            else
                no2.IsChecked = true;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Medicine newMedicine = new Medicine(id.Text, name.Text, manufacturer.Text, Int32.Parse(quantity.Text), ingredients.Text, ingredients_description.Text, oldMedicine.IsAccepted,oldMedicine.WaitingForConfirmation, oldMedicine.IsDeleted, oldMedicine.ReasonForRejection);
            if (newMedicine.IsAccepted ==false && newMedicine.IsDeleted==true && newMedicine.WaitingForConfirmation == false )
            {
                newMedicine.WaitingForConfirmation= true;
                newMedicine.IsDeleted = false;

            }
            medicineController.UpdateMedicine(oldMedicine, newMedicine);
            MessageBox.Show("medicine successfully changed");
            Close();
        }
    }
}