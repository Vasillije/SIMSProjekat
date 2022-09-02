using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;

namespace VasilijeSIMS.Service
{
    internal class IngredientService
    {
        public IngredientRepository ingredientRepository = new IngredientRepository();
        public bool CreateIngredient(Ingredient newI)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients = ingredientRepository.ReadFromFile();
            foreach (Ingredient i in ingredients)
            {
                if (i.Name.Equals(newI.Name))
                {
                    
                    return false;
                }
            }
            ingredients.Add(newI);
            ingredientRepository.LoadIntoFile(ingredients);
            return true;
        }
        public bool UpdateIngredient(Ingredient ingredientOld, Ingredient ingredientNew)
        {
            List<Ingredient> ingredients = ingredientRepository.ReadFromFile();
            foreach (Ingredient i in ingredients)
            {
                if (i.Name.Equals(ingredientOld.Name))
                {
                    ingredients.Remove(i);
                    ingredients.Add(ingredientNew);
                    ingredientRepository.LoadIntoFile(ingredients);
                    return true;
                }
            }
            return false;
        }    
    }
}
