using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;

namespace VasilijeSIMS.Repository
{
    public class MedicineRepository
    {
        private string path;

        public MedicineRepository()
        {
            path = @"..\..\..\data\Medicines.json";
        }


        //citanje iz fajla 
        public List<Medicine> ReadFromFile()
        {
            List<Medicine> medicines = new List<Medicine>();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    medicines = JsonConvert.DeserializeObject<List<Medicine>>(text);
                }
            }
            return medicines;
        }
        //upisivanje u fajl
        public void LoadIntoFile(List<Medicine> medicines)
        {
            JsonSerializer Serializer = new JsonSerializer();
            Serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(path);
            JsonWriter jWriter = new JsonTextWriter(writer);
            Serializer.Serialize(jWriter, medicines);
            jWriter.Close();
            writer.Close();
        }

        public List<Medicine> GetAceppted()
        {
            List<Medicine> aceptedMedicines = new List<Medicine>();
            List<Medicine> medicines = ReadFromFile();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.IsAccepted == true)
                {
                    aceptedMedicines.Add(medicine);
                }
            }
            return aceptedMedicines;
        }
        public List<User> getApprovedBy(Medicine medicine)
        {
            List<Medicine> medicines = ReadFromFile();
             foreach (Medicine i in medicines)
            {
                if (i.Id.Equals(medicine.Id))
                {
                    return i.ApprovedBy;   
                }
            }
            return null;
        }
       
            
        

        public List<Medicine> GetDeclined()
        {
            List<Medicine> declinedMedicines = new List<Medicine>();
            List<Medicine> medicines = ReadFromFile();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.IsAccepted == false && medicine.WaitingForConfirmation == false)
                {
                    declinedMedicines.Add(medicine);
                }
            }    
            return declinedMedicines;
        }
        
        public List<Medicine> GetAwaiting()
        {
            List<Medicine> medicines = ReadFromFile();
            List<Medicine> awaitingMedicines = new List<Medicine>();
            foreach (Medicine i in medicines)
            {
                if (i.WaitingForConfirmation == true)
                {
                    awaitingMedicines.Add(i);
                }
            }
            return awaitingMedicines;
        }
    }
}

