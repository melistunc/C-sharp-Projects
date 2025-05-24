using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaSystem
{
    internal class DatabaseHelper
    {
        // VERİTABANINDAN ÇEKME
        private OleDbConnection connnection; // değişken tanımladık.
                                             //private string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\AjandaDBB.mdb";
        private string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\AjandaDBBB.mdb";
            

        // VERİTABANINDAKİ VERİLERİ GETİRME
        public DatabaseHelper() // conscructor metod kurucu metod, class çağırıldığında ilk çalışan blog'tur.
        {
            connnection = new OleDbConnection (connectionstring);  // tanımladığımız değişkeni kurucu metotta uygulama başlatıldığı gibi çalışması için new ile nesneyi gerçekleştirdik.
        }

        // ekle formu için bir metot.
        private void ExecuteQuery(OleDbCommand cmd)
        {
            try
            {
                if (connnection.State == ConnectionState.Closed) // bağlantı kapalıysa bağlantıyı aç
                {
                    connnection.Open();
                }
                
                cmd.ExecuteNonQuery();
              System.Windows.Forms.MessageBox.Show("İşlem başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {

               System.Windows.Forms.MessageBox.Show("Hata: "+ ex.Message);
            }
            finally
            {
                if (connnection.State == ConnectionState.Open) // bağlantı açıksa kapat.
                {
                    connnection.Close();
                }
            }
        }

        // NOTLARI LİSTELE
        public DataTable Listele()
        {
            // tüm ajandaları listeleme işlemi

            DataTable dt = new DataTable(); // datatable türünde nesne.
            string query = "SELECT * FROM Ajanda";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connectionstring); // verileirmizi alırız adapter ile. sorgumuz ile veritabanındaki verileri aldık.
            adapter.Fill(dt); // oluşturduğumuz datatable'ları okuduğumuz adapter ile doldur.
            return dt; // geriye datatable döndür.
        }

        // DATA GÜNCELLEME IDYE GÖRE NOT GETİR
        public DataTable IdyeGoreDataGetir(int id)
        {
            DataTable dataTable = new DataTable();
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ajanda WHERE ID = @id", connnection))
            {
                cmd.Parameters.AddWithValue("@id",id);
                connnection.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd); // dataları alıyoruz.
                dataAdapter.Fill(dataTable); // dataadapterı datatable ile doldur.
            }
            return dataTable;
        }

        // YENİ NOT EKLE
        // ekle butonu ve ekle formu için ekle metodu.
        public void DataEkle(string tarih, string mesaj)
        {
            string query = "INSERT INTO Ajanda (mesaj, mesaj_tarih) VALUES (@mesaj, @mesaj_tarih)"; // ekleme sql kodu.
            OleDbCommand cmd = new OleDbCommand(query, connnection);
            cmd.Parameters.AddWithValue("@mesaj",mesaj);
            cmd.Parameters.AddWithValue("@mesaj_tarih", tarih);

            ExecuteQuery(cmd); // metodu çalıştırdık.

            
        }

        // NOT GÜNCELLE
        public void NotGuncelle(int id, string tarih, string mesaj)
        {
            string query = "UPDATE Ajanda SET mesaj_tarih = @mesaj_tarih, mesaj= @mesaj WHERE ID= @id";

            OleDbCommand cmd = new OleDbCommand(query,connnection);

            cmd.Parameters.AddWithValue("@mesaj_tarih", tarih);
            cmd.Parameters.AddWithValue("@mesaj", mesaj);
            cmd.Parameters.AddWithValue("@id", id);

            ExecuteQuery(cmd);
        }

        // IDYE VE TARİHE GÖRE NOT SİL
        public void NotSil(int id = int.MinValue, int durum =0, DateTime? tarih = null)
        {
            if (durum == 0) // eğer durum 0'sa id'ye göre silme işlemi yap
            {
                string query = "DELETE FROM Ajanda WHERE ID= @id";
                OleDbCommand cmd = new OleDbCommand(query, connnection);
                cmd.Parameters.AddWithValue("@id", id);

                ExecuteQuery(cmd);
            }
            else if (durum == 1) // durum 1 ise mesaj_tarih'e göre silme işlemi yap.
            {
                string query = "DELETE FROM Ajanda WHERE mesaj_tarih = @mesaj_tarih";
                OleDbCommand cmd = new OleDbCommand(query, connnection);
                cmd.Parameters.AddWithValue("@mesaj_tarih",tarih);

                ExecuteQuery(cmd);
            }
        }

        // TABLODAKİ TÜM TARİHLERİ LİSTE HALİNE GETİR
        public List<DateTime> TumNotTarihleriniGetir() // liste türünde bir datetime döndürecek
        {
            List<DateTime> list = new List<DateTime>();
            string query = "SELECT mesaj_tarih FROM Ajanda";

            using (OleDbCommand cmd = new OleDbCommand(query, connnection))
            {
                connnection.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) // okunabilecek data var mı varsa listeye ekle
                    {
                        if (reader["mesaj_tarih"] != DBNull.Value && DateTime.TryParse(reader["mesaj_tarih"].ToString(), out DateTime dbTarih) ) // gelen mesaj_tarih  veritabanında var mı yok mu baktık. bu satırda datatbase null mı değil mi. varsa onu datetime türüne çevirdik.
                        {
                            list.Add(dbTarih);
                        }
                    }
                }
                connnection.Close();
            }
                return list;
        }

        // BELİRLİ TARİHE AİT MESAJI GETİR.
        public string MesajGetir(DateTime tarih)
        {
            string mesaj = string.Empty;
            string query = "SELECT mesaj FROM Ajanda WHERE mesaj_tarih = @mesaj_tarih";

            using (OleDbCommand cmd = new OleDbCommand(query,connnection))
            {
                cmd.Parameters.AddWithValue("@mesaj_tarih",tarih);

                connnection.Open();

                object result = cmd.ExecuteScalar(); // scalar ilk satır alır.

                if (result != null)
                {
                    mesaj = result.ToString();
                }
            }
            return mesaj;
        }
    }
}
