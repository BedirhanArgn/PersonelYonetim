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
        StreamWriter sw;
        int bazucret = 4500;
        int kontrol = 0;
        ArrayList personel = new ArrayList();
        Staff isci = new Staff();
        public Form2()
        {
            
            InitializeComponent();
        }
        public void dosyaoku()
        {
            if (File.Exists("stuff.csv"))
            {
                using (var reader = new StreamReader("stuff.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        personel.Add(line);
                        // depo.Add(values);
                        //Console.WriteLine(values[1]);
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
            if (File.Exists("stuff.csv"))
            {
                StreamWriter Yaz = new StreamWriter("stuff.csv", true);
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
            isci.ID = txtboxid.ToString();
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
            string yazdir = txtboxid.Text.ToString() + "," + txtboxisim.Text.ToString() + "," + txtboxsoyadi.Text.ToString() + "," + textboxadres.Text.ToString() + "," + cmbaile.SelectedItem.ToString() + "," + cmbboxakademik.SelectedItem.ToString() + "," + cmbboxdeneyim.SelectedItem.ToString() + "," + cmbboxyöneticilik.SelectedItem.ToString() + "," + cmbboxydb.SelectedItem.ToString() + "," + cmbboxil.SelectedItem.ToString() + "," + ucrettotal.ToString();
            dosyayaz(yazdir);
            personel.Add(yazdir);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupboxdil.Visible = false;
            groupboxaile.Visible = false;
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
        //private void btnsil_Click(object sender, EventArgs e)
        //{
        //    int sayac = 0;
        //    for (int i = 0; i < listboxgoster.Items.Count; i++)
        //    {
        //        if (listboxgoster.SelectedIndex == sayac)
        //        {

        //            listboxgoster.Items.RemoveAt(sayac);
        //            personel.RemoveAt(sayac);
        //        }
        //        sayac++;
        //    }
        //    if (listboxgoster.Items.Count > -1)
        //    {
        //        StreamWriter Yaz = new StreamWriter("stuff2.csv");
        //        for (int i = 0; i < personel.Count; i++)
        //        {
        //            Yaz.WriteLine(personel[i]);

        //        }
        //        Yaz.Close();
        //        Yaz.Dispose();
        //        File.Replace("stuff2.csv", "stuff.csv", "temp.csv");
        //        //File.Delete("temp.csv");
        //    }
        //}
        //private void btnupdate_Click(object sender, EventArgs e)
        //{
        //    int indx = 0;
        //    for (int i = 0; i < listboxgoster.Items.Count; i++)
        //    {
        //        if (listboxgoster.SelectedIndex == indx)
        //        {
        //            listboxgoster.Items.RemoveAt(indx);
        //            personel.RemoveAt(indx);
        //            listboxgoster.Items.Insert(indx, txtboxid.Text.ToString() + "," + txtboxisim.Text.ToString() + "," + txtboxsoyadi.Text.ToString() + "," + textboxadres.Text.ToString() + "," + cmbaile.SelectedItem.ToString() + "," + cmbboxakademik.SelectedItem.ToString() + "," + cmbboxdeneyim.SelectedItem.ToString() + "," + cmbboxyöneticilik.SelectedItem.ToString() + "," + cmbboxydb.SelectedItem.ToString() + "," + cmbboxil.SelectedItem.ToString());
        //            //listboxgoster.Items.Insert(indx, txtboxadd.Text.ToString());
        //            personel.Insert(indx, txtboxid.Text.ToString() + "," + txtboxisim.Text.ToString() + "," + txtboxsoyadi.Text.ToString() + "," + textboxadres.Text.ToString() + "," + cmbaile.SelectedItem.ToString() + "," + cmbboxakademik.SelectedItem.ToString() + "," + cmbboxdeneyim.SelectedItem.ToString() + "," + cmbboxyöneticilik.SelectedItem.ToString() + "," + cmbboxydb.SelectedItem.ToString() + "," + cmbboxil.SelectedItem.ToString() + ucrettotal.ToString());
        //        }
        //        indx++;
        //    }
        //    if (listboxgoster.Items.Count > -1)
        //    {
        //        StreamWriter Yaz = new StreamWriter("stuff2.csv");
        //        for (int i = 0; i < personel.Count; i++)
        //        {
        //            Yaz.WriteLine(personel[i]);
        //        }
        //        Yaz.Close();
        //        Yaz.Dispose();
        //        File.Replace("stuff2.csv", "stuff.csv", "temp.csv");
        //    }
        //}

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
            
            this.Close();
            f1.vericek();
            

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

        
    }
}