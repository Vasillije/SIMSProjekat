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
        //public IDictionary<int, Ingredient> IngredientV { get; set; }
        public Dictionary<string, User> ingredient { get; set; }
       // new Dictionary<string, User>();
        public Ingredient IngredientV { get; set; }
        public Boolean IsAccepted { get; set; }
        public Boolean WaitingForConfirmation { get; set; }
        public Boolean IsDeleted { get; set; }
        public User DeclinedBy { get; set; }
        public List<User> ApprovedBy { get; set; }
        public DateTime ProcurementDate { get; set; }



        public string ReasonForRejection { get; set; }

        public Medicine(string id, string name, string manufacturer, int quantity, string iname, string idesc)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            //IngredientV = new Dictionary<int, Ingredient>();
            IngredientV = new Ingredient(iname, idesc);
            IsAccepted = false;
            WaitingForConfirmation = true;
            IsDeleted = false;
            ReasonForRejection = "";
            DeclinedBy = null;
            ApprovedBy = new List<User>();
            ProcurementDate= new DateTime();

        }
        public Medicine(string id, string name, string manufacturer, int quantity, string iname, string idesc, Boolean isAccepted, Boolean WFC,Boolean isDeleted, string reasonForRejection)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            //IngredientV =new Dictionary<int, Ingredient>();
            IngredientV = new Ingredient(iname, idesc);
            IsAccepted = isAccepted;
            WaitingForConfirmation = WFC;
            IsDeleted = isDeleted;
            ReasonForRejection = reasonForRejection;
            DeclinedBy = null;
            ApprovedBy = new List<User>();
            ProcurementDate = new DateTime();
        }
        public Medicine(string id, string name, string manufacturer, int quantity, string iname, string idesc, Boolean isAccepted, Boolean WFC, Boolean isDeleted, string reasonForRejection, User user)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            //IngredientV =new Dictionary<int, Ingredient>();
            IngredientV = new Ingredient(iname, idesc);
            IsAccepted = isAccepted;
            WaitingForConfirmation = WFC;
            IsDeleted = isDeleted;
            ReasonForRejection = reasonForRejection;
            DeclinedBy = user;
            ApprovedBy = new List<User>();
            ProcurementDate = new DateTime();
        }

        public Medicine()
        {
        }
    }

}
