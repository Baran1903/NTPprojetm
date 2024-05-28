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
            göster();

        }

        public void button1_Click(object sender, EventArgs e)
        {

        }
        private void göster()
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yönlendirmesayfası vn = new yönlendirmesayfası();
            vn.Show();
            this.Hide();
        }
    }
}
