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
    public partial class Form1 : Form
    {
        // form hareketi
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        DatabaseHelper dbHelper = new DatabaseHelper(); // oluşturduğumuz class'tan nesne ürettik.
        private void Listelee() // listelee metodu oluşturduk.
        {
            dataGridView1.DataSource = dbHelper.Listele(); // bu nesneyi oluşturduğumuz metot ile çalıştırdık. Listele metodu, databasehelper'dan gelen metot. 
        }
        public Form1()
        {
            InitializeComponent();
            Listelee(); // metod üzerinden direkt çağırdık.

            this.Size = new Size(1200, 483); // istediğin boyut
            this.StartPosition = FormStartPosition.CenterScreen; // ekran ortasına al
            this.WindowState = FormWindowState.Normal; // maximize olmasın
            timer1.Tick += timer1_Tick; // tick kısmını sürekli çalıştır.
            timer1.Start();
        }
       

        private void pctexit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // çarpıya basınca kapanma.
        }

        // form hareketi
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            // oluşturduğumuz guncelle formunu göster dedik. nesneye atayıp bu aksiyonu çalıştırdık.

            if (dataGridView1.SelectedRows.Count == 0) // herhangi bir data seçilmediyse.
            {
                MessageBox.Show("Güncellemek için bir not seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Guncellecs form = new Guncellecs();
            form.gelenID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value); // datagridviewde ilk elemanın value'sini al ve bunu string'E çevir. Gelen ID'yi data'ya gönderiyorum ve 
            form.ShowDialog(); // formumu açıyorum.
            Listelee();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            // butona bastığımızda ekle formumuz açılsın
            Eklecs form1 = new Eklecs();
            form1.ShowDialog(); // ekle form kapanana kadar bekler. ekle form kapanınca listeler
            Listelee();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // gridlerdeki başlıkların ismini değiştirdik.
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "MESAJ";
            dataGridView1.Columns[2].HeaderText = "TARIH";
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) // herhangi bir data seçilmediyse.
            {
                MessageBox.Show("Silmek için bir not seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }

            int tiklanilanNotID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value); // ilk elemanın içerisindeki id'nin valuesini aldık.

            DialogResult sonuc = MessageBox.Show("Bu notu silmek stediğinizden emin misiniz?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (sonuc==DialogResult.Yes)
            {
                dbHelper.NotSil(tiklanilanNotID);
                Listelee();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<DateTime> notTarihleri = dbHelper.TumNotTarihleriniGetir(); // tüm tarihleri list olarak vercecek.
            DateTime suankizaman = DateTime.Now;
            foreach (DateTime notTarih in notTarihleri) // datetime türünde notuun tarihini al nottarihleirnde dolaş.
            {
                if (notTarih.Year == suankizaman.Year && notTarih.Month == suankizaman.Month && notTarih.Day == suankizaman.Day && notTarih.Hour == suankizaman.Hour && notTarih.Minute == suankizaman.Minute)
                {
                    string mesaj = dbHelper.MesajGetir(notTarih);
                    if (!string.IsNullOrEmpty(mesaj)) // mesaj boş değilse
                    {
                        MessageBox.Show(mesaj, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dbHelper.NotSil( durum: 1 ,tarih: notTarih); //silme metodunu çalıştırdık , dışaırdan value vererek. 
                        Listelee();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // formun aşağıda da çalışmasını sağlar.
        }
    }
}
