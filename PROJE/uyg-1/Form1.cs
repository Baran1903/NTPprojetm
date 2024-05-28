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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
        // kayıt sayfası 
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("kayıt ol sayfasına gitmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo);
            kayitol ko = new kayitol();
            ko.Show();
            this.Hide();
        }
        // giriş 
        private void button3_Click(object sender, EventArgs e)
        {
           
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM klnc WHERE KullaniciAdi= '" + kullanici + "' AND Sifre = '" + sifre + "'", baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yönlendirmesayfası ys = new yönlendirmesayfası();
                ys.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
            }
            baglan.Close();

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifredegistirme sifredegistirme = new sifredegistirme();
            sifredegistirme.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayitol kayitol = new kayitol();
            kayitol.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        

       
    }
}
