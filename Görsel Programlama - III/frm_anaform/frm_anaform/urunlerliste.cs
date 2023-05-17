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
    public partial class urunlerliste : Form
    {
        public urunlerliste()
        {
            InitializeComponent();
        }
        public void fnk_kategori()
        {
            string katagori = "SELECT * FROM katagori";
            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(katagori, baglan);
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
        public void fnk_urun_liste()
        {
            string sql = "SELECT urun.u_id as 'Ürün No',urun.u_adi as 'Ürün',katagori.uk_adi as 'Kategori',urun.u_fiyat as 'Fiyat',urun.u_stok as 'Stok' FROM urun LEFT JOIN katagori ON katagori.uk_id =urun.u_katagori";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void urunlerliste_Load(object sender, EventArgs e)
        {
            fnk_urun_liste();
            fnk_kategori();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO urun VALUES('" + textBox1.Text + "','" + Convert.ToInt32(comboBox1.SelectedValue) + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Ürün  Kayıt Edildi ");
            fnk_urun_liste();
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int u_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Ürün No"].Value);
            string sql = "DELETE FROM urun WHERE u_id =" + u_id;
            SqlConnection baglan = new SqlConnection(Form1.baglanti);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            MessageBox.Show("Ürün Silindi ");
            fnk_urun_liste();
            
        }

        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Ürün No"].Value);
            urun_guncelle ud = new urun_guncelle();
            ud.gelen_uid = m_id;
            ud.ShowDialog();
            fnk_urun_liste();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
