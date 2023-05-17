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
    public partial class musteri_liste : Form
    {
        public musteri_liste()
        {
            InitializeComponent();
        }
        public void fnk_musteri_listele()
        {
            string sql = ("SELECT m_id as 'Müşteri No',m_adsoyad as 'Müşteri',m_tel as 'Telefon', m_adres as 'Adres',m_firma as 'Firma' FROM musteri");
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void musteri_liste_Load(object sender, EventArgs e)
        {
            fnk_musteri_listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int musteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Müşteri No"].Value);
            musteri_guncelle a = new musteri_guncelle();
           a.g_m_id = musteriID;
            a.ShowDialog();
            fnk_musteri_listele();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int musteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Müşteri No"].Value);
            string sql = "DELETE FROM musteri WHERE m_id=" + musteriID;
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Silme işlemi Tamamlandı");
            fnk_musteri_listele();
        }

        private void textBox_arama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
