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
            DateTime date = new DateTime(2009, 2, 24);
            NationalBankXmlData xml = new NationalBankXmlData();
            string s;
            Console.WriteLine("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА");
            for (int i = 0; i < 5; i++)
            {
                s = xml.GetData("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА", date.AddDays(i));
                Console.WriteLine(s + " " + date.AddDays(i));
            }
        }
    }
}
