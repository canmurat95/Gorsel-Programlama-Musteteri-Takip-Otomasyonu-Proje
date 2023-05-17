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
    public partial class kullanici_ekle : Form
    {
        public kullanici_ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            string sql_text = "insert into kullanici values('" + textBox1.Text + "','" + textBox2.Text + "')";
            baglan.Open();

            SqlCommand cmd = new SqlCommand(sql_text, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            MessageBox.Show("Kayıt İşlemi Gerçekleştirildi");
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_ekle_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
