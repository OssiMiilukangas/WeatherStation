using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Timers;

namespace SaaAsema
{
  
    
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            Timeri();
            
        }

        private void Timeri()
        {            
            timer1.Interval = 20000;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += new EventHandler(update_Data);             
        }


        private void update_Data(object sender, EventArgs e)
        {           
            TmpAndHmd paivita = new TmpAndHmd();
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            if (paivita.GetVar() == 0)
            {
                lampotila.Text = paivita.GetTmp() + "°C";
                ilmankosteus.Text = paivita.GetHmd() + "%";
                paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
                lampotilaAvg.Text = paivita.GetTmp() + "°C";
                ilmankosteusAvg.Text = paivita.GetHmd() + "%";
            }

            else
            {
                MessageBox.Show("NoData");
            }
            timer1.Stop();
            timer1.Start();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            TmpAndHmd paivita = new TmpAndHmd();
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            if (paivita.GetVar() == 0)
            {
                lampotila.Text = paivita.GetTmp() + "°C";
                ilmankosteus.Text = paivita.GetHmd() + "%";
                paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
                lampotilaAvg.Text = paivita.GetTmp() + "°C";
                ilmankosteusAvg.Text = paivita.GetHmd() + "%";
            }

            else
            {
                MessageBox.Show("NoData");
            }
        }
    
        private void dateTimePicker1_DateChanged(object sender, EventArgs e)
        { 
           
            string a = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            TmpAndHmd paivita = new TmpAndHmd();                      
            SetTmpAndHmd2($"SELECT paivamaara, aika, lampotila, ilmankosteus FROM weather  WHERE paivamaara LIKE '{a}%' ");
            paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE paivamaara LIKE '{a}%' ");
            lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
            foreach (var series in lampotilaChart.Series)
            {
                series.Points.Clear();
            }
            SetTmpAndHmdGraph($"SELECT * FROM weather  WHERE paivamaara LIKE '{a}%' ");


        }
        public void SetTmpAndHmd2(string sql)
        {
            string cnnStr = @"Server = weatherstation.cpd96oxpry4s.us-east-1.rds.amazonaws.com; Database = WeatherStation;
                          User= t8mios00; Password = kahvia1234";

            MySqlConnection cnn = new MySqlConnection(cnnStr);

            try
            {
                cnn.Open();

                MySqlDataAdapter sqlDa = new MySqlDataAdapter(sql, cnn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                weatherDataGridView.DataSource = dtbl;
            }            
            catch (Exception)
            {
               MessageBox.Show("No data.");
                
            }           
            cnn.Close();
        }

        public void SetTmpAndHmdGraph(string sql)
        {
            string cnnStr = @"Server = weatherstation.cpd96oxpry4s.us-east-1.rds.amazonaws.com; Database = WeatherStation;
                          User= t8mios00; Password = kahvia1234";

            MySqlConnection cnn = new MySqlConnection(cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = new MySqlCommand();

                MySqlCommand selectData;
                selectData = cnn.CreateCommand();
                selectData.CommandText = sql;

                MySqlDataReader rdr = selectData.ExecuteReader();

                lampotilaChart.ChartAreas[0].AxisY.Minimum = -50;              
                lampotilaChart.ChartAreas[0].AxisY.Maximum = 50;
                lampotilaChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                lampotilaChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                lampotilaChart.ChartAreas[0].CursorX.AutoScroll = true;
                lampotilaChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;


                while (rdr.Read())
                {
                    lampotilaChart.Series["Lampotila"].Points.AddXY(rdr["aika"].ToString(), rdr.GetDouble("lampotila").ToString("00,00"));
                    lampotilaChart.Series["Ilmankosteus"].Points.AddXY(rdr["aika"].ToString(), rdr.GetDouble("ilmankosteus").ToString("00,00"));                                          
                }
                rdr.Close();                

            }
            catch (Exception)
            {
                MessageBox.Show("No Data.");
            }
            cnn.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            TmpAndHmd paivita = new TmpAndHmd();
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE() ORDER BY idweather");// DESC LIMIT 1");
            if (paivita.GetVar() == 0)
            {
                lampotila.Text = paivita.GetTmp() + "°C";
                ilmankosteus.Text = paivita.GetHmd() + "%";
                paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
                lampotilaAvg.Text = paivita.GetTmp() + "°C";
                ilmankosteusAvg.Text = paivita.GetHmd() + "%";
                paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
                lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
                ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
                SetTmpAndHmd2($"SELECT paivamaara, aika, lampotila, ilmankosteus FROM weather  WHERE DATE(paivamaara) = CURDATE()");
                SetTmpAndHmdGraph($"SELECT * FROM weather  WHERE  DATE(paivamaara) = CURDATE()");
            }
            else
            {
                MessageBox.Show("No Data.");
            }           
        }        
    }   
}
    

public class TmpAndHmd 
{
    private string strValue1;
    private string strValue2;
    private int var;

    public TmpAndHmd()
    {
       
    }

    public string GetTmp()
    {
        return strValue1;
    }

    public string GetHmd()
    {
        return strValue2;
    }
    public int GetVar()
    {
        return var;
    }
    public string StrValue2 { get => strValue2; set => strValue2 = value; }
    public string StrValue1 { get => strValue1; set => strValue1 = value; }
    public void SetTmpAndHmd(string sql)
    {
        string cnnStr = @"Server = weatherstation.cpd96oxpry4s.us-east-1.rds.amazonaws.com; Database = WeatherStation;
                          User= t8mios00; Password = kahvia1234";

        MySqlConnection cnn = new MySqlConnection(cnnStr);

        try
        {
            cnn.Open();

            MySqlCommand cmd = new MySqlCommand(sql);

            MySqlCommand selectData;
            selectData = cnn.CreateCommand();
            selectData.CommandText = sql;

            MySqlDataReader rdr = selectData.ExecuteReader();

            if (!rdr.HasRows)
            {
                var = 1;
            }
            else
            {
                var = 0;
            }
            
            while (rdr.Read())
            {
                double lampoTila = (double)rdr["lampotila"];
                double ilmanKosteus = (double)rdr["ilmankosteus"];
                StrValue1 = lampoTila.ToString("N1");
                StrValue2 = ilmanKosteus.ToString("N1");

            }     
            rdr.Close();
        }

        catch (Exception)
        {
           // MessageBox.Show("No data.");
        }
        cnn.Close();


    }


}
