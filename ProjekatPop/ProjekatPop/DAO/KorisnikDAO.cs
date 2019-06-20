using ProjekatPop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjekatPop.DataBase;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.ComponentModel;

namespace ProjekatPop.DAO
{
    public class KorisnikDAO 
    {
        

        public static ObservableCollection<Korisnik> VratiKorisnike()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("Select * FROM Korisnik WHERE Deleted = 0", cnn);

            ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Korisnik k = new Korisnik();

                    k.Id = (int)dr["KorisnikId"];
                    k.Ime = dr["Ime"].ToString();
                    k.Prezime = dr["Prezime"].ToString();
                    k.Email = dr["Email"].ToString();
                    k.Adresa = dr["Adresa"].ToString();                    
                    Epol pol;
                    Enum.TryParse(dr["Pol"].ToString(), out pol);
                    k.Pol = pol;  
                    k.UserName = dr["KorisnickoIme"].ToString();
                    k.Password = dr["Lozinka"].ToString();                   
                    Etip tip;
                    Enum.TryParse(dr["TipKorisnika"].ToString(), out tip);
                    k.Tip =  tip;

                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    korisnici.Add(k);

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

            return korisnici;
        }


        public static Korisnik vratiKorisnika(int id)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Korisnik WHERE KorisnikId = @KorisnikId AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("KorisnikId", id);
            Korisnik k = new Korisnik();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    k.Id = (int)dr["KorisnikId"];
                    k.Ime = dr["Ime"].ToString();
                    k.Prezime = dr["Prezime"].ToString();
                    k.Email = dr["Email"].ToString();
                    k.Adresa = dr["Adresa"].ToString();
                    Epol pol;
                    Enum.TryParse(dr["Pol"].ToString(), out pol);
                    k.Pol = pol;
                    k.UserName = dr["KorisnickoIme"].ToString();
                    k.Password = dr["Lozinka"].ToString();
                    Etip tip;
                    Enum.TryParse(dr["TipKorisnika"].ToString(), out tip);
                    k.Tip = tip;

                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);
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

            return k;

        }

        public static Korisnik vratiKorisnikaPrekoUserName(string userName)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Korisnik WHERE KorisnickoIme = @KorisnickoIme AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("KorisnickoIme", userName);
            Korisnik k = new Korisnik();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();


                while (dr.Read())
                {
                    k.Id = (int)dr["KorisnikId"];
                    k.Ime = dr["Ime"].ToString();
                    k.Prezime = dr["Prezime"].ToString();
                    k.Email = dr["Email"].ToString();
                    k.Adresa = dr["Adresa"].ToString();
                    Epol pol;
                    Enum.TryParse(dr["Pol"].ToString(), out pol);
                    k.Pol = pol;
                    k.UserName = dr["KorisnickoIme"].ToString();
                    k.Password = dr["Lozinka"].ToString();
                    Etip tip;
                    Enum.TryParse(dr["TipKorisnika"].ToString(), out tip);
                    k.Tip = tip;

                    k.Deleted = Convert.ToBoolean(dr["Deleted"]);
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

            if (k.Id != 0)
            {
                return k;
            }
            return null;

        }

        public static int UbaciKorisnika(Korisnik k)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("INSERT INTO Korisnik Values(@Ime, @Prezime, @Email, @Adresa, @Pol, @UserName, @Passoword, @Tip, @Deleted) ; SELECT SCOPE_IDENTITY();", cnn);

            komanda.Parameters.AddWithValue("@Ime", k.Ime);
            komanda.Parameters.AddWithValue("@Prezime", k.Prezime);
            komanda.Parameters.AddWithValue("@Email", k.Email);
            komanda.Parameters.AddWithValue("@Adresa", k.Adresa);
            if (k.Pol == null)
            {
                komanda.Parameters.AddWithValue("@Pol", string.Empty);
            }
            else
            {
                komanda.Parameters.AddWithValue("@Pol", k.Pol.ToString());
            }           
            komanda.Parameters.AddWithValue("@UserName", k.UserName);
            komanda.Parameters.AddWithValue("@Passoword", k.Password);
            komanda.Parameters.AddWithValue("@Tip", k.Tip.ToString());
            komanda.Parameters.AddWithValue("@Deleted", 0);           
            
            try
            {
                cnn.Open();
                int id =Convert.ToInt32(komanda.ExecuteScalar());           
                return id;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                
                cnn.Close();
            }


        }

        public static int IzmeniKorisnika(Korisnik k)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Korisnik SET ");
            sb.AppendLine("Ime = @Ime, Prezime = @Prezime, Email = @Email, Adresa = @Adresa, Pol = @Pol, ");
            sb.AppendLine("KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka, TipKorisnika = @Tip");
            sb.AppendLine("WHERE KorisnikId = @KorisnikId " );
           



            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Ime", k.Ime);
            komanda.Parameters.AddWithValue("@Prezime", k.Prezime);
            komanda.Parameters.AddWithValue("@Email", k.Email);
            komanda.Parameters.AddWithValue("@Adresa", k.Adresa);
            komanda.Parameters.AddWithValue("@Pol", k.Pol.ToString());
            komanda.Parameters.AddWithValue("@KorisnickoIme", k.UserName);
            komanda.Parameters.AddWithValue("@Lozinka", k.Password);
            komanda.Parameters.AddWithValue("@Tip", k.Tip.ToString());

            komanda.Parameters.AddWithValue("@KorisnikId", k.Id);


           

            try
            {
                cnn.Open();
                komanda.ExecuteNonQuery();
               
                return 0;
                
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                cnn.Close();
            }





        }

        public static int IzbrisiKorisnika(Korisnik k)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Korisnik SET ");
            sb.AppendLine("Deleted = 1");            
            sb.AppendLine("WHERE KorisnikId = @KorisnikId;");

            sb.AppendLine("UPDATE Karta SET ");
            sb.AppendLine("Deleted = 1");
            sb.AppendLine("WHERE KorisnikId = @KorisnikId;");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);
            komanda.Parameters.AddWithValue("@KorisnikId", k.Id);




            try
            {
                cnn.Open();
                komanda.ExecuteNonQuery();

                return 0;

            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                cnn.Close();
            }





        }







    }
}
