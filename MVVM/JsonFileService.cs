using MVVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM
{
    internal class JsonFileService : IFileService
    {
        public List<Phone> Open(string filename)
        {
            filename += ".json";
            List<Phone> phones = new List<Phone>();
            DataContractJsonSerializer jsonFarmatter = new DataContractJsonSerializer(typeof(List<Phone>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFarmatter.ReadObject(fs) as List<Phone>;
            }
            return phones;
        }

        public void Save(string filename, List<Phone> phonesList)
        {
            filename += ".json";
            DataContractJsonSerializer jsonFarmatter = new DataContractJsonSerializer(typeof(List<Phone>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFarmatter.WriteObject(fs, phonesList);
            }
        }
    }
}