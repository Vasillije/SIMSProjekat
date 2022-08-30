using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasilijeSIMS.Model
{
    public class Ingredient
    {
        public string Name { get; set; } //jedinstveno
        public string Description { get; set; }
        public Boolean IsChecked { get; set; }

        public Ingredient(string name, string description, bool isChecked)
        {
            Name = name;
            Description = description;
            IsChecked = isChecked;
        }
    }
}
