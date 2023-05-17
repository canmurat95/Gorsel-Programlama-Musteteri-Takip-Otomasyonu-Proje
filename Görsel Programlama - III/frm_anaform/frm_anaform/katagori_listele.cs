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
    public partial class katagori_listele : Form
    {
        public katagori_listele()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void fnk_liste_doldur()
        {

            string sql = " select uk_id as 'Katagori No' , uk_adi as 'Katagori Adi' " + " from katagori";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();


        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int katagoriid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Katagori No"].Value);
            katagori_guncelle a = new katagori_guncelle();
            a.uk_id = katagoriid;
            a.ShowDialog();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı");
        }

        private void katagori_listele_Load(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int katagoriid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Katagori No"].Value);
            string sql = " delete from katagori where uk_id=" + katagoriid;

            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            fnk_liste_doldur();
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT uk_id as 'Kategori No',uk_adi as 'Kategori' FROM katagori WHERE uk_adi like '%" + textBox1.Text + "%' ";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
