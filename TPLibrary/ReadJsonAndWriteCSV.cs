using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


namespace TPLibrary
{
    public class ReadJsonAndWriteCSV
    {
        public static void ImplementJSONToCSV()
        {
            string importFilePath = @"E:\RFP\ThirdpartyLibrary\TPLibrary\Files\export.json";
            string exportFilePath = @"E:\RFP\ThirdpartyLibrary\TPLibrary\Files\Jsondata.csv";

            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));

            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressData);
            }
        }
    }
}
