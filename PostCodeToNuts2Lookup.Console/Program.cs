using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace PostCodeToNuts2Lookup.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var postcodes = new List<Postcode>();
            var nsplData = new List<NSPL>();
            var lauData = new List<Lau>();
            var data = new List<Data>();
            
            
            
            using (var reader = new StreamReader("Data/PostCodes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var temp = csv.GetRecords<Postcode>();
                foreach (var r in temp)
                {
                    var p = new Postcode
                    {
                        PostCode = r.PostCode.ToUpper().Replace(" ", "")
                    };
                    postcodes.Add(p);
                    
                    System.Console.WriteLine(p.PostCode);
                }
            }
            
            using (var reader = new StreamReader("Data/NSPL.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var temp = csv.GetRecords<NSPL>().ToList();
                
                foreach (var r in temp)
                {
                    var nspl = new NSPL()
                    {
                        pcds = r.pcds.Replace(" ", "").ToUpper(),
                        nuts = r.nuts
                    };
                    
                    nsplData.Add(nspl);
                    
                    //Console.WriteLine(nspl.ToString());
                }
            }
            
            using (var reader = new StreamReader("Data/LAU2_to_LAU1_to_NUTS3_to_NUTS2_to_NUTS1" +
                                                 ".csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                lauData = csv.GetRecords<Lau>().ToList();
            }
            
            foreach (var postcode in postcodes)
            {
                var dataItem = new Data
                {
                    PostCode = postcode.PostCode,
                    Lau2 = nsplData.SingleOrDefault(x => x.pcds == postcode.PostCode)?.nuts,
                };

                dataItem.Code = lauData.SingleOrDefault(x => x.LAU217CD == dataItem.Lau2)?.NUTS218CD;
                
                data.Add(dataItem);
                
                System.Console.WriteLine(dataItem.ToString());
            }
            
            
            using (var writer = new StreamWriter("outputrawdata.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }

            var output = data
                .GroupBy(x => x.Code)
                .Select(x => new Output
                {
                    Code = x.Key,
                    Values = x.Count()
                });

            using (var writer = new StreamWriter("output.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(output);
            }
            
            System.Console.ReadKey();
        }
        
       
    }
}