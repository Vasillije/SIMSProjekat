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
        MedicineService medicineService = new MedicineService();
        public bool DeleteMedicine(Medicine medicine)
        {
            return medicineService.DeleteMedicine(medicine);
        }
        public bool CreateMedicine(Medicine user)
        {
            return medicineService.CreateMedicine(user);
        }
        public bool ApprovedByPharmacistCheck(Medicine user)
        {
            return medicineService.ApprovedByPharmacistCheck(user);
        }
        public bool ApprovedByDoctorCheck(Medicine user)
        {
            return medicineService.ApprovedByDoctorCheck(user);
        }
        public bool? AddToApprovedBy(Medicine m,User user)
        {
            return medicineService.AddToApprovedBy(m,user);
        }
        public bool ThreePeopleCheck(Medicine m)
        {
            return medicineService.ThreePeopleCheck(m);
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
