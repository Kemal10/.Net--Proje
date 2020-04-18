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
    public partial class Listeleme : Form
    {
        public Listeleme()
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

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoster("SELECT  Kayit_Tbl.Musteri_Ad,Musteri_Soyad, Oda_Tbl.Oda_No,Giris_Tarihi,Cikis_Tarihi FROM Kayit_Tbl INNER JOIN Oda_Tbl ON Kayit_Tbl.Musteri_TC =  Oda_Tbl.Oda_ID  ");
        }
    }
}
