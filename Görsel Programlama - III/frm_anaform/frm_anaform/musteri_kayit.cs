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
    public partial class musteri_kayit : Form
    {
        public musteri_kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = ("INSERT INTO musteri VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')");

            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Müşteri Eklendi");
            Close();
        }

        private void musteri_kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
