using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;
using VasilijeSIMS.Repository;
using VasilijeSIMS.Service;


namespace VasilijeSIMS.Controller
{
    public class MedicineController
    {
        MedicineRepository medicineRepository = new MedicineRepository();
        MedicineService medicineService = new MedicineService();
        public bool DeleteMedicine(Medicine medicine)
        {
            return medicineService.DeleteMedicine(medicine);
        }
        public bool CreateMedicine(Medicine user)
        {
            return medicineService.CreateMedicine(user);
        }
        public Medicine FindById(String id)
        {
            return medicineService.FindById(id);
        }
        public bool UpdateMedicine(Medicine medicine, Medicine newMedicine)
        {
            return medicineService.UpdateMedicine( medicine,  newMedicine);
        }
    }
}
