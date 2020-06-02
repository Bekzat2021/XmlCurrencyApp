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
            DateTime date = new DateTime(2009, 2, 23);
            NationalBankXmlData xml = new NationalBankXmlData();
            //string[] res = xml.GetDataArray("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА", date, 15);

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            List<string> res2 = xml.GetCurrnecies(date);

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
