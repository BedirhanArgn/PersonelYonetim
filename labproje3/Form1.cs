using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace labproje3
{
    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            vericek();
        }
        private void rbingbilgisi_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void vericek()
        {
            DataTable dt = new DataTable();
            if (File.Exists("stuff.csv"))
            {
                string[] satirlar = File.ReadAllLines("stuff.csv");
                string header = "ID,İsim,Soyadi,Adres,Aile,Akademik,Deneyim,Yöneticilik Görevi,Yabancı Dil,Çalışılan İl,Maas";
                if (satirlar.Length > 0)
                {
                    //string ilkSatir = satirlar[0];
                    string[] basliklar = header.Split(',');
                    foreach (string headerwords in basliklar)
                    {
                        dt.Columns.Add(new DataColumn(headerwords));
                    }

                    for (int i = 0; i < satirlar.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string[] veriler = satirlar[i].Split(',');
                        int indexer = 0;
                      
                            foreach (string headerword in basliklar)
                            {
                                dr[headerword] = veriler[indexer++];
                            }
                            dt.Rows.Add(dr);
                    }
                }
                else
                {
                    f2.dosyaolustur();
                }
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }


        private void btnduzenle_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



