using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using ProjekatPop.Model;
using ProjekatPop.DataBase;
using System.Data;

namespace ProjekatPop.DAO
{
    public class AvionDAO
    {
        public static ObservableCollection<Avion> vratiAvione()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Avion WHERE Deleted = 0", cnn);

            ObservableCollection<Avion> avioni = new ObservableCollection<Avion>();
          
            try
            {                
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();
                
                while (dr.Read())
                {                    
                    Avion a = new Avion();                 

                    a.Id = (int)dr["AvionId"];
                    int brRedovaEklase = (int)dr["BrojRedovaEkonomskeKlase"];
                    int brSedistaEklase = (int)dr["BrojSedistaUReduEkonomskeKlase"];
                    a.puniListuEkon(brRedovaEklase, brSedistaEklase);
                    int brRedovaBiznis = (int)dr["BrojRedovaBiznisKlase"];
                    int brSedistaBiznis = (int)dr["BrojSedistaUReduBiznisKlase"];
                    a.puniListuBiz(brRedovaBiznis, brSedistaBiznis);             

                    a.AvioKompanija = AvioKompanijaDAO.vratiAvioKompaniju((int)dr["AvioKompanijaId"]);
                    a.Naziv = dr["Naziv"].ToString();
                    a.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    if (a.AvioKompanija.Deleted || a.AvioKompanija.Naziv == null)
                    {
                        IzbirisAvio(a);
                        
                    }
                    else
                    {
                        avioni.Add(a);
                    }

                    
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

            return avioni;

        }



        public static Avion vratiAvion(int id)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Avion WHERE AvionId = @AvionId AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("AvionId", id);
            Avion a = new Avion();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    a.Id = (int)dr["AvionId"];
                    int brRedovaEklase = (int)dr["BrojRedovaEkonomskeKlase"];
                    int brSedistaEklase = (int)dr["BrojSedistaUReduEkonomskeKlase"];
                    a.puniListuEkon(brRedovaEklase, brSedistaEklase);
                    int brRedovaBiznis = (int)dr["BrojRedovaBiznisKlase"];
                    int brSedistaBiznis = (int)dr["BrojSedistaUReduBiznisKlase"];
                    a.puniListuBiz(brRedovaBiznis, brSedistaBiznis);

                    a.AvioKompanija = AvioKompanijaDAO.vratiAvioKompaniju((int)dr["AvioKompanijaId"]);
                    a.Naziv = dr["Naziv"].ToString();                    
                    a.Deleted = Convert.ToBoolean(dr["Deleted"]); 
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

            return a;

        }

        public static List<int> vratiBrSedita(Avion a)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Avion WHERE AvionId = @AvionId", cnn);

            komanda.Parameters.AddWithValue("AvionId", a.Id);
            List<int> lista = new List<int>();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    
                    int brRedovaEklase = (int)dr["BrojRedovaEkonomskeKlase"];
                    int brSedistaEklase = (int)dr["BrojSedistaUReduEkonomskeKlase"];
                    
                    int brRedovaBiznis = (int)dr["BrojRedovaBiznisKlase"];
                    int brSedistaBiznis = (int)dr["BrojSedistaUReduBiznisKlase"];

                    lista.Add(brRedovaEklase);
                    lista.Add(brSedistaEklase);
                    lista.Add(brRedovaBiznis);
                    lista.Add(brSedistaBiznis);


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

        public static int NapraviAvion(Avion avion, List<int> lista)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("INSERT INTO Avion VALUES ");
            sb.AppendLine("(@BrojRedovaEkonKlase, @BrojSEdistaUReduEkonKlase,@BrojRedovaBizKlase, ");
            sb.AppendLine(" @BrojSEdistaUReduBizKlase, @AvioKompanijaId, @Naziv, @Deleted);");
            

            SqlCommand komanda = new SqlCommand("INSERT INTO Avion VALUES (@BrojRedovaEkonKlase, @BrojSEdistaUReduEkonKlase, @BrojRedovaBizKlase, @BrojSEdistaUReduBizKlase,@AvioKompanijaId , @Naziv, 0)", cnn);

            komanda.Parameters.AddWithValue("@BrojRedovaEkonKlase",lista[0]);
            komanda.Parameters.AddWithValue("@BrojSEdistaUReduEkonKlase", lista[1]);
            komanda.Parameters.AddWithValue("@BrojRedovaBizKlase",lista[2]);
            komanda.Parameters.AddWithValue("@BrojSEdistaUReduBizKlase", lista[3]);
            komanda.Parameters.AddWithValue("@AvioKompanijaId", avion.AvioKompanija.Id);
            komanda.Parameters.AddWithValue("@Naziv", avion.Naziv);
            //komanda.Parameters.AddWithValue("@Deleted", 0);

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

        public static int IzmeniAvion(Avion avion)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Avion SET ");
            sb.AppendLine("Naziv = @Naziv , AvioKompanijaId = @AvioKompanijaId ");
            sb.AppendLine("WHERE AvionId = @AvionId");


            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Naziv", avion.Naziv);
            komanda.Parameters.AddWithValue("@AvioKompanijaId", avion.AvioKompanija.Id);
            komanda.Parameters.AddWithValue("@AvionId", avion.Id);

           

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
        public static int IzbirisAvio(Avion avion)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Avion SET ");
            sb.AppendLine("Deleted = 1");
            sb.AppendLine("WHERE AvionId = @AvionId");


            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            
            komanda.Parameters.AddWithValue("@AvionId", avion.Id);



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
