using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentNoteSystem.forms
{
    // Ah met Çakır-- Matematik-- Cüneyt Öz-- 75

    public partial class Ogretmen: Form
    {
        private int ogrenciıd;
        // formu hareket ettirmek için kod
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OgrenciNotSistemiDBBBB.mdb"; // veritabanı bağladık.


        // oluşturduğum metotlar
        private void GetStudents() // öğrenci getirme metodu
        {
            // ogrenciler butonuna basıldığında panel gözüksün
            panelnotguncelle.Visible = false;
            pnlraporlar.Visible = false;
            panelOgrenciler.Visible = true;

            string query = "SELECT * FROM Ogrenciler"; // query sorgu. Ogrenciler tablosundaki tüm öğrencileri getir.

            try // burayı dene ve olası hata durumunda
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString)) // veritabanındaki vverileri bağladık.
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection); //adapter, connectiondaki querye gidecek ve dataları bana getirecek. ama bu data'lar okuyabileceğim türden değil o yuzden bunu datatable ile benim okuyabileceğim görebileceğim formata getireceğim.
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); // data'ları okuyabileceğim formata getirdim.

                    dataGridView1.DataSource = dt; // gridview'ime dt'lerimizi bağladık. okuduğumuz dt'leri.

                    label9.Text = "Tüm Öğrenciler";
                }

            }
            catch (Exception ex) // olası hatada hata mesajı ver.
            {
                MessageBox.Show($"Hata: {ex.Message}","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error); // ex.message kodumuzda olan hatayı bize verir.
            }
       
        }
        private void UpdateStudentNote()
        {
            //panelOgrenciler.Visible=false; // paneller birbirinw karışmasın diye. ogrenciler butonundaki panel'in visiable'ını false yapıp sonra güncellenin visiable'sini açarız.
            panelnotguncelle.Visible = true;
            pnlraporlar .Visible = false;

            string query = "SELECT * FROM Ogrenciler";
             using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query,conn)) // query sorgumuu conn'dan gelen verilere göre çalıştır.
                {
                    // gelen verileri datatable ve ilgili yerlere dolduruyorum.
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt); // adapterımı datatable ile dolduruyorum.

                    comboBox1.DisplayMember = "Ad"; // kullanıcının gördüğü veriler ad'lar olacak.
                    comboBox1.ValueMember = "ID"; // arkaplanda tutulacak olan şey de ID'dır. bunu Ad yapsaydık ekranda değişen bir şey olmazdı arkada tutulan yer değişecekti.
                    comboBox1.DataSource = dt; // combobox datasoruce'suna dataları ver. datasource yani kaynak olarak gönderdik.
                }
            }
            label9.Text = "Not Güncelle"; // başlığın güncellemesi.
        }

        private void ListData( ) 
        {
            string query = "SELECT * FROM Ogrenciler"; // query sorgu. Ogrenciler tablosundaki tüm öğrencileri getir.

            try // burayı dene ve olası hata durumunda
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString)) // veritabanındaki vverileri bağladık.
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection); //adapter, connectiondaki querye gidecek ve dataları bana getirecek. ama bu data'lar okuyabileceğim türden değil o yuzden bunu datatable ile benim okuyabileceğim görebileceğim formata getireceğim.
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); // data'ları okuyabileceğim formata getirdim.

                    dataGridView1.DataSource = dt; // gridview'ime dt'lerimizi bağladık. okuduğumuz dt'leri.

                    label9.Text = "Tüm Öğrenciler";
                }

            }
            catch (Exception ex) // olası hatada hata mesajı ver.
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // ex.message kodumuzda olan hatayı bize verir.
            }

            if (comboBox1.SelectedItem != null) // eleman seçmişsek bura çalışsın
            {
                // datatbale ile combobox'ı bağlamıştık. datatable birden fazla satır içeriyor ve verileri datarow olarak saklıyor.
                DataRowView rowView = comboBox1.SelectedItem as DataRowView; // en sonda bunu datarowview'e dönüştürmüş olduk. burada yeni bir nesne ooluşturmuyoruz. halihazırda oluşturduklarımızı aldık.

                if (rowView != null) // row varsa
                {
                    ogrenciıd = Convert.ToInt32(rowView["ID"]); // öğrenci ıd'lerini değişkende tuttuk.

                    lblıd.Text = "Öğrenci ID:" + rowView["ID"].ToString();
                    lblad.Text = "Öğrenci Adı:" + rowView["Ad"].ToString(); // ad label'ına row ile gelen Ad sutunundaki bilgiyi yazdır dedik.
                    lblsoyad.Text = "Öğrenci Soyadı:" + rowView["Soyad"].ToString();
                    lblno.Text = "Öğrenci Numarası:" + rowView["Numara"].ToString();
                    lblsifre.Text = "Şifre:" + rowView["Sifre"].ToString();

                    labelturkce.Text = "Türkçe: " + rowView["TurkceNot"].ToString();
                    labelmatematik.Text = "Matematik: " + rowView["MatematikNot"].ToString(); // dersler kısmını oluşturduk.
                    labelfizik.Text = "Fizik: " + rowView["FizikNot"].ToString();
                    labelfelsefe.Text = "Felsefe: " + rowView["FelsefeNot"].ToString();
                    labelbiyoloji.Text = "Biyoloji: " + rowView["BiyolojiNot"].ToString();

                    texturkc.Text = rowView["TurkceNot"].ToString();
                    txtmat.Text = rowView["MatematikNot"].ToString(); // not güncelleme textboxlarına o anki notlarını gösterdik.
                    txtfzk.Text = rowView["FizikNot"].ToString();
                    txtfels.Text = rowView["FelsefeNot"].ToString();
                    txtbiyo.Text = rowView["BiyolojiNot"].ToString();

                    // notların ortalamasını aldık
                    label11.Text = "Ortalama: " +

                        ((Convert.ToDouble(rowView["TurkceNot"]) +
                        Convert.ToDouble(rowView["MatematikNot"]) +
                        Convert.ToDouble(rowView["FizikNot"]) +
                        Convert.ToDouble(rowView["FelsefeNot"]) +
                        Convert.ToDouble(rowView["BiyolojiNot"])) / 5).ToString("0.00"); // 0.00 küsüratını da eklemesini söyler.
                }
            }
        }

        private int GetCount(OleDbConnection cnn , string query)
        {
            using (OleDbCommand cmd = new OleDbCommand(query, cnn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }




        public Ogretmen()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnogrenciler_Click(object sender, EventArgs e)
        {
           GetStudents(); // metodu burada çalıştırdık.
        }

        private void btnnot_Click(object sender, EventArgs e)
        {
            UpdateStudentNote(); // not güncelle metodunu çağırdık.
            
        }

        // formu hareket ettirmek için kullanılan kod.
        private void Ogretmen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListData(); // listdata metodu oluşturduk ve combobox içinden bu listdata metodunu çağırırız.
        }

        private void notgncellegroup_Click(object sender, EventArgs e)
        {
            int matematikNot = Convert.ToInt32(txtmat.Text);
            int turkceNot = Convert.ToInt32(texturkc.Text);
            int fizikNot = Convert.ToInt32(txtfzk.Text);
            int felsefeNot = Convert.ToInt32(txtfels.Text);
            int biyolojiNot = Convert.ToInt32(txtbiyo.Text); // textbox'lardan gelen değerleri değişkenlerde tuttuk. 

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Ogrenciler SET MatematikNot = @matematikNot, TurkceNot = @turkceNot, FizikNot = @fizikNot, BiyolojiNot = @biyolojiNot, FelsefeNot = @felsefeNot WHERE ID= @id"; // Turkcenot , turkcenottan gelecek. Sadece id'den gelen değerler güncellensin dedik.

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@matematikNot", matematikNot);
                        cmd.Parameters.AddWithValue("@turkceNot", turkceNot);
                        cmd.Parameters.AddWithValue("@fizikNot", fizikNot);
                        cmd.Parameters.AddWithValue("@biyolojiNot", biyolojiNot);
                        cmd.Parameters.AddWithValue("@felsefeNot", felsefeNot);
                        cmd.Parameters.AddWithValue("@id", ogrenciıd);
                        int roweAffected = cmd.ExecuteNonQuery(); // bu sorguyu çalıştır. int türünde sayı verir. etkilenen satırların sayısını verir.

                        if (roweAffected>0) // etkilenen varsa 
                        {
                            MessageBox.Show("Güncelleme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListData();
                            GetStudents();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex) {

                    MessageBox.Show("Hata: "+ex.Message);
                }
            }
        }

        private void btnrapor_Click(object sender, EventArgs e)
        {
            
            pnlraporlar.Visible = true;
            label9.Text = "Raporlar";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                int ogrenciSayisi = GetCount(conn, "SELECT COUNT(*) FROM Ogrenciler");
                int ogretmenSayisi = GetCount(conn, "SELECT COUNT(*) FROM Ogretmenler");
                int dersSayisi = GetCount(conn, "SELECT COUNT(*) FROM Dersler");
                int matgecenogrenciler = GetCount(conn, "SELECT COUNT(*) FROM Ogrenciler WHERE MatematikNot >=50");
                int matkalanogrenciler = GetCount(conn, "SELECT COUNT(*) FROM Ogrenciler WHERE MatematikNot <50");

                labelogrnc.Text = ogrenciSayisi.ToString();
                lblogretmen.Text = dersSayisi.ToString();
                lblders.Text = dersSayisi.ToString();
                lblbaşarılı.Text = matgecenogrenciler.ToString();
                lblbaşarısız.Text = matkalanogrenciler.ToString();
            }
        }
    }
}
