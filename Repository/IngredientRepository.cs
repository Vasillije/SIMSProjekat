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


        //citanje iz fajla 
        public List<Ingredient> ReadFromFile()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(text);
                }
            }
            return ingredients;
        }
        //upisivanje u fajl
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
    }
}
