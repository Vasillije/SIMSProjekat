using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasilijeSIMS.Model
{
    public class Medicine
    {  
        public string Id { get; set; } //jedinstveno - sifra
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public Ingredient IngredientV { get; set; }
        public Boolean IsAccepted { get; set; }
      //  public Boolean WaitingForConfirmation { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
