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
            TmpAndHmd paivita = new TmpAndHmd();
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather ORDER BY idweather DESC LIMIT 1");
            int b = paivita.GetVar();
            if (b == 1)
            {
                lampotila.Text = paivita.GetTmp() + "°C";
                ilmankosteus.Text = paivita.GetHmd() + "%";
                paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
                lampotilaAvg.Text = paivita.GetTmp() + "°C";
                ilmankosteusAvg.Text = paivita.GetHmd() + "%";               
            }
            else if (b == 0)
            {
                MessageBox.Show("No Data.");
                lampotila.Text = "-.-°C";
                ilmankosteus.Text = "-.-%";
                lampotilaAvg.Text = "-.-°C";
                ilmankosteusAvg.Text = "-.-%";
            }

        }
      
        private void Button1_Click_1(object sender, EventArgs e)
        {
            TmpAndHmd paivita = new TmpAndHmd();          
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            int b = paivita.GetVar();
            if (b == 1)
            {                
                lampotila.Text = paivita.GetTmp() + "°C";
                ilmankosteus.Text = paivita.GetHmd() + "%";
            }
            else if (b == 0)
            {                
                MessageBox.Show("No Data.");
                lampotila.Text = "-.-°C";
                ilmankosteus.Text = "-.-%";
                lampotilaAvg.Text = "-.-°C";
                ilmankosteusAvg.Text = "-.-%";
            }
        }
    
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { 
           
            string a = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            TmpAndHmd paivita = new TmpAndHmd();                      
            paivita.SetTmpAndHmd($"SELECT lampotila, ilmankosteus FROM weather WHERE paivamaara LIKE '{a}%' ");
            int b = paivita.GetVar();
            if (b == 1)
            {
            paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE paivamaara LIKE '{a}%' ");
            lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
            }
            else if (b == 0)
            {               
                MessageBox.Show("No data.");
                lampotilaAvgFromDate.Text = "-.-°C";
                ilmankosteusAvgFromDate.Text = "-.-%";
            }
            

        }

        private void aikavalidateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string c = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.SetTmpAndHmd2($"Select lampotila FROM weather WHERE paivamaara Like '{c}%' ");
        }
        public void SetTmpAndHmd2(string sql)
        {
            string cnnStr = @"Server = mysli.oamk.fi; Database = opisk_t8mios00;
                        User= t8mios00; Password = FPeRsNjALZXT22Xa";

            MySqlConnection cnn = new MySqlConnection(cnnStr);

            try
            {
                cnn.Open();


                MySqlCommand cmd = new MySqlCommand(sql, cnn);

                MySqlCommand selectData;
                selectData = cnn.CreateCommand();
                selectData.CommandText = sql;

                MySqlDataReader rdr = selectData.ExecuteReader();

                while (rdr.Read())
                {

                    lampotilaChart.Series["Temp"].Points.AddXY(rdr.GetDouble("lampotila"),rdr.GetString("aika"));
                }
                rdr.Close();


            }
            catch (Exception)
            {
                //MessageBox.Show("No data.");
            }
            cnn.Close();
            

        }
    }
}
    

public class TmpAndHmd 
{
    private string strValue1;
    private string strValue2;
    private int vari;
    
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
        return vari;
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

            
            MySqlCommand cmd = new MySqlCommand(sql, cnn);

            MySqlCommand selectData;
            selectData = cnn.CreateCommand();
            selectData.CommandText = sql;

            MySqlDataReader rdr = selectData.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    double lampoTila = (double)rdr["lampotila"];
                    double ilmanKosteus = (double)rdr["ilmankosteus"];
                    StrValue1 = lampoTila.ToString("N1");
                    StrValue2 = ilmanKosteus.ToString("N1");
                    vari = 1;                  
                }
                rdr.Close();
            }   
            else
            {
                vari = 0;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show("No data.");
        }
        cnn.Close();


    }

}
