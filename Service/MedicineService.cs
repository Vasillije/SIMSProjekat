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

    }
}
