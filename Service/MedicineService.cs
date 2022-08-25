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
    public class MedicineService
    {
        public List<Medicine> medicines = new List<Medicine>();
        public MedicineRepository medicineRepository = new MedicineRepository();
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
                if (i.Id.Equals(newM.Id) && i.IngredientV.Name.Equals(newM.IngredientV.Name))
                {
                    MessageBox.Show("This medicine already exists");
                    return false;
                }
            }
            medicines.Add(newM);
            medicineRepository.LoadIntoFile(medicines);
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
        public List<Medicine> SearchAccepted(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> foundMedicines = new List<Medicine>();
            List<Medicine> medicines = medicineRepository.getAceppted();
            foreach (Medicine i in medicines)
            {
                if (i.Id.ToLower().Contains(tekst) || i.Name.ToLower().Contains(tekst) || i.Manufacturer.ToLower().Contains(tekst) || i.Quantity.ToString().ToLower().Contains(tekst) || i.IngredientV.Name.ToString().ToLower().Contains(tekst))
                {
                    foundMedicines.Add(i);
                }
            }
            return foundMedicines;
        }

        public List<Medicine> SearchDeclined(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> medicines = medicineRepository.ReadFromFile();
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

        public List<Medicine> SearchAwaiting(string search)
        {
            string tekst = search.ToLower();
            List<Medicine> medicines = medicineRepository.ReadFromFile();
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

    }
}
