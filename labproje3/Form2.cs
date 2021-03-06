﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace labproje3
{
    public partial class Form2 : Form
    {
        double ucretydb;
        double ucretaile;
        double ucrettotal;
        string asgarimaasi;
        string name;
        string surname;
        string deneyim;
        string akademikderece;
        string Yoneticilik;
        string yabancidil;
        string ailedurum;
        string adres;
        string imageyolu;
        string calisilanil;
        int ucret;
        StreamWriter sw;
        int bazucret = 4500;
        int idsayisi;
        string[] Sutun = new string[10];
        int kontrol = 0;
        ArrayList personel = new ArrayList();
        Staff isci = new Staff();
        int a = 0;
        public Form2()
        {

            InitializeComponent();
        }
        public void listviewolustur()
        {
            lstListe.Columns.Add("Id", 30);
            lstListe.Columns.Add("Ad ", 130);
            lstListe.Columns.Add("Soyadı", 100);
        }
        public void dosyaoku()
        {
            try
            {
                if (File.Exists("stuff.csv"))
                {
                    Form1 f1 = new Form1();
                    using (var reader = new StreamReader(f1.Yol))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            idsayisi = Convert.ToInt32(values[0]);
                            personel.Add(line);
                            if (values[0].ToString() == "")
                            {
                                lstListe.Visible = false;
                            }
                            else
                            {
                                lstListe.Visible = true;
                                for (int i = 0; i < 3; i++)
                                {

                                    Sutun[a] = values[i].ToString();
                                    a++;
                                }
                                lstListe.Items.Add(new ListViewItem(Sutun));
                                Array.Clear(Sutun, 0, Sutun.Length);
                                a = 0;
                            }
                        }
                        reader.Close();
                        reader.Dispose();
                    }

                }
                else
                {
                    dosyaolustur();
                }
            }
            catch
            {
                MessageBox.Show("Yukleme Basarisiz Oldu");
            }

        }
        public void dosyayaz(string yazdir)
        {
            Form1 f1 = new Form1();
            if (File.Exists("stuff.csv"))
            {
                StreamWriter Yaz = new StreamWriter(f1.Yol, true);
                Yaz.WriteLine(yazdir);
                Yaz.Close();
            }
            else
            {
                dosyaolustur();

            }
        }
        public void dosyaolustur()
        {
            sw = new StreamWriter("stuff.csv");
            sw.Close();
            sw.Dispose();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                idsayisi++;
                isci.ID = idsayisi.ToString();
                isci.Imagepath = imageyolu;
                isci.Name = txtboxisim.ToString();
                isci.Surname = txtboxsoyadi.ToString();
                isci.Address = textboxadres.ToString();
                isci.ydbdil = cmbboxydb.SelectedIndex;
                isci.ustogrenim = cmbboxakademik.SelectedIndex;
                isci.yoneticilikgorevi = cmbboxyöneticilik.SelectedIndex;
                isci.Deneyim = cmbboxdeneyim.SelectedIndex;
                isci.ailedurum = ucretaile;
                isci.calisilanil = cmbboxil.SelectedIndex;
                if(chcboxyarizaman.Checked==false)
                {
                isci.Salary1 =ucrethesabi();
                }
               
                string yazdir = idsayisi.ToString() + "," + txtboxisim.Text.ToString() + "," + txtboxsoyadi.Text.ToString() + "," + textboxadres.Text.ToString() + "," + ucrettotal.ToString() + "," + cmbboxakademik.SelectedItem.ToString() + "," + cmbboxdeneyim.SelectedItem.ToString() + "," + cmbboxyöneticilik.SelectedItem.ToString() + "," + cmbboxydb.SelectedItem.ToString() + "," + cmbboxil.SelectedItem.ToString() + "," + cmbaile.SelectedItem.ToString() + "," + imageyolu;
                dosyayaz(yazdir);
                personel.Add(yazdir);
                string[] sutun = new string[3];
                sutun[0] = idsayisi.ToString();
                sutun[1] = txtboxisim.Text;
                sutun[2] = txtboxsoyadi.Text;
                lstListe.Items.Add(new ListViewItem(sutun));
                progressBar1.Value = 100;
                MessageBox.Show("Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Eklenemedi");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            groupboxdil.Visible = false;
            groupboxcocuk.Visible = false;
            groupboxaile.Visible = false;
            progressBar1.Visible = false;
            listviewolustur();
            dosyaoku();
        }
        public double ucrethesabi()
        {
            if (cmbboxydb.SelectedIndex == 2 && rbingbilgisi.Checked == true || cmbboxydb.SelectedIndex == 2 && rbingilizceokul.Checked)
            {
                ucretydb = 0.20 + (Convert.ToInt32(textboxdilsayisi.Text.ToString()) * 0.05);
            }
            else if (cmbboxydb.SelectedIndex == 2 && rbingbilgisi.Checked == false || cmbboxydb.SelectedIndex == 2 && rbingilizceokul.Checked == false)
            {
                ucretydb = (Convert.ToInt32(textboxdilsayisi.Text.ToString()) * 0.05);
            }
            else if (cmbboxydb.SelectedIndex == 1 || cmbboxydb.SelectedIndex == 0)
            {
                ucretydb = 0.20;
            }
            else
            {
                ucretydb = 0;
            }
            ucrettotal = (bazucret * (isci.calisilanil + isci.Deneyim + isci.ustogrenim + ucretaile + ucretydb + isci.yoneticilikgorevi + 1.0));
            return ucrettotal;
        }
        private void checkBoxing3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxing3.Checked == true)
            {
                textboxdilsayisi.Visible = true;
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 f1 = new Form1();
                int sayac = 0;
                for (int i = 0; i < lstListe.Items.Count; i++)
                {
                    if (lstListe.Items[sayac].Selected == true)
                    {

                        lstListe.Items.RemoveAt(sayac);
                        personel.RemoveAt(sayac);
                    }
                    sayac++;
                }
                if (lstListe.Items.Count > -1)
                {
                    StreamWriter Yaz = new StreamWriter("stuff2.csv");
                    for (int i = 0; i < personel.Count; i++)
                    {
                        Yaz.WriteLine(personel[i]);

                    }
                    Yaz.Close();
                    idsayisi--;
                    Yaz.Dispose();
                    File.Replace("stuff2.csv", f1.Yol, "temp.csv");
                    File.Delete("stuff2.csv");
                }
            }
            catch
            {
                MessageBox.Show("Silme Başarısız oldu");
            }

        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                name = txtboxisim.Text;
                isci.Name = name;
                isci.Imagepath = imageyolu;
                surname = txtboxsoyadi.Text;
                isci.Surname = surname;
                deneyim = cmbboxdeneyim.Text;
                isci.Deneyim = Convert.ToDouble(cmbboxdeneyim.SelectedIndex.ToString());
                calisilanil = cmbboxil.Text;
                isci.calisilanil = Convert.ToDouble(cmbboxil.SelectedIndex.ToString());
                akademikderece = cmbboxakademik.Text;
                isci.ustogrenim = Convert.ToDouble(cmbboxakademik.SelectedIndex.ToString());
                yabancidil = cmbboxydb.Text;

                isci.ydbdil = Convert.ToDouble(cmbboxydb.SelectedIndex.ToString());

                isci.ydbdil = Convert.ToDouble(cmbboxydb.SelectedIndex.ToString());

                Yoneticilik = cmbboxyöneticilik.Text;
                isci.yoneticilikgorevi = Convert.ToDouble(cmbboxyöneticilik.SelectedIndex.ToString());
                ailedurum = cmbaile.Text;
                isci.ailedurum = Convert.ToDouble(cmbaile.SelectedIndex.ToString());
                adres = textboxadres.Text;
                Form1 f1 = new Form1();

                string[] sutun = new string[10];
                int indx = 0;
                string eskiid;
                while (true)
                {
                    if (lstListe.SelectedItems[0] == lstListe.Items[indx])
                    {
                        eskiid = lstListe.Items[indx].Text;
                        lstListe.Items.RemoveAt(indx);
                        personel.RemoveAt(indx);
                        idsayisi--;
                        sutun[0] = eskiid;
                        sutun[1] = name;
                        sutun[2] = surname;
                        lstListe.Items.Insert(indx, new ListViewItem(sutun));
                        ucrethesabi();
                        idsayisi++;

                        personel.Insert(indx, eskiid + "," + name + "," + surname + "," + adres + "," + ucrettotal.ToString() + "," + akademikderece + "," + deneyim + "," + Yoneticilik + "," + yabancidil + "," + calisilanil + "," + ailedurum + "," + isci.Imagepath);

                        personel.Insert(indx, eskiid + "," + name + "," + surname + "," + adres + "," + ucrettotal.ToString() + "," + akademikderece + "," + deneyim + "," + Yoneticilik + "," + yabancidil + "," + calisilanil + "," + ailedurum + "," + isci.Imagepath);
                        break;
                    }
                    indx++;
                }
                if (lstListe.Items.Count > -1)
                {
                    StreamWriter Yaz = new StreamWriter("stuff2.csv");
                    for (int i = 0; i < personel.Count; i++)
                    {
                        Yaz.WriteLine(personel[i]);
                    }
                    Yaz.Close();
                    Yaz.Dispose();
                    MessageBox.Show("Guncelleme Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    File.Replace("stuff2.csv", f1.Yol, "temp.csv");
                }
            }
            catch
            {
                MessageBox.Show("Güncelleme basarısız oldu");
            }

        }
        private void cmbaile_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupboxcocuk.Visible = false;
            if (cmbaile.SelectedIndex == 0) //Evli ve esi çalışmıyor
            {
                ucretaile = 0.20;
                checkboxes.Checked = true;
            }
            else if (cmbaile.SelectedIndex == 1)
            {
                ucretaile = 0.20;
            }
            else if (cmbaile.SelectedIndex == 2)
            {
                ucretaile = 0.30;
            }
            else if (cmbaile.SelectedIndex == 3)
            {
                ucretaile = 0.40;
            }
            else if (cmbaile.SelectedIndex == 4)
            {
                groupboxcocuk.Visible = true;
            }
        }
        private void chc2cocuk_CheckedChanged(object sender, EventArgs e)
        {
            groupboxaile.Visible = true;
            if (cmbaile.SelectedIndex == 1)
            {
                ucretaile = 2 * 0.20;

            }
            if (cmbaile.SelectedIndex == 2)
            {
                ucretaile = 2 * 0.30;

            }
            if (cmbaile.SelectedIndex == 3)
            {
                ucretaile = 2 * 0.40;
            }
        }
        private void checkboxes_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 4 || cmbaile.SelectedIndex == 1 || cmbaile.SelectedIndex == 2 || cmbaile.SelectedIndex == 3)
            {
                ucretaile += 0.20;
            }
        }
        private void chcbekar_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 4)
            {
                ucretaile = 0;
            }
        }
        private void chcbox06_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 4)
            {
                ucretaile += 0.20;
                kontrol = 1;
            }
        }
        private void chcbox718_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 4 && kontrol == 1)
            {
                ucretaile += 0.30;
            }

        }
        private void chcbox18_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 4 && kontrol == 1 && chcbox718.Checked)
            {
                ucretaile = (ucretaile + 0.40) - 0.20;
            }
            else //3 ü işaretli değişlse
            {
                ucretaile = ucretaile + 0.40;
            }
        }
        private void btngeri_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.vericek();
            this.Visible = false;

        }
        private void checkboxes_CheckedChanged_1(object sender, EventArgs e)
        {
            ucretaile += 0.20;
        }
        private void cmbboxydb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbboxydb.SelectedIndex == 2)
            {
                textboxdilsayisi.Visible = true;
                label9.Visible = true;
                checkBoxing3.Checked = true;
                groupboxdil.Visible = true;
            }
            if (cmbboxydb.SelectedIndex == 0)
            {
                rbingbilgisi.Checked = true;
                groupboxdil.Visible = false;

            }
            if (cmbboxydb.SelectedIndex == 1)
            {
                rbingilizceokul.Checked = true;
                groupboxdil.Visible = false;
            }
            if (cmbboxydb.SelectedIndex == 3)
            {
                ucretydb = 0;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int indx = 0;
                for (int i = 0; i < lstListe.Items.Count; i++)
                {
                    if (lstListe.Items[indx].Selected == true)
                    {
                        string kelime = personel[indx].ToString();
                        string[] bolunecekkelime = kelime.Split(',');
                        //  txtboxid.Text = bolunecekkelime[0];
                        txtboxisim.Text = bolunecekkelime[1];
                        txtboxsoyadi.Text = bolunecekkelime[2];
                        textboxadres.Text = bolunecekkelime[3];
                        cmbaile.Text = bolunecekkelime[10];
                        cmbboxakademik.Text = bolunecekkelime[5];
                        cmbboxdeneyim.Text = bolunecekkelime[6];
                        cmbboxyöneticilik.Text = bolunecekkelime[7];
                        cmbboxydb.Text = bolunecekkelime[8];
                        cmbboxil.Text = bolunecekkelime[9];
                        asgarimaasi = bolunecekkelime[4];
                        imageyolu = bolunecekkelime[11];
                        resimyukle(imageyolu);
                    }
                    indx++;
                }
            }catch
            {
                MessageBox.Show("Görüntüleme Başarısız Oldu", "Uyarı", MessageBoxButtons.OK);
            }

        }
        private void txtboxisim_KeyUp(object sender, KeyEventArgs e)
        {
            name = txtboxisim.Text;

        }
        private void txtboxsoyadi_KeyUp(object sender, KeyEventArgs e)
        {
            surname = txtboxsoyadi.Text;
        }
        private void textboxadres_KeyUp(object sender, KeyEventArgs e)
        {
            adres = textboxadres.Text;
        }
        private void picturestuff_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);    // masaüstünü göstermesi için
            openFileDialog1.Filter = "JPEG (*.jpg; *jpeg; *jpe)|*.jpg; *jpeg; *jpe|All files (*.*)|*.*";        // dosya filtrelemesi
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            foreach (string s in openFileDialog1.FileNames)     // multi select özelliği için kullanılabilir
                            {
                                picturestuff.ImageLocation = s;
                                imageyolu = picturestuff.ImageLocation;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: Dosya okunamadı!" + ex.Message);
                }

            }
        }
        public void resimyukle(string veriyolu)
        {
            Image image = Image.FromFile(veriyolu);
            picturestuff.Image = image;
        }
        private void cmbboxdeneyim_DropDownClosed(object sender, EventArgs e)
        {
            deneyim = cmbboxdeneyim.Text;
            for (int i = 0; i < cmbboxdeneyim.Items.Count; i++)
            {
                if (cmbboxdeneyim.Items[i].ToString() == cmbboxdeneyim.Text)
                {
                    isci.Deneyim = i;
                }
            }
        }
        private void cmbaile_DropDownClosed(object sender, EventArgs e)
        {

            ailedurum = cmbaile.Text;

            ailedurum = cmbaile.Text;

        }
        private void cmbboxyöneticilik_DropDownClosed(object sender, EventArgs e)
        {
            Yoneticilik = cmbboxyöneticilik.Text;
            for (int i = 0; i < cmbboxyöneticilik.Items.Count; i++)
            {
                if (cmbboxyöneticilik.Items[i].ToString() == cmbboxyöneticilik.Text)
                {
                    isci.yoneticilikgorevi = i;
                }
            }
        }
        private void cmbboxydb_DropDownClosed(object sender, EventArgs e)
        {
            yabancidil = cmbboxydb.Text;

        }
        private void cmbboxakademik_DropDownClosed(object sender, EventArgs e)
        {
            akademikderece = cmbboxakademik.Text;
            for (int i = 0; i < cmbboxakademik.Items.Count; i++)
            {
                if (cmbboxakademik.Items[i].ToString() == cmbboxakademik.Text)
                {
                    isci.ustogrenim = i;
                }
            }
        }
        private void cmbboxil_DropDownClosed(object sender, EventArgs e)
        {
            calisilanil = cmbboxil.Text;
            for (int i = 0; i < cmbboxil.Items.Count; i++)
            {
                if (cmbboxil.Items[i].ToString() == cmbboxil.Text)
                {
                    isci.calisilanil = i;
                }
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                Environment.Exit(0);
            }
            catch
            {

            }

        }

        private void chcboxyarizaman_CheckedChanged(object sender, EventArgs e)
        {
            isci.Salary1=ucrethesabi();
            if(chcboxyarizaman.Checked==true)
            {
                ucrettotal = ucrettotal / 2;
                ucret = Convert.ToInt32(ucrettotal);
                ucrettotal = ucret;
                isci.Salary1 = ucret;
            }
           
        }
    }
}