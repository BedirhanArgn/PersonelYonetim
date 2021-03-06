﻿using System;
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
using Newtonsoft.Json;
namespace labproje3
{
    public partial class Form1 : Form
    {
        int listeninboyutu = 0;
        int sayac = 0;
        int[] PersonelList;
        string[] IsciBilgileri = new string[100];
        List<jsonclass> json = new List<jsonclass>(); 
        int[] maasdizi = new int[100];
        string[] veriler = new string[100];
        string sJSONResponse;
        Form2 f2 = new Form2();
        public static string yol = "stuff.csv";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            vericek();
            kisisayisibul();
        }
        private void rbingbilgisi_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void vericek()
        {
            sayac++;
            listeninboyutu = 0;
         
            DataTable dt = new DataTable();
            if (File.Exists(Yol))
            {
                string[] satirlar = File.ReadAllLines(Yol);
                string header = "ID,İsim,Soyadi,Adres,Maas,Akademik,Deneyim,Yöneticilik Görevi,Yabancı Dil,Çalışılan İl,Aile";
                if(sayac==2)
                {
                    json.Clear();
                    sJSONResponse = "";
                }
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
                        listeninboyutu++;
                        DataRow dr = dt.NewRow();
                        string[] veriler = satirlar[i].Split(',');
                        
                            json.Add(new jsonclass { Id = veriler[0], Adi = veriler[1], Soyadi = veriler[2],Adresi=veriler[3],Maas = veriler[4], Akademik = veriler[5], Deneyimm = veriler[6], Yongorev = veriler[7], Yabancidill = veriler[8], Il = veriler[9], Aile = veriler[10] });
                        
                        IsciBilgileri[i] = satirlar[i];
                        int indexer = 0;
                        foreach (string headerword in basliklar)
                        {

                            dr[headerword] = veriler[indexer++];
                        }
                        dt.Rows.Add(dr);
                    }                                       
                    sJSONResponse = JsonConvert.SerializeObject(json);                 

                    PersonelList = new int[listeninboyutu];
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                }
            }
            else
            {
                f2.dosyaolustur();
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            PersonelList = new int[listeninboyutu];

        }
        private void btnduzenle_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        public void kisisayisibul()
        {
            DataTable dt = new DataTable();
            if (File.Exists(Yol))
            {
                string[] satirlar = File.ReadAllLines(Yol);
                string header = "ID,İsim,Soyadi,Adres,Maas,Akademik,Deneyim,Yöneticilik Görevi,Yabancı Dil,Çalışılan İl,Aile";

                if (satirlar.Length > 0)
                {
                    //string ilkSatir = satirlar[0];
                    string[] basliklar = header.Split(',');
                    for (int i = 0; i < satirlar.Length; i++)
                    {
                        string[] veriler = satirlar[i].Split(',');
                        PersonelList[i] = Int32.Parse(veriler[4]);
                    }
                }
            }
        }
        private void btncsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Dosyayı Seçin";
            open.Filter = "Text File|*.csv";
            if (open.ShowDialog() == DialogResult.OK)
            {
                yol = open.FileName;
                vericek();
            }
            //if (File.Exists(yol))
            //{

            //    yol = open.FileName;
            //    vericek();
            //}
        }
        public string Yol
        {
            get { return yol; }
            set { yol = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kisisayisibul();

            dataGridView1.DataSource = null;
          
            PersonelList = MergeSort(PersonelList);
            for (int i = 0; i < PersonelList.Count(); i++)
            {
                string[] maas = IsciBilgileri[i].Split(',');
                maasdizi[i] = Convert.ToInt32(maas[4]);
            }


            for (int i = 0; i < PersonelList.Count(); i++)
            {


                for (int j = 0; j < PersonelList.Count(); j++)
                {
                    if (PersonelList[i] == maasdizi[j])
                    {
                        veriler[i] = (IsciBilgileri[j].ToString());
                    }

                }

            }
            DataTable dt = new DataTable();
            List<string> veriler3 = veriler.OfType<string>().ToList();
            if (veriler.Count() > 0)
            {
                //string ilkSatir = satirlar[0];
                string header = "ID,İsim,Soyadi,Adres,Maas,Akademik,Deneyim,Yöneticilik Görevi,Yabancı Dil,Çalışılan İl,Aile";
                string[] basliklar = header.Split(',');
                foreach (string headerwords in basliklar)
                {
                    dt.Columns.Add(new DataColumn(headerwords));
                }
                for (int i = 0; i < veriler3.Count(); i++)
                {

                    DataRow dr = dt.NewRow();
                    string[] veriler2 = veriler3[i].Split(',');
                    int indexer = 0;
                    foreach (string headerword in basliklar)
                    {
                        dr[headerword] = veriler2[indexer++];
                    }
                    dt.Rows.Add(dr);
                }

            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
        public int[] MergeSort(int[] Personel)
        {
            int[] Left;
            int[] Right;
            int[] Result = new int[Personel.Count()];

            if (Personel.Count() <= 1)
            {
                return Personel;
            }

            int midPoint = Personel.Count() / 2;
            Left = new int[midPoint];
            if (Personel.Count() % 2 == 0)
                Right = new int[midPoint];
            else
            {
                Right = new int[midPoint + 1];

            }
            for (int i = 0; i < midPoint; i++)
            {

                Left[i] = Personel[i];
            }
            int x = 0;
            for (int i = midPoint; i < Personel.Count(); i++)
            {
                Right[x] = Personel[i];
                x++;
            }
            Left = MergeSort(Left);
            //Recursively sort the right array  
            Right = MergeSort(Right);
            //Merge our two sorted arrays  
            Result = Merge(Left, Right);

            return Result;

        }
        public int[] Merge(int[] Left, int[] Right)
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.Refresh();
            int resultLength = Left.Count() + Right.Count();
            int[] Result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < Left.Count() || indexRight < Right.Count())
            {
                //if both arrays have elements  
                if (indexLeft < Left.Count() && indexRight < Right.Count())
                {
                    //If item on left array is less than item on right array, add that item to the result array  
                    if (Left[indexLeft] <= Right[indexRight])
                    {
                        Result[indexResult] = Left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array  
                    else
                    {
                        Result[indexResult] = Right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array  
                else if (indexLeft < Left.Count())
                {
                    Result[indexResult] = Left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array  
                else if (indexRight < Right.Count())
                {
                    Result[indexResult] = Right[indexRight];
                    indexRight++;
                    indexResult++;
                }

            }
            return Result;
        }
        private void btnazalan_Click(object sender, EventArgs e)
        {
            kisisayisibul();
            dataGridView1.DataSource = null;
            PersonelList = MergeSort(PersonelList);
            Array.Reverse(PersonelList);
                for (int i = 0; i < PersonelList.Count(); i++)
                {
                    string[] maas = IsciBilgileri[i].Split(',');
                    maasdizi[i] = Convert.ToInt32(maas[4]);
                }


                for (int i = 0; i < PersonelList.Count(); i++)
                {
                    for (int j = 0; j < PersonelList.Count(); j++)
                    {
                        if (PersonelList[i] == maasdizi[j])
                        {
                            veriler[i] = (IsciBilgileri[j].ToString());
                        }

                    }

                }

                DataTable dt = new DataTable();
                List<string> veriler3 = veriler.OfType<string>().ToList();
                if (veriler.Count() > 0)
                {
                    //string ilkSatir = satirlar[0];
                    string header = "ID,İsim,Soyadi,Adres,Maas,Akademik,Deneyim,Yöneticilik Görevi,Yabancı Dil,Çalışılan İl,Aile";
                string[] basliklar = header.Split(',');
                    foreach (string headerwords in basliklar)
                    {
                        dt.Columns.Add(new DataColumn(headerwords));
                    }
                    for (int i = 0; i < veriler3.Count(); i++)
                    {

                        DataRow dr = dt.NewRow();
                        string[] veriler2 = veriler3[i].Split(',');
                        int indexer = 0;
                        foreach (string headerword in basliklar)
                        {
                            dr[headerword] = veriler2[indexer++];
                        }
                        dt.Rows.Add(dr);
                    }

                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);
        }
        private void btnjson_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Metin Dosyası|*.json";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(save.FileName);
                Kayit.WriteLine(sJSONResponse);
                Kayit.Close();
            }
        }
    }
    }





