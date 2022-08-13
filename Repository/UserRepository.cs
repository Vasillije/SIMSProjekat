using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasilijeSIMS.Model;

namespace VasilijeSIMS.Repository
{
    public class UserRepository
    {


        private string path;

        public UserRepository()
        {
            path = @"..\..\..\data\Users.json";
        }


        //citanje iz fajla 
        public List<User> ReadFromFile()
        {
            List<User> users = new List<User>();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(text);
                }
            }
            return users;
        }
        //upisivanje u fajl
        public void LoadIntoFile(List<User> users)
        {
            JsonSerializer Serializer = new JsonSerializer();
            Serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(path);
            JsonWriter jWriter = new JsonTextWriter(writer);
            Serializer.Serialize(jWriter, users);
            jWriter.Close();
            writer.Close();
        }
    }
}
