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

        public List<Medicine> getAceppted()
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

        
    }
}

