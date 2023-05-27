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

namespace HavayollariTakipUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //eski sürümde çalışabilmesi için oldedb 4.0 yapıldı.

            OleDbConnection baglan = new OleDbConnection("Provider=microsoft.jet.oledb.4.0; data source= vt.mdb");
            baglan.Open();

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            OleDbParameter[] pr = new OleDbParameter[7];
            pr[0] = new OleDbParameter("@ucusNo", textBox1.Text);
            pr[1] = new OleDbParameter("@yolcu_AdiSoyadi", textBox2.Text);
            pr[2] = new OleDbParameter("@tc_No", textBox3.Text);
            pr[3] = new OleDbParameter("@telefon_No", maskedTextBox1.Text);
            pr[4] = new OleDbParameter("@tarih", dateTimePicker1.Text);
            pr[5] = new OleDbParameter("@nereden", comboBox1.Text);
            pr[6] = new OleDbParameter("@nereye", comboBox2.Text);

            komut.Parameters.AddRange(pr);
            komut.CommandText = "insert into " +
                "Kisiler (UcusNo,Yolcu_AdiSoyadi,Tc_no,Telefon_no,Tarih,Nereden,Nereye) " +
                "values (@ucusNo,@yolcu_AdiSoyadi,@tc_No,@telefon_No,@tarih,@nereden,@nereye)";
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Başarılı , veriler kaydedildi!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection
                ("provider=microsoft.jet.oledb.4.0; data source=vt.mdb");
            baglan.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            OleDbParameter[] pr = new OleDbParameter[1];
            pr[0] = new OleDbParameter("@ucusNo", textBox5.Text);
            komut.Parameters.AddRange(pr);

            komut.CommandText = "delete from Kisiler where ucusNo=@ucusNo";
            komut.ExecuteNonQuery();
            baglan.Close();
            if (textBox5.Text == "")
            {
                MessageBox.Show("Veri bulunamadi :(");
            }
            else
            {
                MessageBox.Show("Tebrikler Veri Silindi");
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                maskedTextBox1.Text = "";
                dateTimePicker2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection
                ("provider=microsoft.jet.oledb.4.0; data source=vt.mdb");
            baglan.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            OleDbParameter[] pr = new OleDbParameter[1];
            pr[0] = new OleDbParameter("@ucusNo", textBox5.Text);
            komut.Parameters.AddRange(pr);

            komut.CommandText = "select * from Kisiler where ucusNo=@ucusNo";
            OleDbDataReader oku = default(OleDbDataReader);
            oku = komut.ExecuteReader(CommandBehavior.CloseConnection);
            if (oku.Read())
            {
                textBox5.Text = oku.GetValue(0).ToString();
                textBox6.Text = oku.GetValue(1).ToString();
                textBox7.Text = oku.GetValue(2).ToString();
                maskedTextBox2.Text = oku.GetValue(3).ToString();
                dateTimePicker2.Text = oku.GetValue(4).ToString();
                comboBox3.Text = oku.GetValue(5).ToString();
                comboBox4.Text = oku.GetValue(6).ToString();

            }
            else
            {
                MessageBox.Show("Herhangi bir veriye ulaşılamadı");
            }
            baglan.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection
                ("provider=microsoft.jet.oledb.4.0; data source=vt.mdb");
            baglan.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            OleDbParameter[] pr = new OleDbParameter[1];
            pr[0] = new OleDbParameter("@ucusNo", textBox9.Text);
            komut.Parameters.AddRange(pr);

            komut.CommandText = "select * from Kisiler where ucusNo=@ucusNo";
            OleDbDataReader oku = default(OleDbDataReader);
            oku = komut.ExecuteReader(CommandBehavior.CloseConnection);
            if (oku.Read())
            {
                textBox9.Text = oku.GetValue(0).ToString();
                textBox10.Text = oku.GetValue(1).ToString();
                textBox11.Text = oku.GetValue(2).ToString();
                maskedTextBox3.Text = oku.GetValue(3).ToString();
                dateTimePicker3.Text = oku.GetValue(4).ToString();
                comboBox5.Text = oku.GetValue(5).ToString();
                comboBox6.Text = oku.GetValue(6).ToString();

            }
            else
            {
                MessageBox.Show("Herhangi bir veriye ulaşılamadı");
            }
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=microsoft.jet.oledb.4.0; data source= vt.mdb");
            baglan.Open();

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            OleDbParameter[] pr = new OleDbParameter[7];
            pr[0] = new OleDbParameter("@ucusNo", textBox9.Text);
            pr[1] = new OleDbParameter("@yolcu_AdiSoyadi", textBox10.Text);
            pr[2] = new OleDbParameter("@tc_No", textBox11.Text);
            pr[3] = new OleDbParameter("@telefon_No", maskedTextBox3.Text);
            pr[4] = new OleDbParameter("@tarih", dateTimePicker3.Text);
            pr[5] = new OleDbParameter("@nereden", comboBox5.Text);
            pr[6] = new OleDbParameter("@nereye", comboBox6.Text);

            komut.Parameters.AddRange(pr);
            komut.CommandText = "update " +
                "Kisiler set ucusNo=@ucusNo,yolcu_AdiSoyadi=@yolcu_AdiSoyadi," +
                "tc_No=@tc_No,telefon_No=@telefon_No,tarih=@tarih,nereden=@nereden, nereye=@nereye " +
                "where ucusNo=@ucusNo ";
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Veriler Update Edildi!!");

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            maskedTextBox3.Text = "";
            dateTimePicker3.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            ff.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label22.Text = comboBox2.Text;
            comboBox2.Text = comboBox1.Text;
            comboBox1.Text = label22.Text;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            label22.Text = comboBox4.Text;
            comboBox4.Text = comboBox3.Text;
            comboBox3.Text = label22.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label22.Text = comboBox6.Text;
            comboBox6.Text = comboBox5.Text;
            comboBox5.Text = label22.Text;
        }
    }
}
