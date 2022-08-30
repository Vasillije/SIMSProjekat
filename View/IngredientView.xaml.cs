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
    /// Interaction logic for IngredientView.xaml
    /// </summary>
    public partial class IngredientView : Window
    {
        public ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public IngredientRepository ingredientRepository = new IngredientRepository();
        public IngredientView(Medicine medicine)
        {
            InitializeComponent();
            ingredients = new ObservableCollection<Ingredient>(medicine.ingredientDictionary.Values);
            ingredientsDataGrid.ItemsSource = showIngredients(ingredients);
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
    }
}
