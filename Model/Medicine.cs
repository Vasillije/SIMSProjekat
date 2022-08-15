using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasilijeSIMS.Model
{
    public class Medicine
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;

        public string Id { get; set; } //jedinstveno - sifra
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public Ingredient IngredientV { get; set; }
        public Boolean IsAccepted { get; set; }
        public Boolean WaitingForConfirmation { get; set; }
        public Boolean IsDeleted { get; set; }

        public Medicine(string id, string name, string manufacturer, int quantity, string iname, string idesc)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            IngredientV = new Ingredient(iname, idesc);
            IsAccepted = false;
            WaitingForConfirmation = true;
            IsDeleted = false;
        }

       
    }

}
