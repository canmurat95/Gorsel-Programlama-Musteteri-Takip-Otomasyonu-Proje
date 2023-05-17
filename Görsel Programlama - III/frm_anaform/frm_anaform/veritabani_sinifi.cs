using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace frm_anaform
{
    class veritabani_sinifi
    {
        SqlConnection baglan = new SqlConnection(Form1.baglanti);
        SqlCommand command;
        SqlDataReader reader;
        public void girisyap(string ad, string sifre, Form frm1)
        {

            command = new SqlCommand("select*from kullanici where k_adi='" + ad + "' and k_sifre='" + sifre + "'", baglan);
        baglan.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giris Yapıldı");

                frm1.Hide();
                anaform a = new anaform();


        a.ShowDialog();
                Application.Exit();
                
            }
            else
            {


                MessageBox.Show("hatalı giris");
            }
baglan.Close();
            command.Dispose();
        }
    }
}
