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
using System.Collections.ObjectModel;

namespace ProjekatPop.DAO
{
    public class AerodromDAO
    {
        public static Aerodrom vratiAerodrom(int id)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Aerodrom WHERE AerodromId = @AerodromId AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("AerodromId", id);
            Aerodrom ar = new Aerodrom();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    ar.Id = (int)dr["AerodromId"];
                    ar.Sifra = dr["Sifra"].ToString();
                    ar.Naziv = dr["Naziv"].ToString();
                    ar.Grad = dr["Grad"].ToString();
                    ar.Deleted = Convert.ToBoolean(dr["Deleted"]);   


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

            return ar;

        }

        public static ObservableCollection<Aerodrom>  vratiAerodrome()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Aerodrom WHERE Deleted = 0", cnn);

            ObservableCollection<Aerodrom> lista = new ObservableCollection<Aerodrom>();
           

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Aerodrom ar = new Aerodrom();
                    ar.Id = (int)dr["AerodromId"];
                    ar.Sifra = dr["Sifra"].ToString();
                    ar.Naziv = dr["Naziv"].ToString();
                    ar.Grad = dr["Grad"].ToString();
                    ar.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    lista.Add(ar);
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

            return lista;

        }

        public static int napraviAerodrom(Aerodrom aerodrom)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Aerodrom VALUES ");
            sb.AppendLine("(@Sifra,@Naziv, @Grad , 0)");
            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Sifra",aerodrom.Sifra);
            komanda.Parameters.AddWithValue("@Naziv", aerodrom.Naziv);
            komanda.Parameters.AddWithValue("@Grad", aerodrom.Grad);

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

        public static int izmeniAerodrom(Aerodrom aerodrom)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Aerodrom SET ");
            sb.AppendLine("Naziv = @Naziv,Grad = @Grad, Deleted = @Deleted WHERE AerodromID = @Id");
            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

           
            komanda.Parameters.AddWithValue("@Naziv", aerodrom.Naziv);
            komanda.Parameters.AddWithValue("@Grad", aerodrom.Grad);
            komanda.Parameters.AddWithValue("@Deleted", aerodrom.Deleted);
            komanda.Parameters.AddWithValue("@Id", aerodrom.Id);

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

        public static int izbrisiAerdrom(Aerodrom aerodrom)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Aerodrom SET ");
            sb.AppendLine("Deleted = 1 WHERE AerodromId = @Id");
            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);


           
            komanda.Parameters.AddWithValue("@Id", aerodrom.Id);

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

