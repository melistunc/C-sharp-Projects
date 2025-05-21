using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentNoteSystem.forms
{
    public partial class Ogrenciler: Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OgrenciNotSistemiDBBBB.mdb"; // veritabanı bağladık.

        public int OgrenciNo;
        public Ogrenciler()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            using (OleDbConnection cnn = new OleDbConnection(connectionString))
            {
                cnn.Open();

                string query = "SELECT * FROM Ogrenciler WHERE Numara = @numara";

                using (OleDbCommand  cmd = new OleDbCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@numara", OgrenciNo);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) // datalar okunuyorsa 
                        {
                            adlbl.Text = reader["Ad"].ToString();
                            soyadlbl.Text = reader["Soyad"].ToString();
                            ıdlbl.Text = reader["ID"].ToString();
                            sifrelbl.Text = reader["Sifre"].ToString();
                            fiziklbl.Text = reader["FizikNot"].ToString();
                            marlblb.Text = reader["MatematikNot"].ToString();
                            turkcelbl.Text = reader["TurkceNOt"].ToString();
                            felsefelbl.Text = reader["FelsefeNot"].ToString();
                            biyolbl.Text = reader["BiyolojiNOt"].ToString();
                        }
                    }
                }
            }
        }
    }
}
