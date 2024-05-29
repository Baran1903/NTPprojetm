using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace uyg_1
{
    public partial class kullanicilar : Form
    {
        public kullanicilar()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
        private void kullanicilar_Load(object sender, EventArgs e)
        {
            goster();

        }

        public void button1_Click(object sender, EventArgs e)
        {

        }
        private void goster()
        {
            baglan.Open();
            OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM klnc", baglan);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            dataGridView1.DataSource = dt;
            baglan.Close();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yönlendirmesayfası vn = new yönlendirmesayfası();
            vn.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM klnc WHERE kullaniciAdi = '" + textBox1.Text + "'";

            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            textBox1.Clear();
            textBox2.Clear();
            
        }

        
    }
}
