using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for AddMedicineView.xaml
    /// </summary>
    public partial class AddMedicineView : Window
    {
        public MedicineController medicineController = new MedicineController();
        public IngredientRepository ingredientRepository = new IngredientRepository();
        public ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public AddMedicineView()
        {
            InitializeComponent();
            ingredients = new ObservableCollection<Ingredient>(ingredientRepository.ReadFromFile());
            ingredientsDataGrid.ItemsSource= ingredients;
        }

        public bool validation()
        {
            if (id.Text == null || name.Text == null || manufacturer.Text == null || quantity.Text == null)
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
            List<Ingredient> ingredientsList = IngredientsChecked();
            Dictionary<string, Ingredient> ingredientsDictionary = new Dictionary<string, Ingredient>();
            foreach (Ingredient i in ingredientsList)
            {
                ingredientsDictionary.Add( i.Name + "key", i);
                
            }
        

            if (validation() == true /*&& quantityValidation()==true*/)
            {
                
                
                Medicine newMedicine = new Medicine(id.Text, name.Text, manufacturer.Text, Int32.Parse( quantity.Text), ingredientsDictionary);
                medicineController.CreateMedicine(newMedicine);
            }
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
    }
}
