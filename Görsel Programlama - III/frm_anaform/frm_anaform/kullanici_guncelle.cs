using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frm_anaform
{
    public partial class kullanici_guncelle : Form
    {
        public int k_id;
        
        public kullanici_guncelle()
        {
            InitializeComponent();
        }

        private void kullanici_guncelle_Load(object sender, EventArgs e)
        {
            string sql = " select * from kullanici where k_id='" + k_id + "' ";
            SqlConnection sqlconn = new SqlConnection(Form1.baglanti);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows == true)
            {
                textBox1.Text = Convert.ToString(rd["k_adi"]);
                textBox2.Text = Convert.ToString(rd["k_sifre"]);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = " update kullanici set k_adi='" + textBox1.Text + "' , " +
" k_sifre='" + textBox2.Text + "'  where k_id=" + k_id;

            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
