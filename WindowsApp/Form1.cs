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
        string currnecy;
        NationalBankXmlData xml = new NationalBankXmlData();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy MM dd";
            dateTimePicker2.CustomFormat = "yyyy MM dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            int days = (date2 - date1).Days + 1;
            if (days < 1)
            {
                MessageBox.Show("Дата окончания не может быть меньше даты начала.");
                return;
            }
            if (DateTime.Now < date1 || date2 > DateTime.Now)
            {
                MessageBox.Show("Неправильный выбор даты.");
                return;
            }

            label3.Text = $"Вы выбрали диапазон в {days.ToString()} дня";
            currnecy = comboBox1.SelectedItem.ToString();
            chart1.Series.Add(currnecy);
            chart1.Series[currnecy].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[currnecy].IsValueShownAsLabel = true;
            chart1.Series[currnecy].Color = Color.Lime;
            chart1.Series[currnecy].BorderWidth = 3;
            chart1.Series[currnecy].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].BackColor = Color.LightYellow;

            string[] res = xml.GetDataArray(currnecy, date1, days);
            for (int i = 0; i < days; i++)
            {
                chart1.Series[currnecy].
                    Points.AddXY(date1.AddDays(i).ToString("dd.MM.yyyy"), res[i]);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;

            List<string> res2 = xml.GetCurrnecies(date1);
            res2.ToArray();

            for (int i = 0; i < res2.Count; i++)
            {
                comboBox1.Items.Add(res2[i]);
            }
        }
    }
}
