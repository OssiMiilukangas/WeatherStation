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
            lampotila.Text = paivita.GetTmp() + "°C";
            ilmankosteus.Text = paivita.GetHmd() + "%";
            paivita.SetTmpAndHmd("SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            lampotilaAvg.Text = paivita.GetTmp() + "°C";
            ilmankosteusAvg.Text = paivita.GetHmd() + "%";
        }
      
        private void Button1_Click_1(object sender, EventArgs e)
        {
            TmpAndHmd paivita = new TmpAndHmd();
            paivita.SetTmpAndHmd("SELECT lampotila, ilmankosteus FROM weather WHERE DATE(paivamaara) = CURDATE()");
            lampotila.Text = paivita.GetTmp() + "°C";
            ilmankosteus.Text = paivita.GetHmd() + "%";
        }

        private void dataHakuButton_Click(object sender, EventArgs e)
        {


            DateTime dDate;
            if (DateTime.TryParse(dayTextBox.Text, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            if (string.IsNullOrEmpty(dayTextBox.Text))
            {
                MessageBox.Show("Input Date.");
            }
           

            else
            {
                MessageBox.Show("Invalid Date.");

                TmpAndHmd paivita = new TmpAndHmd();
                    paivita.SetTmpAndHmd($"SELECT lampotila, ilmankosteus FROM weather WHERE paivamaara LIKE '{dayTextBox.Text}%' ");
                    lampotilaFromDate.Text = paivita.GetTmp() + "°C";
                    ilmankosteusFromDate.Text = paivita.GetHmd() + "%";
                    paivita.SetTmpAndHmd($"SELECT AVG (lampotila) AS lampotila, AVG (ilmankosteus) AS ilmankosteus FROM weather WHERE paivamaara LIKE '{dayTextBox.Text}%' ");
                    lampotilaAvgFromDate.Text = paivita.GetTmp() + "°C";
                    ilmankosteusAvgFromDate.Text = paivita.GetHmd() + "%";
                
                
            }
          
        }
       
    }
    
    }
public class TmpAndHmd : Form
{
    private string strValue1;
    private string strValue2;
    
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

            while (rdr.Read())
            {
                double lampoTila = (double)rdr["lampotila"];
                double ilmanKosteus = (double)rdr["ilmankosteus"];
                StrValue1 = lampoTila.ToString("N2");
                StrValue2 = ilmanKosteus.ToString("N2");
            }
            rdr.Close();


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        cnn.Close();


    }
   
}
