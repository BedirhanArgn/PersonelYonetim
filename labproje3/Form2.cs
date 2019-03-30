using System;
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
            idsayisi++;
            isci.ID = idsayisi.ToString();
            isci.Imagepath = imageyolu;
            isci.Name = txtboxisim.ToString();
            isci.Surname = txtboxsoyadi.ToString();
            isci.Address = textboxadres.ToString();
            isci.ydbdil = ucretydb;
            isci.ustogrenim = cmbboxakademik.SelectedIndex;
            isci.yoneticilikgorevi = cmbboxyöneticilik.SelectedIndex;
            isci.Deneyim = cmbboxdeneyim.SelectedIndex;
            isci.ailedurum = ucretaile;
            isci.calisilanil = cmbboxil.SelectedIndex;
            isci.Salary1 = ucrethesabi();
            string yazdir = idsayisi.ToString() + "," + txtboxisim.Text.ToString() + "," + txtboxsoyadi.Text.ToString() + "," + textboxadres.Text.ToString() + "," + cmbaile.SelectedItem.ToString() + "," + cmbboxakademik.SelectedItem.ToString() + "," + cmbboxdeneyim.SelectedItem.ToString() + "," + cmbboxyöneticilik.SelectedItem.ToString() + "," + cmbboxydb.SelectedItem.ToString() + "," + cmbboxil.SelectedItem.ToString() + "," + ucrettotal.ToString() + "," + imageyolu;
            dosyayaz(yazdir);
            personel.Add(yazdir);

            string[] sutun = new string[3];
            sutun[0] = idsayisi.ToString();
            sutun[1] = txtboxisim.Text;
            sutun[2] = txtboxsoyadi.Text;
            lstListe.Items.Add(new ListViewItem(sutun));
            MessageBox.Show("Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            groupboxdil.Visible = false;
            groupboxaile.Visible = false;
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
            else
            {
                ucretydb = 0.20;
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
        private void btnupdate_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            name = txtboxisim.Text;
            isci.Name = name;
            isci.Imagepath = imageyolu;
            surname = txtboxsoyadi.Text;
            isci.Surname = surname;
            deneyim = cmbboxdeneyim.Text;
            calisilanil = cmbboxil.Text;
            akademikderece = cmbboxakademik.Text;
            yabancidil = cmbboxydb.Text;
            Yoneticilik = cmbboxyöneticilik.Text;
            ailedurum = cmbaile.Text;
            adres = textboxadres.Text;
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
                    personel.Insert(indx, eskiid + "," + name + "," + surname + "," + adres + "," + ailedurum + "," + akademikderece + "," + deneyim + "," + Yoneticilik + "," + yabancidil + "," + calisilanil + "," + ucrettotal.ToString() + "," + isci.Imagepath);
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
        private void cmbaile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 0) //Evli ve esi çalışmıyor
            {
                ucretaile = 0.20;
                checkboxes.Checked = true;
            }


        }
        private void chc1cocuk_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbaile.SelectedIndex == 1)
            {
                ucretaile = 0.20;
            }
            if (cmbaile.SelectedIndex == 2)
            {
                ucretaile = 0.20;
            }
            if (cmbaile.SelectedIndex == 3)
            {
                ucretaile = 0.30;
            }
            if (cmbaile.SelectedIndex == 4)
            {
                ucretaile = 0.40;
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
            this.Close();

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
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
                    cmbaile.Text = bolunecekkelime[4];
                    cmbboxakademik.Text = bolunecekkelime[5];
                    cmbboxdeneyim.Text = bolunecekkelime[6];
                    cmbboxyöneticilik.Text = bolunecekkelime[7];
                    cmbboxydb.Text = bolunecekkelime[8];
                    cmbboxil.Text = bolunecekkelime[9];
                    asgarimaasi = bolunecekkelime[10];
                    imageyolu = bolunecekkelime[11];
                    resimyukle(imageyolu);
                }
                indx++;
            }
        }
        private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);
        }
        private void txtboxid_KeyUp(object sender, KeyEventArgs e)
        {
            // id = txtboxid.Text;
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



        private void cmbboxdeneyim_TextChanged(object sender, EventArgs e)
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

        private void cmbaile_TextChanged(object sender, EventArgs e)
        {
            ailedurum = cmbaile.Text;

        }

        private void cmbboxyöneticilik_TextChanged(object sender, EventArgs e)
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

        private void cmbboxydb_TextChanged(object sender, EventArgs e)
        {
            yabancidil = cmbboxydb.Text;
        }

        private void cmbboxakademik_TextChanged(object sender, EventArgs e)
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

        private void cmbboxil_TextChanged(object sender, EventArgs e)
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
    }
}