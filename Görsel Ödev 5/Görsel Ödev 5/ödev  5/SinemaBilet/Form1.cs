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

namespace SinemaBilet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        //Veri tabanının bilgisayardaki dosya yolunu buraya giriyoruz.
        //Bilgisayar degiştigi zaman baglantı yolu güncellenmeli !!!!!!

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C: /Users/Monster/Desktop/Görsel Ödev /sinemabilet1 - 2003.mdb");

        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\Monster\Desktop\Görsel Ödev 5\sinemabilet1-2003.mdb"


        void koltuklistele()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From sinema", baglanti);
            da.Fill(dt);
            dataGridView3.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            koltuklistele();



        }

        private void btnBiletAyir_Click(object sender, EventArgs e)
        {
            OleDbCommand ekle = new OleDbCommand("insert into sinema ( koltuk_no, adı, soyadı,  seans, salon, film_adı ) ( @p1, @p2, @p3, @p4, @p5, @p6,)", baglanti);

            baglanti.Open();

            ekle.Parameters.AddWithValue("@p1", comboBox1);
            ekle.Parameters.AddWithValue("@p2", txtAdi);
            ekle.Parameters.AddWithValue("@p3", txtSoyadi);
            ekle.Parameters.AddWithValue("@p4", comboBox4);
            ekle.Parameters.AddWithValue("@p5", comboBox3);
            ekle.Parameters.AddWithValue("@p6", comboBox5);


            ekle.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kişinin bileti ayrılmıştır.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBilet_iptal_Click(object sender, EventArgs e)
        {


            OleDbCommand ekle = new OleDbCommand("delete from sinema ( koltuk_no, adı, soyadı,  seans, salon, film_adı ) ( @p1, @p2, @p3, @p4, @p5, @p6,)", baglanti);

            baglanti.Open();

            ekle.Parameters.AddWithValue("@p1", comboBox1);
            ekle.Parameters.AddWithValue("@p2", txtAdi);
            ekle.Parameters.AddWithValue("@p3", txtSoyadi);
            ekle.Parameters.AddWithValue("@p4", comboBox4);
            ekle.Parameters.AddWithValue("@p5", comboBox3);
            ekle.Parameters.AddWithValue("@p6", comboBox5);


            ekle.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kişinin bileti iptal edilmiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand ekle = new OleDbCommand("update from sinema ( koltuk_no, adı, soyadı,  seans, salon, film_adı ) ( @p1, @p2, @p3, @p4, @p5, @p6,)", baglanti);

            baglanti.Open();

            ekle.Parameters.AddWithValue("@p1", comboBox1);
            ekle.Parameters.AddWithValue("@p2", txtAdi);
            ekle.Parameters.AddWithValue("@p3", txtSoyadi);
            ekle.Parameters.AddWithValue("@p4", comboBox4);
            ekle.Parameters.AddWithValue("@p5", comboBox3);
            ekle.Parameters.AddWithValue("@p6", comboBox5);


            ekle.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Bilet düzenleme başarılı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
