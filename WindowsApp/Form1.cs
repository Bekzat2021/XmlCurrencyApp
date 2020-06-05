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
        List<Color> existedColors = new List<Color>();
        NationalBankXmlData xml = new NationalBankXmlData();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy MM dd";
            dateTimePicker2.CustomFormat = "yyyy MM dd";
        }

        public Color GiveRandomColor()
        {
            Random random = new Random();

            Color color = new Color();
            while (true)
            {
                color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

                if (existedColors.Count < 1)
                    existedColors.Add(color);
                else if (!existedColors.Contains(color))
                    break;
            }
            return color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime beginDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            int days = (endDate - beginDate).Days + 1;
            if (CheckDate(beginDate, endDate, days) == false)
                return;

            label3.Text = $"Вы выбрали диапазон в {days.ToString()} дня";
            string currnecy = comboBox1.SelectedItem.ToString();
            SetChart1Settings(currnecy);
            FillChart1(currnecy, beginDate, endDate, days);
        }

        private void FillChart1(string currency, DateTime beginDate, DateTime endDate, int days)
        {
            string[] res = xml.GetDataArray(currency, beginDate, days);
            for (int i = 0; i < days; i++)
            {
                chart1.Series[currency].
                    Points.AddXY(beginDate.AddDays(i).ToString("dd.MM.yyyy"), res[i]);
            }
        }

        private bool CheckDate(DateTime beginDate, DateTime endDate, int days)
        {
            if (days < 1)
            {
                MessageBox.Show("Дата окончания не может быть меньше даты начала.");
                return false;
            }
            if (DateTime.Now < beginDate || endDate > DateTime.Now)
            {
                MessageBox.Show("Неправильный выбор даты.");
                return false;
            }
            return true;
        }

        private void SetChart1Settings(string currnecy)
        {
            chart1.Series.Add(currnecy);
            chart1.Series[currnecy].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[currnecy].IsValueShownAsLabel = true;
            chart1.Series[currnecy].Color = GiveRandomColor();
            chart1.Series[currnecy].BorderWidth = 3;
            chart1.Series[currnecy].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].BackColor = Color.LightYellow;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
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
