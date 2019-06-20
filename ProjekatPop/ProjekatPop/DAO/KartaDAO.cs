using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using ProjekatPop.Model;
using ProjekatPop.DataBase;

namespace ProjekatPop.DAO
{
    public class KartaDAO
    {
        public static ObservableCollection<Karta> vratiKarte()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Karta WHERE Deleted = 0", cnn);

            ObservableCollection<Karta> karte = new ObservableCollection<Karta>();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Karta k = new Karta();

                    k.KartaId = (int)dr["KartaId"];
                    k.Let = LetDAO.vratiLet((int)dr["LetId"]);
                    Sediste s = new Sediste();
                    s.Id = 1;
                    s.Red = (int)dr["BrojReda"];
                    s.SedisteURedu = (int)dr["BrojSedista"];
                    EtipSedista tip;
                    Enum.TryParse(dr["Klasa"].ToString(), out tip);
                    s.tipSedista = tip;
                    s.Deleted = false;
                    k.Sediste = s;
                    k.Korisnik = KorisnikDAO.vratiKorisnika((int)dr["KorisnikId"]);
                    k.Kapija = dr["Kapija"].ToString();
                    k.Cena = (decimal)dr["Cena"];
                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    if (k.Let.Deleted || k.Let.Sifra == null)
                    {
                        IzbrisiKartu(k);
                       
                    }
                    else
                    {
                        karte.Add(k);
                    }
                    
                }
                cnn.Close();
            }
            catch (Exception xcp)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                MessageBox.Show(xcp.Message);
                return null;
            }
            return karte;
        }

        public static List<Karta> VratiKarteULetu(Let let)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Karta WHERE LetId = @LetID AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("@LetID", let.Id);
            List<Karta> karte = new List<Karta>();


            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Karta k = new Karta();
                    k.KartaId = (int)dr["KartaId"];
                    k.Let = LetDAO.vratiLet((int)dr["LetId"]);
                    Sediste s = new Sediste();
                    s.Id = 1;
                    s.Red = (int)dr["BrojReda"];
                    s.SedisteURedu = (int)dr["BrojSedista"];
                    EtipSedista tip;
                    Enum.TryParse(dr["Klasa"].ToString(), out tip);
                    s.tipSedista = tip;
                    s.Deleted = false;
                    k.Sediste = s;
                    k.Korisnik = KorisnikDAO.vratiKorisnika((int)dr["KorisnikId"]);
                    k.Kapija = dr["Kapija"].ToString();
                    k.Cena = (decimal)dr["Cena"];
                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    karte.Add(k);
                }
            }
            catch (Exception xcp)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                MessageBox.Show(xcp.Message);
                return null;
            }

            return karte;


        }

        public static ObservableCollection<Karta> VratiMojeKarte(Korisnik u)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Karta WHERE KorisnikId = @KorisnikId AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("@KorisnikId", u.Id);
            ObservableCollection<Karta> karte = new ObservableCollection<Karta>();


            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Karta k = new Karta();
                    k.KartaId = (int)dr["KartaId"];
                    k.Let = LetDAO.vratiLet((int)dr["LetId"]);
                    Sediste s = new Sediste();
                    s.Id = 1;
                    s.Red = (int)dr["BrojReda"];
                    s.SedisteURedu = (int)dr["BrojSedista"];
                    EtipSedista tip;
                    Enum.TryParse(dr["Klasa"].ToString(), out tip);
                    s.tipSedista = tip;
                    s.Deleted = false;
                    k.Sediste = s;
                    k.Korisnik = KorisnikDAO.vratiKorisnika((int)dr["KorisnikId"]);
                    k.Kapija = dr["Kapija"].ToString();
                    k.Cena = (decimal)dr["Cena"];
                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    karte.Add(k);
                }
            }
            catch (Exception xcp)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                MessageBox.Show(xcp.Message);
                return null;
            }

            return karte;


        }

        public static int NaparviKartu(Karta k)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Karta VALUES ");
            sb.AppendLine("(@LetId, @BrojReda, @BrojSedista, @KorisnikId, @Klasa,@Kapija,@Cena, @Deleted)");

            SqlCommand komanda = new SqlCommand(sb.ToString(),cnn);

            komanda.Parameters.AddWithValue("@LetId", k.Let.Id);
            komanda.Parameters.AddWithValue("@BrojReda", k.Sediste.Red);
            komanda.Parameters.AddWithValue("@BrojSedista", k.Sediste.SedisteURedu);
            komanda.Parameters.AddWithValue("@KorisnikId", k.Korisnik.Id);
            komanda.Parameters.AddWithValue("@Klasa", k.Sediste.tipSedista.ToString());
            komanda.Parameters.AddWithValue("@Kapija", k.Kapija);
            komanda.Parameters.AddWithValue("@Cena", k.Cena);
            komanda.Parameters.AddWithValue("@Deleted", 0);



            try
            {
                cnn.Open();
                komanda.ExecuteNonQuery();
                cnn.Close();
                return 0;
                
            }
            catch (Exception xcp)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                MessageBox.Show(xcp.Message);
                return -1;
            }


        }

        public static int IzbrisiKartu(Karta k)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Karta SET ");
            sb.AppendLine("Deleted = 1 WHERE KartaId = @Id");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Id", k.KartaId);
            



            try
            {
                cnn.Open();
                komanda.ExecuteNonQuery();
                cnn.Close();
                return 0;

            }
            catch (Exception xcp)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                MessageBox.Show(xcp.Message);
                return -1;
            }


        }

    }




}
