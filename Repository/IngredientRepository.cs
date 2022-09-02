using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;

namespace VasilijeSIMS.Repository
{
    public class IngredientRepository
    {
        private string path;

        public IngredientRepository()
        {
            path = @"..\..\..\data\Ingredients.json";
        }

        public List<Ingredient> ReadFromFile()
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    Ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(text);
                }
            }
            return Ingredients;
        }

        public void LoadIntoFile(List<Ingredient> ingredients)
        {
            JsonSerializer Serializer = new JsonSerializer();
            Serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(path);
            JsonWriter jWriter = new JsonTextWriter(writer);
            Serializer.Serialize(jWriter, ingredients);
            jWriter.Close();
            writer.Close();
        }
        public List<Ingredient> GetChecked()
        {
            List<Ingredient> checkedIngredients = new List<Ingredient>();
            List<Ingredient> ingredients = ReadFromFile();
            foreach (Ingredient i in ingredients)
            {
                if (i.IsChecked == true)
                {
                    checkedIngredients.Add(i);
                }
            }
            return checkedIngredients;
        }

    }
}
