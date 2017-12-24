using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string quot = "\"";
            using (TextFieldParser tfp = new TextFieldParser("c:\\test.csv", Encoding.GetEncoding("Windows-1251")))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");
                tfp.HasFieldsEnclosedInQuotes = true;
                XElement root = new XElement("root");
                while (!tfp.EndOfData)
                {
                    string[] str = tfp.ReadFields();
                    XElement row = new XElement("Object",
                        new XElement("ID", str[0]), // str[0].Trim('\"')
                        new XElement("Name", str[1]),
                        new XElement("Activity", str[3]),
                        new XElement("Description", str[4].Replace("&#"," ")),
                        new XElement("MO", str[8]),
                        new XElement("Subject", str[9]),
                        new XElement("City", str[11]),
                        new XElement("Adress", str[13]),
                        new XElement("OKTMO", str[15]),
                        new XElement("Action",
                             new XElement("Type", str[17]),
                             new XElement("BeginDate", str[18]),
                             new XElement("EndDate", str[19])),
                        new XElement("Finance",
                             new XElement("TotalSum", str[20]),
                             new XElement("FederalInv", str[21]),
                             new XElement("FederalCons", str[22]),
                             new XElement("SubjectInv", str[23]),
                             new XElement("SubjectCons", str[24]),
                             new XElement("DepartInv", str[25]),
                             new XElement("DepartCons", str[26]),
                             new XElement("NoBudgetInv", str[27]),
                             new XElement("NoBudgetCons", str[28])),
                        new XElement("Key", str[29]),
                        new XElement("Supervisor",
                             new XElement("Name", str[30]),
                             new XElement("Adress", str[32]),
                             new XElement("Phone", str[34])),
                        new XElement("Phone", str[35]),
                        new XElement("Schedule",
                             new XElement("Weekdays", str[36]),
                             new XElement("Saturday", str[37]),
                             new XElement("Sunday", str[38])),
                        new XElement("Space", str[39]),
                        new XElement("Email", str[40]),
                        new XElement("URL", str[41]),
                        new XElement("InReg", str[42]),
                        new XElement("TypeObj", str[43]),
                        new XElement("Competitions",
                            from line in str[44].Split(',')
                            select new XElement("Competition",line)),
                        new XElement("SportList",
                            from sport in str[45].Split(',')
                            select new XElement("Sport",sport)));
                    root.Add(row);
                    
                }
                root.Save(Directory.GetCurrentDirectory() + "\\xmlout.xml");
                Console.ReadLine();
            }
        }
    }
}
