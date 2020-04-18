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

namespace Otell
{
    public partial class Musteri_Kayit : Form
    {
        public Musteri_Kayit()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }


        private void Musteri_Kayit_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from Kayit_Tbl ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Kayit_Tbl (Musteri_TC ,Musteri_Ad,Musteri_Soyad,Tel_no ) values (@tc,@ad,@soyad,@telefon_no)", baglantı);
            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@telefon_no", textBox4.Text);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Kayit_Tbl");
            baglantı.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from Kayit_Tbl where Musteri_TC=@tc ", baglantı);
            komut.Parameters.AddWithValue("@tc", textBox5.Text);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Kayit_Tbl");
            baglantı.Close();

            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from Kayit_Tbl where Musteri_Ad like '" + textBox6.Text + "%'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string Tc = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string Ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string Soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Tel = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();

            textBox1.Text = Tc;
            textBox2.Text = Ad;
            textBox3.Text = Soyad;
            textBox4.Text = Tel;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update Kayit_Tbl set Musteri_TC = '"+textBox1.Text+"',Musteri_Soyad='"+textBox3.Text+"',Tel_no='"+ textBox4.Text+"' where Musteri_Ad='"+textBox2.Text+"'" , baglantı);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Kayit_Tbl");
            baglantı.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }
    }
}
