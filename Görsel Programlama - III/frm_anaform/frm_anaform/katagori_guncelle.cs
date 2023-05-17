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
    public partial class katagori_guncelle : Form
    {
        public int uk_id;
        public katagori_guncelle()
        {
            InitializeComponent();
        }

        private void katagori_guncelle_Load(object sender, EventArgs e)
        {
            string sql = " select * from katagori where uk_id='" + uk_id + "' ";
            SqlConnection sqlconn = new SqlConnection(Form1.baglanti);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows == true)
            {
                textBox1.Text = Convert.ToString(rd["uk_adi"]);
             
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = " update katagori set uk_adi='" + textBox1.Text + "'  where m_id=" + uk_id;

            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            this.Close();
        }
    }
}
