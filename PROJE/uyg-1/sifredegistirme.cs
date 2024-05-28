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
    public partial class sifredegistirme : Form
    {
        public sifredegistirme()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
        OleDbCommand komut;
        OleDbDataAdapter da;

        void olustur()
        {
            baglan.Open();
            da = new OleDbDataAdapter("Select * From Kütüphane", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglan.Close();
        
     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            


           string tablo = ("Select * From klnc ");
           komut = new OleDbCommand(tablo, baglan);
           baglan.Open();
           OleDbDataReader okuyucu = komut.ExecuteReader();

           while (okuyucu.Read())
           {
               if (okuyucu.GetValue(0).ToString() == textBox1.Text && okuyucu.GetValue(1).ToString() == textBox4.Text)
               {
                   if (textBox2.Text == textBox3.Text)
                   {
                       string ya = "UPDATE klnc SET Sifre = '" + textBox2.Text + "' WHERE KullaniciAdi = '" + textBox1.Text + "'";
                       komut = new OleDbCommand(ya, baglan);
                       komut.ExecuteNonQuery();

                   }

               }               

           }
           baglan.Close();
           Form1 arda = new Form1();
           arda.Show();
           this.Hide();

        
            
        }

        private void sifredegistirme_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 sifre = new Form1();
            sifre.Show();
            this.Hide();
            
            
        }
    }
}
