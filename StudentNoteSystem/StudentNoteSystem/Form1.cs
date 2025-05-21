using StudentNoteSystem.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentNoteSystem
{
    public partial class Form1: Form
    {
        // formu hareket ettirmek için kod
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OgrenciNotSistemiDBB.mdb"; // veritabanı bağladık.

        public Form1()
        {
            InitializeComponent();
        }

        // formu hareket ettirmek için kod.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { 
            
        
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // çarpıya bastığımızda kapanacak.
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // soru işaretine tıkladığımızda çıkan bilgi.
            MessageBox.Show("Öğrencilerin notlarını görüntülediği, öğretmenlerin not bilgisini sisteme girdiği ve yöneticilerin her iki tarafı da kontrol ettiği bir öğrenci not sistemi uygulaması.");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // isntagram linki eklemek.
            // link eklemek için process sınıfı kullanılır.
            Process.Start("https://www.instagram.com/"); // start içine link verdiğimizde o link açılır.
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // web linki eklemek için
            Process.Start("https://www.google.com/");
        }

        private void girisbtn_Click(object sender, EventArgs e)
        {
            string kullaniciadi = kaditexbox.Text;
            string sifre = sifretexbox.Text;
            string rol = "";

            if (kullaniciadi != "" && sifre != "") // kullanıcı adı textbox ve sifre textbox boş değilse burayı çalıştır
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString)) // using ile artık bağlantıyı kapatmak zorunda değiliz. işlem bittikten sonra açık olan bağlantı varsa onu kapatır hem de belleği temizler.oldebconnection'dan bir bağlantı nesne oluşturduk ve connecstring'i burada kullandık. oldeb connection'u açacak.
                {
                    conn.Open(); // connection'u açtık. kapatmaya gerek yok artık using yüzünden.

                    // öğrenci kodları
                    string queryString = "SELECT * FROM Ogrenciler WHERE Numara =@numara AND Sifre = @sifre"; // bağlantı string. tüm data'ları çek numarası parametreden gelen numara ve sifresi parametreden gelen sifre olacak. sql sorgusu.

                    using (OleDbCommand cmd = new OleDbCommand(queryString, conn)) // yukarıda yazdığımız query'i çalıştıracağız.querystring'i conn'dan çalıştır dedik.
                    {
                        cmd.Parameters.AddWithValue(@"numara", kullaniciadi); // numara parametresi kullanıcıadı'ndan gelecek.
                        cmd.Parameters.AddWithValue(@"sifre", sifre);

                        // yukarıdaki cmd.parameters'teki parametrelere uygun kişi var mı? diyoruz.
                        using (OleDbDataReader reader = cmd.ExecuteReader())  // dataları okuyan bir okuyucu. cmd içerisinden gelen data'yı okutacak. bu data'yı okuyabilmek için execute etmeliyiz.sorguyu çalıştırıyoruz ve bir datareader'e gönderiyoruz.
                        {
                            if (reader.Read()) // okunabilen bir data var mı? eğer data varsa true döndürür varsa öğrenci var yani öğrenci giriş yapmıştır.
                            {
                                // öğrenci formu açılır.
                                rol = "Öğrenci"; // okunursa öğrenci olacak.
                                Ogrenciler ogrenciler = new Ogrenciler();
                                ogrenciler.OgrenciNo = Convert.ToInt32( kullaniciadi);
                                this.Hide(); // normal formu gizle sonra ogrenci formu aç.
                                ogrenciler.ShowDialog(); // ogrenciler formunu aç.
                            }
                        }   
                    }

                    // öğretmen kodları
                    if (rol == "") // rol boşsa
                    {
                        string queryOgretmen = "SELECT * FROM Ogretmenler WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre "; // veritabanından verileri çekme kodu.

                        using(OleDbCommand cmd = new OleDbCommand(queryOgretmen, conn))
                        {
                            cmd.Parameters.AddWithValue(@"kullaniciAdi", kullaniciadi);
                            cmd.Parameters.AddWithValue(@"sifre", sifre);

                            //data okunuyor mu
                            using (OleDbDataReader reader = cmd.ExecuteReader())  // dataları okuyan bir okuyucu. cmd içerisinden gelen data'yı okutacak. bu data'yı okuyabilmek için execute etmeliyiz.sorguyu çalıştırıyoruz ve bir datareader'e gönderiyoruz.)
                            {
                                if (reader.Read()) // okunabilen bir data var mı? eğer data varsa true döndürür varsa öğrenci var yani öğrenci giriş yapmıştır.
                                {
                                    // öğrenci formu açılır.
                                    rol = "Öğretmen"; // okunursa öğretmen olacak.
                                    Ogretmen ogretmen = new Ogretmen();
                                    this.Hide(); // formu açtıktan sonra gizle öğretmen formunu aç.
                                    ogretmen.ShowDialog(); // ogretmen formu aç.
                                }
                            }
                        }
                    }
                }

                if (rol == "") // giriş kısmı boşsa
                {
                    MessageBox.Show("Kullanıcı bulunamadı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakılamaz.", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Stop); // ikinci string messagebo'taki title olur. Sonraki messageboxaltında OK butonu koyar.Sonraki messagebox'A bir icon koyar.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // yüklendiğinde imlecin text kullanıcı adına gelmesini isyiyorum.
            this.ActiveControl = kaditexbox; // formun aktif yeri kaditextbox olacak.
        }
    }
    }

