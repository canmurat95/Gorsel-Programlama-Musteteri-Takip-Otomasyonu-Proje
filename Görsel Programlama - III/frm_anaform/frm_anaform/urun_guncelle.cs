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
    public partial class urun_guncelle : Form
    {
        public urun_guncelle()
        {
            InitializeComponent();
        }
        public int gelen_uid;
        public void fnk_kategori()
        {
            string kategori = "SELECT * FROM katagori";
            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(kategori, baglan);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "uk_adi";
            comboBox1.ValueMember = "uk_id";
            baglan.Close();
        }

        private void urun_guncelle_Load(object sender, EventArgs e)
        {
            fnk_kategori();
            string sql = "SELECT * FROM urun where u_id =" + gelen_uid;
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true)
            {
                comboBox1.SelectedValue = Convert.ToString(dr["u_katagori"]);
                textBox1.Text = Convert.ToString(dr["u-adi"]);
                textBox2.Text = Convert.ToString(dr["u_fiyat"]);
                textBox3.Text = Convert.ToString(dr["u_stok"]);
            }
            else
            {
                MessageBox.Show("Ürün Kaydı Bulunamadı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            string sql = "UPDATE urun SET u_adi='" + textBox1.Text + "',u_katagori='" + Convert.ToInt32(comboBox1.SelectedValue) + "',u_fiyat='" + textBox2.Text + "',u_stok='" + textBox3.Text + "' WHERE u_id =" + gelen_uid;
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            MessageBox.Show(" Bilgiler Güncellendi");
            this.Close();
        }
    }
}
