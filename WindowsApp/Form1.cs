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
        string currnecy = "АВСТРАЛИЙСКИЙ ДОЛЛАР";
        NationalBankXmlData xml = new NationalBankXmlData();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy MM dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value;
            string s;
            
            chart1.Series.Add(currnecy);
            chart1.Series[currnecy].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[currnecy].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].BackColor = Color.LightYellow;
            for (int i = 0; i < 5; i++)
            {
                s = xml.GetData(currnecy, date.AddDays(i));
                chart1.Series[currnecy].
                    Points.AddXY(date.AddDays(i).ToString("dd.MM.yyyy"), s);
            }

        }
    }
}
