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
    public partial class kullanici_liste : Form
    {
        public kullanici_liste()
        {
            InitializeComponent();
        }

        private void kullanici_liste_Load(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void fnk_liste_doldur()
        {

            string sql = "SELECT k_id as 'Kullanici No',k_adi as 'Kullanici Adi',k_sifre as 'Kullanici Sifre' FROM kullanici";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();


        }

        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kullaniciid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Kullanici No"].Value);
            kullanici_guncelle a = new kullanici_guncelle();
            a.k_id = kullaniciid;
            a.ShowDialog();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı");
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kullaniciid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Kullanici No"].Value);
            string sql = " delete from kullanici where k_id=" + kullaniciid;

            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            fnk_liste_doldur();
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT k_id as 'Kullanıcı No', k_adi as 'Kullanıcı', k_sifre as 'Kullanıcı Şifre' FROM kullanici  WHERE k_adi like '%" + textBox1.Text + "%' ";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
