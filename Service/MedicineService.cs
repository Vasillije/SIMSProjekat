using DynamicExpresso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VasilijeSIMS.Enums;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;

namespace VasilijeSIMS.Service
{
    public class MedicineService
    {
        public List<Medicine> medicines = new List<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
        public Ingredient ingredient;
        public bool DeleteMedicine(Medicine medicine)
        {
            medicines = medicineRepository.ReadFromFile();
            foreach(Medicine i in medicines)
            {
                if(i.Id == medicine.Id)
                {
                    medicines.Remove(i);
                    medicineRepository.LoadIntoFile(medicines);
                    return true;
                }
            }
        return false;
        }
       
        public Medicine? FindById(String id)
        {
            List<Medicine> medicines = medicineRepository.ReadFromFile();
            foreach (Medicine i in medicines)
            {
                if (i.Id == id)
                    return i;
            }
            return null;
        }
        public bool CreateMedicine(Medicine newM)
        {
            List<Medicine> medicines = new List<Medicine>();
            medicines = medicineRepository.ReadFromFile();
            foreach (Medicine i in medicines)
            {
                if (i.Id.Equals(newM.Id) )
                {
                    MessageBox.Show("This medicine already exists");
                    return false;
                }
            }
            medicines.Add(newM);
            medicineRepository.LoadIntoFile(medicines);
            return true;
        }
        public bool addToApprovedBy(Medicine medicine, User user)
        {
            List<User> approved;
            Medicine newMedicine =medicine;
            approved = medicineRepository.getApprovedBy(medicine);
            foreach (User i in approved)
            {
                if (i.Jmbg.Equals(user.Jmbg))
                {
                    
                MessageBox.Show("Alreaady approved by this user");
                return false;
                }
            }
                newMedicine.ApprovedBy.Add(user);
                UpdateMedicine(medicine, newMedicine);
                return true;
           
        }
        public bool UpdateMedicine(Medicine medicine, Medicine newMedicine)
        {
            List<Medicine> medicines = medicineRepository.ReadFromFile();
            foreach (Medicine i in medicines)
            {
                if (i.Id.Equals(medicine.Id))
                {
                    medicines.Remove(i);
                    medicines.Add(newMedicine);
                    medicineRepository.LoadIntoFile(medicines);
                    return true;
                }
            }
            return false;
        }
        public bool ThreePeopleCheck(Medicine medicine)
        {
            if (medicineRepository.getApprovedBy(medicine).Count() >= 3)
            { 
                return true;
            }
            return false;
                 
        }
        public bool ApprovedByPharmacistCheck(Medicine medicine)
        {
            List<User> approved = new List<User>();
            List<User> pharmacist = new List<User>();
            approved = medicineRepository.getApprovedBy(medicine);
            foreach (User i in approved)
            {
                if (i.TypeUser.Equals(UserType.Pharmacist))
                {
                    pharmacist.Add(i);
                }
            }
            if (pharmacist.Distinct().Count() >= 2)
            {
                return true;
            }
            return false;
        }
        public bool ApprovedByDoctorCheck(Medicine medicine)
        {
            List<User> approved = new List<User>();
            List<User> doctor = new List<User>();
            approved = medicineRepository.getApprovedBy(medicine);
            foreach (User i in approved)
            {
                if (i.TypeUser.Equals(UserType.Doctor))
                {
                    doctor.Add(i);
                }
            }
            if (doctor.Distinct().Count() >= 1)
            {
                return true;
            }
            return false;
        }

        public List<Medicine> SearchAccepted(string search/*, string from, string to*/)
        {
            string tekst = search.ToLower();
            List<Medicine> foundMedicines = new List<Medicine>();
            List<Medicine> medicines = medicineRepository.GetAceppted();
            foreach (Medicine i in medicines)
            {
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) || i.IngredientV.Name.ToString().ToLower().Contains(tekst))
                {
                    foundMedicines.Add(i);
                }
                else if (i.IngredientV.Name.ToString().ToLower().Contains(tekst))
                {
                    var variables = tekst.Split(new[] { "(", "||", "&&", ")", " " }, StringSplitOptions.RemoveEmptyEntries);

                    var interpreter = new Interpreter();

                    foreach (var variable in variables)
                    {
                        interpreter.SetVariable(variable, ingredient.Name.Contains(variable));
                    }
                    if ((bool)interpreter.Eval(tekst))
                    {
                        foundMedicines.Add(i);
                    }
                }
            }
            return foundMedicines;
        }

        public List<Medicine> SearchAcceptedQuantity(string from, string to)
        {
            string tekst1 = from.ToLower();
            string tekst2 = to.ToLower();
            List<Medicine> foundMedicines = new List<Medicine>();
            List<Medicine> medicines = medicineRepository.GetAceppted();
            foreach (Medicine i in medicines)
            {
                if (i.Quantity <= Int32.Parse(to) && i.Quantity >= Int32.Parse(from))
                {
                    foundMedicines.Add(i);
                }
            }
            return foundMedicines;
        }

        public List<Medicine> SearchDeclined(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> medicines = medicineRepository.GetDeclined();
            List<Medicine> foundMedicines = new List<Medicine>();
            foreach (Medicine i in medicines)
            {
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) || i.IngredientV.Name.ToString().ToLower().Contains(tekst))
                {
                    foundMedicines.Add(i);
                }
            }
            return foundMedicines;
        }

        public List<Medicine> SearchDeclinedQuantity(string from, string to)
        {
            string text1 = from.ToLower();
            string text2 = to.ToLower();
            List<Medicine> medicines = medicineRepository.GetDeclined();
            List<Medicine> foundMedicines = new List<Medicine>();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Quantity >= Int32.Parse(from) && medicine.Quantity <= Int32.Parse(to))
                {
                    foundMedicines.Add(medicine);
                }
            }
            return foundMedicines;
        }



        public List<Medicine> SearchAwaiting(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> medicines = medicineRepository.GetAwaiting();
            List<Medicine> foundMedicines = new List<Medicine>();
            foreach (Medicine i in medicines)
            {
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) )
                {
                    foundMedicines.Add(i);
                }
            }
            return foundMedicines;
        }

        public List<Medicine> SearchAwaitingQuantity(string from, string to)
        {
            string tekst1 = from.ToLower();
            string tekst2 = to.ToLower();
            List<Medicine> foundMedicines = new List<Medicine>();
            List<Medicine> medicines = medicineRepository.GetAwaiting();
            foreach (Medicine i in medicines)
            {
                if (i.Quantity <= Int32.Parse(to) && i.Quantity >= Int32.Parse(from))
                {
                    foundMedicines.Add(i);
                }
            }
            return foundMedicines;
        }
    }
}
