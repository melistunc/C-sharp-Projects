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
    public partial class Eklecs : Form
    {

        DatabaseHelper dbHelper = new DatabaseHelper(); // miras aldık.

        // form hareketi
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Eklecs()
        {
            InitializeComponent(); 
            this.Size = new Size(844, 502); // istediğin boyut
            this.StartPosition = FormStartPosition.CenterScreen; // ekran ortasına al
            this.WindowState = FormWindowState.Normal; // maximize olmasın
        }

        private void Eklecs_Load(object sender, EventArgs e)
        {
            sectarih.MinDate = DateTime.Now;
        }

        // form hareketi
        private void Eklecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmesaj.Text)) // txt kısmımız boş mu dolu mu kontrol ettiriyorsa boşsa true verir ama biz burada bış değilse bu işlemleri yap diyoruz. 
            {
                dbHelper.DataEkle(sectarih.Value.ToString("dd.MM.yyyy HH:mm"), txtmesaj.Text); // ekleme işlemi.
                this.Hide();
                
            }

            else
            {
                MessageBox.Show("Mesaj alanını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
