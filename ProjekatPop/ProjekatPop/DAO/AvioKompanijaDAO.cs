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
    public class AvioKompanijaDAO
    {
        public static AvioKompanija vratiAvioKompaniju(int id)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM AvioKompanija WHERE AvioKompanijaID = @AvioKompanijaId AND Deleted = 0",cnn);

            komanda.Parameters.AddWithValue("AvioKompanijaId", id);
            AvioKompanija av = new AvioKompanija();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    av.Id = (int)dr["AvioKompanijaId"];
                    av.Naziv = dr["Naziv"].ToString();
                    av.Deleted = Convert.ToBoolean(dr["Deleted"]);
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

            return av;

        }

        public static AvioKompanija vratiAvioKompanijuPrekoImena(string naziv)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM AvioKompanija WHERE Naziv = @Naziv AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("Naziv", naziv);
            AvioKompanija av = new AvioKompanija();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    av.Id = (int)dr["AvioKompanijaId"];
                    av.Naziv = dr["Naziv"].ToString();
                    av.Deleted = Convert.ToBoolean(dr["Deleted"]);
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

            return av;

        }


        public static ObservableCollection<AvioKompanija> vratiAvioKompanije()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM AvioKompanija WHERE Deleted = 0", cnn);

            ObservableCollection<AvioKompanija> lista = new ObservableCollection<AvioKompanija>();
            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    AvioKompanija av = new AvioKompanija();
                    av.Id = (int)dr["AvioKompanijaId"];
                    av.Naziv = dr["Naziv"].ToString();
                    av.Deleted = Convert.ToBoolean(dr["Deleted"]);
                    lista.Add(av);
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

        public static int DodajAvioKompaniju(AvioKompanija av)
        { 
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("INSERT INTO AvioKompanija VALUES (@Naziv,@Deleted)", cnn);

            komanda.Parameters.AddWithValue("@Naziv", av.Naziv);
            komanda.Parameters.AddWithValue("@Deleted", 0);

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

        public static int IzmeniAvioKompaniju(AvioKompanija av)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE AvioKompanija SET ");
            sb.AppendLine("Naziv = @Naziv");           
            sb.AppendLine("WHERE AvioKompanijaId = @AvioKompanijaId ");




            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);
            komanda.Parameters.AddWithValue("@Naziv", av.Naziv);         

            komanda.Parameters.AddWithValue("@AvioKompanijaId", av.Id);




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

        public static int IzbirisAvioKompaniju(AvioKompanija av)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE AvioKompanija SET ");
            sb.AppendLine("Deleted = 1");
            sb.AppendLine("WHERE AvioKompanijaId = @AvioKompanijaId; ");

            sb.AppendLine("UPDATE Avion SET ");
            sb.AppendLine("Deleted = 1");
            sb.AppendLine("WHERE AvioKompanijaId = @AvioKompanijaId; ");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);
            
            komanda.Parameters.AddWithValue("@AvioKompanijaId", av.Id);




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
