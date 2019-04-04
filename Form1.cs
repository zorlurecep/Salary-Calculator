/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:1
**				ÖĞRENCİ ADI............:Recep Ömer Zorlu    
**				ÖĞRENCİ NUMARASI.......:G181210045
**              DERSİN ALINDIĞI GRUP...:2D
****************************************************************************/

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

namespace Son_hal_deneme1
{
    public partial class Form1 : Form
    {
        List<Personel> personels = new List<Personel>();//Creates a personel class type list in order to personels information

        Stream myStream;//used for control file input
        OpenFileDialog openFile = new OpenFileDialog();//for opening files by user

        string[] satirlar = null;//split our text into this by lines and with the lenght of this we decide our loops loop time
        string[] kelimeler = null;//splits our text into this by words and from here we assing our data to our list elements
        string fileName = null;//keeps file path
        string fileText = null;//keeps all file context in it

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileandTransferInformations();
            ShowOpenedRecords();
        }

        public void OpenFileandTransferInformations()//with this method we choose our file and assing our personel informations to appropriate positions
        {
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFile.OpenFile()) != null)
                {
                    fileName = openFile.FileName;//gets file path
                    fileText = File.ReadAllText(fileName);//read all text
                    satirlar = fileText.Split('\n');//split lines
                    kelimeler = fileText.Split(' ', '\n');//split words
                }
            }

            int sayi = 0;

            for (int i = 0; i < satirlar.Length; i++)
            {
                personels.Add(new Personel());//create new spaces for personels with each loop

                personels[i].tc = kelimeler[sayi];
                personels[i].adi = kelimeler[sayi + 1];
                personels[i].soyadi = kelimeler[sayi + 2];
                personels[i].yas = System.Convert.ToInt32(kelimeler[sayi + 3]);
                personels[i].calısmaSuresi = System.Convert.ToInt32(kelimeler[sayi + 4]);       //assing our data to appropriate positions
                personels[i].medeniHali = kelimeler[sayi + 5];
                personels[i].esDurumu = kelimeler[sayi + 6];
                personels[i].cocukSayisi = System.Convert.ToInt32(kelimeler[sayi + 7]);
                personels[i].tabanMaas = System.Convert.ToInt32(kelimeler[sayi + 8]);
                personels[i].makamTazminati = System.Convert.ToInt32(kelimeler[sayi + 9]);
                personels[i].idariGorevTazminati = System.Convert.ToInt32(kelimeler[sayi + 10]);
                personels[i].fazlaMesaiSaati = System.Convert.ToInt32(kelimeler[sayi + 11]);
                personels[i].fazlaMesaiSaatUcreti = System.Convert.ToInt32(kelimeler[sayi + 12]);
                personels[i].vergiMatrahi = System.Convert.ToInt32(kelimeler[sayi + 13]);
                //personels[i].resimYolu = kelimeler[sayi + 14];

                sayi += 14;
            }
        }

        public void ShowOpenedRecords()//prints our opened files into rich text box
        {
            for (int i = 0; i < satirlar.Length; i++)
            {
                richTextBox1.Text += satirlar[i] + "\r";
            }
        }

        public void KayitAra()//searc for recors that entered to our text box
        {
            if (textBox1.Text != "")
            {
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (textBox1.Text == personels[i].tc)
                    {
                        label7.Text = personels[i].tc;//prints informations to labels
                        label8.Text = personels[i].adi;
                        label9.Text = personels[i].soyadi;

                        personels[i].NetMaasHesapla();
                        label10.Text = Convert.ToString(personels[i].NetMaas);

                        //if like to add also image put image adress at the end of the text file and change line 90 to 15 and uncomment line 88 also these lines
                        //Bitmap image = new Bitmap(personels[i].resimYolu);//takes picture path

                        //pictureBox1.Image = (Image)image;
                        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
            }
            else
            {
                MessageBox.Show("Kayit bulunamadi");//controls if text box empty or record not found 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitAra();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
