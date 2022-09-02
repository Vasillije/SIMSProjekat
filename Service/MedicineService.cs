using DynamicExpresso;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public bool AddToApprovedBy(Medicine medicine, User user)
        {
            List<User> approved;
            Medicine newMedicine =medicine;
            approved = medicineRepository.GetApprovedBy(medicine);
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
            if (medicineRepository.GetApprovedBy(medicine).Count() >= 3)
            { 
                return true;
            }
            return false;                
        }
        public bool ApprovedByPharmacistCheck(Medicine medicine)
        {
            List<User> approved = new List<User>();
            List<User> pharmacist = new List<User>();
            approved = medicineRepository.GetApprovedBy(medicine);
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
            approved = medicineRepository.GetApprovedBy(medicine);
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

        public List<Medicine> SearchAccepted(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> foundMedicines = new List<Medicine>();
            List<Medicine> medicines = medicineRepository.GetAceppted();
            foreach (Medicine i in medicines)
            {
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) )
                {
                    foundMedicines.Add(i);
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
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) )
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

        public ObservableCollection<Medicine> SearchAcceptedIngredient(string tekst = "")
        {
           // if (tekst.Contains("&"))
            //{ }
            
            string[] tekst1 = tekst.Split('|');
            string[] koristiti;
            string[] tekst2 = tekst.Split('&');
            if (tekst1.Length >1)
            {
                koristiti = tekst1;
            }
            else 
            {
                koristiti = tekst2;
            }

                ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
                foreach (Medicine medicine in medicineRepository.GetAceppted())
                {
                    bool found = false;
                   

                    foreach (KeyValuePair<string, Ingredient> pair in (medicine.ingredientDictionary))
                    {
                        if (found )
                        {
                            break;
                        }
                    if (koristiti == tekst1)
                    {
                        foreach (string t in tekst1)
                        {
                            if (pair.Value.Name.Trim().ToLower().Contains(t.Trim().ToLower()))
                            {
                                medicines.Add(medicine);
                                found = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (string t in tekst2)
                        {
                            if (pair.Value.Name.Trim().ToLower().Contains(t.Trim().ToLower()))
                            {
                                medicines.Add(medicine);
                                found = true;
                                break;
                            }
                        }
                    }

                    }

                }
                return medicines;
            
        }

        public ObservableCollection<Medicine> SearchDeclinedIngredient(string tekst = "")
        {
            string[] tekst1 = tekst.Split('|');
            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicineRepository.GetDeclined())
            {
                bool found = false;

                foreach (KeyValuePair<string, Ingredient> pair in (medicine.ingredientDictionary))
                {
                    if (found)
                    {
                        break;
                    }

                    foreach (string t in tekst1)
                    {
                        if (pair.Value.Name.Contains(t) || pair.Value.Name.ToLower().Contains(t.ToLower()) || pair.Value.Name.ToUpper().Contains(t.ToUpper()))
                        {
                            medicines.Add(medicine);
                            found = true;
                            break;
                        }
                    }
                }
            }
            return medicines;
        }

        public ObservableCollection<Medicine> SearchAwaitingIngredient(string tekst = "")
        {
            string[] tekst1 = tekst.Split('|');
            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicineRepository.GetAwaiting())
            {
                bool found = false;

                foreach (KeyValuePair<string, Ingredient> pair in (medicine.ingredientDictionary))
                {
                    if (found)
                    {
                        break;
                    }

                    foreach (string t in tekst1)
                    {
                        if (pair.Value.Name.Contains(t) || pair.Value.Name.ToLower().Contains(t.ToLower()) || pair.Value.Name.ToUpper().Contains(t.ToUpper()))
                        {
                            medicines.Add(medicine);
                            found = true;
                            break;
                        }
                    }
                }
            }
            return medicines;
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
