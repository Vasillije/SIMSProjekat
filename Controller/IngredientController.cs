using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using VasilijeSIMS.Service;

namespace VasilijeSIMS.Controller
{
    internal class IngredientController
    {
        IngredientRepository ingredientRepository = new IngredientRepository();
        IngredientService ingredientService = new IngredientService();
        public bool UpdateMIngredient(Ingredient ingredient, Ingredient ingredientNew)
        {
            return ingredientService.UpdateIngredient(ingredient, ingredientNew);
        }
        public bool CreateIngredient(Ingredient i)
        {
            return ingredientService.CreateIngredient(i);
        }
    }
}
