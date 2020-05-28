using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp;

namespace JustText
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2020, 2, 21);
            NationalBankXmlData xml = new NationalBankXmlData();
            string[] res = xml.GetDataArray("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА", date, 15);
        }
    }
}
