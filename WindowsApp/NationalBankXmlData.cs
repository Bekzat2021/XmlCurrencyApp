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
        public NationalBankXmlData()
        {
            
        }

        public string GetData(string currency, DateTime date)
        {
            string connection = "https://nationalbank.kz/rss/get_rates.cfm?fdate=" + date.ToString("dd.MM.yyyy");
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
                        {
                            found = true;
                        }
                        if (found)
                        {
                            if (childNode.Name == "description")
                            {
                                result = childNode.InnerText;
                                exit = true;
                                break;
                            }
                        }
                        
                    }
                }
            }
            return result;
        }
    }
}
