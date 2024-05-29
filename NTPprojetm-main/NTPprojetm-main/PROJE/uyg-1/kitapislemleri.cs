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
    public partial class kitapislemleri : Form
    {
        public kitapislemleri()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
  
        void goster()
        {
            baglan.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Kitaplar", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);

            dataGridView1.DataSource = tablo;
            baglan.Close();
        
        
        
        
        }

        private void kitapislemleri_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Kitaplar (KitapAdı,Yazarı,Sayfası,Tema,Tür) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

            OleDbCommand komut = new OleDbCommand(sorgu,baglan);

            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Kitaplar WHERE KitapAdı = '" + textBox1.Text + "'";

            OleDbCommand komut = new OleDbCommand(sorgu,baglan);

            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Kitaplar SET Yazarı = '" + textBox2.Text + "', Sayfası = '" + textBox3.Text + "', Tema = '" + textBox4.Text + "' , Tür = '" + textBox5.Text + "' WHERE KitapAdı = '" + textBox1.Text + "'";

            OleDbCommand komut = new OleDbCommand(sorgu,baglan);

            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            goster();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yönlendirmesayfası vn = new yönlendirmesayfası();
            vn.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
