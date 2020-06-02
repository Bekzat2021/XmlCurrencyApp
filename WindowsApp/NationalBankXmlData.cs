using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsApp
{
    public class NationalBankXmlData
    {
        XmlDocument xDoc = new XmlDocument();
        XmlElement xRoot;
        string connection; 

        public string[] GetDataArray(string currency, DateTime date, int days)
        {
            string[] result = new string[days];
            
            for (int i = 0; i < days; i++)
                result[i] = GetData(date.AddDays(i), currency);
            
            return result;
        }

        public string GetData(DateTime date, string currency)
        {
            connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=" + date.ToString("dd.MM.yyyy");
            xDoc.Load(connection);
            xRoot = xDoc.DocumentElement;

            string result = "";

            bool exit = false;
            bool found = false;

            foreach (XmlNode xnode in xRoot)
            {
                if (exit)
                    break;
                if (xnode.Name == "item")
                {
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.InnerText == currency)
                            found = true;
                        if (found && childNode.Name == "description")
                        {
                            result = childNode.InnerText;
                            exit = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public List<string> GetCurrnecies(DateTime date)
        {
            connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=" + date.ToString("dd.MM.yyyy");
            xDoc.Load(connection);
            xRoot = xDoc.DocumentElement;
            List<string> result = new List<string>();
            
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "item")
                {
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "fullname")
                        {
                            result.Add(childNode.InnerText);
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
