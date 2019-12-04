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

namespace SaaAsema
{
  
    
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
                    
        }
      
        private void Button1_Click_1(object sender, EventArgs e)
        {
            TmpAndHmd paivita = new TmpAndHmd();          
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");                 
            lampotila.Text = paivita.GetTmp() + "°C";
            ilmankosteus.Text = paivita.GetHmd() + "%";
            paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            lampotilaAvg.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvg.Text = paivita.GetHmd() + "%";
        }
    
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { 
           
            string a = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            TmpAndHmd paivita = new TmpAndHmd();                      
            //paivita.SetTmpAndHmd($"SELECT lampotila, ilmankosteus FROM weather WHERE paivamaara LIKE '{a}%' ");
            this.SetTmpAndHmd2($"SELECT paivamaara, aika, lampotila, ilmankosteus FROM weather  WHERE paivamaara LIKE '{a}%' ");


            paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE paivamaara LIKE '{a}%' ");
            lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
                                                  
        }
        public void SetTmpAndHmd2(string sql)
        {
            string cnnStr = @"Server = mysli.oamk.fi; Database = opisk_t8mios00;
                          User= t8mios00; Password = FPeRsNjALZXT22Xa";
           
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
               //MessageBox.Show("No data.");
                
            }           
            cnn.Close();
        }
/*
        public void SetTmpAndHmdGraph()
        {
            string cnnStr = @"Server = mysli.oamk.fi; Database = opisk_t8mios00;
                          User= t8mios00; Password = FPeRsNjALZXT22Xa";

            MySqlConnection cnn = new MySqlConnection(cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = new MySqlCommand();

                MySqlCommand selectData;
                selectData = cnn.CreateCommand();
                string query = "Select * FROM weather WHERE  paivamaara LIKE '2019-12-03%' ";
                selectData.CommandText = query;

                MySqlDataReader rdr = selectData.ExecuteReader();

                while (rdr.Read())
                {
                    lampotilaChart.Series["lampotila"].Points.AddXY(rdr["aika"].ToString(), rdr.GetDouble("lampotila").ToString("00,00"));            
                    lampotilaChart.Series["ilmankosteus"].Points.AddXY(rdr["aika"].ToString(), rdr.GetDouble("ilmankosteus").ToString("00,00"));                    
                }
                rdr.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("No Data.");
            }
            cnn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.SetTmpAndHmdGraph();           
        }
        */
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
            }
            else
            {
                MessageBox.Show("No Data.");
            }

            paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
            this.SetTmpAndHmd2($"SELECT paivamaara, aika, lampotila, ilmankosteus FROM weather  WHERE DATE(paivamaara) = CURDATE()");
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
        string cnnStr = @"Server = mysli.oamk.fi; Database = opisk_t8mios00;
                        User= t8mios00; Password = FPeRsNjALZXT22Xa";

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
            MessageBox.Show("No data.");
        }
        cnn.Close();


    }


}
