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
    public partial class katagoriekle : Form
    {
        public katagoriekle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO katagori VALUES('" + textBox1.Text + "')";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Kategori Kayıt Edildi");
            
        }

        private void katagoriekle_Load(object sender, EventArgs e)
        {

        }
    }
}
