using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy MM dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date;// = new DateTime(2009, 2, 24);
            date = dateTimePicker1.Value;
            label1.Text = dateTimePicker1.Value.ToString();
            NationalBankXmlData xml = new NationalBankXmlData();
            string s;
            
            chart1.Series.Add("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА");
            chart1.Series["ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА"].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].BackColor = Color.LightYellow;
            for (int i = 0; i < 5; i++)
            {
                s = xml.GetData("ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА", date.AddDays(i));
                chart1.Series["ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА"].
                    Points.AddXY(date.AddDays(i).ToString("dd.MM.yyyy"), s);
                //Console.WriteLine(s + " " + date.AddDays(i));
            }
            
        }
    }
}
