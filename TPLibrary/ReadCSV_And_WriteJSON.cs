using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TPLibrary
{
    public class ReadCSV_And_WriteJSON
    {
        public static void Implement_CSVToJSON()
        {
            string importfilepath = @"E:\RFP\ThirdpartyLibrary\TPLibrary\Files\Jsondata.csv";
            string exportfilepath = @"E:\RFP\ThirdpartyLibrary\TPLibrary\Files\export.json";

            using (var reader = new StreamReader(importfilepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine(addressData.firstname + "\t" + addressData.lastname + "\t" + addressData.address + "\t" + addressData.city + "\t" + addressData.state + "\t" + addressData.code + "\n");
                }
                Console.WriteLine("Now reading from csv file and write to json file");

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportfilepath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
