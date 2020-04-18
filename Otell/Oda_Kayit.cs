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
    public partial class Oda_Kayit : Form
    {
        public Oda_Kayit()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from Oda_Tbl ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda_Tbl (Oda_No ,Giris_Tarihi,Cikis_Tarihi ) values (@oda_no,@giris_tarihi,@cikis_tarihi)", baglantı);
            komut.Parameters.AddWithValue("@oda_no", textBox1.Text);
            komut.Parameters.AddWithValue("@giris_tarihi", this.dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@cikis_tarihi", this.dateTimePicker2.Text);
           
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Oda_Tbl");
            baglantı.Close();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from Oda_Tbl where Oda_No=@oda_no ", baglantı);
            komut.Parameters.AddWithValue("@oda_no", textBox2.Text);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Oda_Tbl");
            baglantı.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from Oda_Tbl where Oda_No like '" + textBox1.Text + "%'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update Oda_Tbl set Oda_No = '" + textBox1.Text + "',Giris_Tarihi='" + this.dateTimePicker1.Text + "',Cikis_Tarihi='" + this.dateTimePicker2.Text + "' where Oda_No='" + textBox1.Text + "'", baglantı);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Oda_Tbl");
            baglantı.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
