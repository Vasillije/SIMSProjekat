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
    /// Interaction logic for UpdateMedicineView.xaml
    /// </summary>
    public partial class UpdateMedicineView : Window
    {
        MedicineController medicineController = new MedicineController();
        Medicine oldMedicine = new Medicine();
        public IngredientRepository ingredientRepository = new IngredientRepository();
        public ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public UpdateMedicineView(Medicine medicine)
        {
            InitializeComponent();
            oldMedicine = medicine;
            id.Text=medicine.Id;
            name.Text = medicine.Name;
            manufacturer.Text = medicine.Manufacturer;
            quantity.Text = medicine.Quantity.ToString();
            ingredients = new ObservableCollection<Ingredient>(medicine.ingredientDictionary.Values);
            ingredientsDataGrid.ItemsSource = showIngredients(ingredients);
           
            if (medicine.IsAccepted)
                yes1.IsChecked = true;
            else
                no1.IsChecked = true;

            if (medicine.IsDeleted)
                yes2.IsChecked = true;
            else
                no2.IsChecked = true;

        }

        private ObservableCollection<Ingredient> showIngredients(ObservableCollection<Ingredient> ingredientsList)
        {
            ObservableCollection<Ingredient> ing = new ObservableCollection<Ingredient>(ingredientRepository.ReadFromFile());

            foreach (Ingredient i in ing)
            {
                foreach (Ingredient ii in ingredientsList)
               {
                    if (i.Name == ii.Name)
                    {
                        i.IsChecked = true;
                    }
               }
            }
            return ing;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private List<Ingredient> IngredientsChecked()
        {
            List<Ingredient> checkedIngredients = new List<Ingredient>();
            foreach (Ingredient ingr in ingredientsDataGrid.ItemsSource)
            {
                if (ingr.IsChecked == true)
                {
                    checkedIngredients.Add(ingr);
                }
            }
            return checkedIngredients;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            List<Ingredient> ingredientsList = IngredientsChecked();
            Dictionary<string, Ingredient> ingredientsDictionary = new Dictionary<string, Ingredient>();
            foreach (Ingredient i in ingredientsList)
            {
                ingredientsDictionary.Add(i.Name + "key", i);

            }
            Medicine newMedicine = new Medicine(id.Text, name.Text, manufacturer.Text, Int32.Parse(quantity.Text), ingredientsDictionary, oldMedicine.IsAccepted,oldMedicine.WaitingForConfirmation, oldMedicine.IsDeleted, oldMedicine.ReasonForRejection);
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