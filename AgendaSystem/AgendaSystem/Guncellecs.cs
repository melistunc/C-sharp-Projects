using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaSystem
{
    public partial class Guncellecs : Form
    {

        // form hareketi
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        DatabaseHelper dbHelper = new DatabaseHelper();

        public int gelenID; // değişken oluşturduk.

        public Guncellecs()
        {
            InitializeComponent();
            this.Size = new Size(830, 587); // istediğin boyut
            this.StartPosition = FormStartPosition.CenterScreen; // ekran ortasına al
            this.WindowState = FormWindowState.Normal; // maximize olmasın

        }

        // hareket özelliği
        private void Guncellecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // kapanma işlemi
        private void pctexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Guncellecs_Load(object sender, EventArgs e)
        {
            // form yüklendiğinde minimum datetime'ı şu anki zaman seçebilirm yani öncesini göremem.
            tarih.MinDate = DateTime.Now;

            DataTable dt = dbHelper.IdyeGoreDataGetir(gelenID);// bu datatable dbhelperın içerisinden idyegöredata getir ve gelenıd'yi buraya verelim.

            if (dt.Rows.Count > 0) // eğer veri bulunduysa data varsa.
            {
                txtmesaj.Text = dt.Rows[0]["mesaj"].ToString(); // txtmesaj içine önceden içine yazılan metni getir yani form yüklendiğinde txt içine önceden yazılanlar görünsün.

                // saat ve tarihleri de getirsin diye.
                if (DateTime.TryParse(dt.Rows[0]["mesaj_tarih"].ToString(), out DateTime result))
                // dt içinden ilk elemanın mesaj_tarihini getir.
                // datetime türüne dönüştürmeye çalış içindeki parametreyi. tryparse, iki prametre alır ilki string , ikincisi dönüştürme işlemi başarılı olursa çıktı olarak datetime türünd ebir result verecek.
                {
                    tarih.Value = result;
                }
            }
             
        }

        private void btnguncellee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmesaj.Text)) // text içi doluysa
            {
                dbHelper.NotGuncelle(gelenID, tarih.Value.ToString("dd.MM.yyyy HH:mm"), txtmesaj.Text);
            }
            else
            {
                MessageBox.Show("Mesaj alanı zorunlu","UYarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
