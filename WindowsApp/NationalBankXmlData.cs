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
        string connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=23.02.2009";

        public string[] GetCurrencyArray(DateTime date)
        {
            List<string> currncies = null;

            connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=" + date.ToString("dd.MM.yyyy");
            xDoc.Load(connection);
            xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                currncies.Add(GetData(date));
            }

            return currncies.ToArray();
        }

        public string[] GetDataArray(string currency, DateTime date, int days)
        {
            string[] result = new string[days];
            for (int i = 0; i < days; i++)
            {
                result[i] = GetData(date.AddDays(i), currency);
            }
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            return result;

        }

        public string GetData(DateTime date, string currency = null, bool IsName = false)
        {
            connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=" + date.ToString("dd.MM.yyyy");
            xDoc.Load(connection);
            xRoot = xDoc.DocumentElement;
            string result = "";
            bool exit = false;
            bool found = false;
            string searchItem = "description";
            if (IsName == true)
                searchItem = "fullname";
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
                        if (found && childNode.Name == searchItem)
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
    }
}
