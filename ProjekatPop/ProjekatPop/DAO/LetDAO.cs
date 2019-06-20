using ProjekatPop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

using ProjekatPop.DataBase;

namespace ProjekatPop.DAO
{
    public class LetDAO
    {
        public static Let vratiLet(int id)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Let WHERE LetId = @LetId AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("LetId", id);
            Let l = new Let();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    l.Id = (int)dr["LetId"];
                    l.Sifra = dr["Sifra"].ToString();
                    l.Pilot = dr["Pilot"].ToString();                    
                    l.vremePolaska = DateTime.Parse(dr["VremePolaska"].ToString());
                    l.vremeDolaska = DateTime.Parse(dr["VremeDolaska"].ToString());
                    l.PolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["PolazniAerodrom"]);
                    l.DolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["DolazniAerodrom"]);
                    l.Avion = AvionDAO.vratiAvion((int)dr["AvionId"]);
                    l.Cena = (decimal)dr["Cena"];
                    l.Deleted = Convert.ToBoolean(dr["Deleted"]);


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

            return l;

        }

        public static Let vratiLetPrekoSifre(string sifra)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Let WHERE Sifra = @Sifra AND Deleted = 0", cnn);

            komanda.Parameters.AddWithValue("@Sifra", sifra.ToString());
            Let l = new Let();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    l.Id = (int)dr["LetId"];
                    l.Sifra = dr["Sifra"].ToString();
                    l.Pilot = dr["Pilot"].ToString();
                    l.vremePolaska = DateTime.Parse(dr["VremePolaska"].ToString());
                    l.vremeDolaska = DateTime.Parse(dr["VremeDolaska"].ToString());
                    l.PolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["PolazniAerodrom"]);
                    l.DolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["DolazniAerodrom"]);
                    l.Avion = AvionDAO.vratiAvion((int)dr["AvionId"]);
                    l.Cena = (decimal)dr["Cena"];
                    l.Deleted = Convert.ToBoolean(dr["Deleted"]);


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

            if (l.Id != 0)
            {
                return l;
            }
            return null;
          

        }

        public static ObservableCollection<Let> VratiLetove()
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Let WHERE Deleted = 0", cnn);

            ObservableCollection<Let> letovi = new ObservableCollection<Let>();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Let l = new Let();
                    l.Id = (int)dr["LetId"];
                    l.Sifra = dr["Sifra"].ToString();
                    l.Pilot = dr["Pilot"].ToString();
                    l.vremePolaska = DateTime.Parse(dr["VremePolaska"].ToString());
                    l.vremeDolaska = DateTime.Parse(dr["VremeDolaska"].ToString());
                    l.PolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["PolazniAerodrom"]);
                    l.DolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["DolazniAerodrom"]);
                    l.Avion = AvionDAO.vratiAvion((int)dr["AvionId"]);
                    l.Cena = (decimal)dr["Cena"];
                    l.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    if (l.DolazniAerodrom.Deleted || l.DolazniAerodrom.Naziv == null)
                    {
                        IzbrisiLet(l);
                    }
                    else if (l.PolazniAerodrom.Deleted || l.PolazniAerodrom.Naziv == null)
                    {
                        IzbrisiLet(l);
                    }
                    else if  (l.Avion.Deleted || l.Avion == null)
                    {
                        IzbrisiLet(l);
                    }
                    else
                    {                        
                        letovi.Add(l);
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


            return letovi;

        }


        public static int IzmeniLet(Let let)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Let SET ");
            sb.AppendLine("Sifra=@Sifra,Pilot = @Pilot,VremePolaska = @VremePolaska,VremeDolaska = @VremeDolaska, ");
            sb.AppendLine("PolazniAerodrom = @PolazniAerodrom,DolazniAerodrom = @DolazniAerodrom, ");
            sb.AppendLine("AvionId = @AvionId,Cena = @Cena, Deleted = @Deleted ");
            sb.AppendLine("WHERE LetId = @LetId ");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Sifra", let.Sifra);
            komanda.Parameters.AddWithValue("@Pilot", let.Pilot);
            komanda.Parameters.AddWithValue("@VremePolaska", let.vremePolaska);
            komanda.Parameters.AddWithValue("@VremeDolaska", let.vremeDolaska);
            komanda.Parameters.AddWithValue("@PolazniAerodrom", let.PolazniAerodrom.Id);
            komanda.Parameters.AddWithValue("@DolazniAerodrom", let.DolazniAerodrom.Id);
            komanda.Parameters.AddWithValue("@AvionId", let.Avion.Id);
            komanda.Parameters.AddWithValue("@Cena", let.Cena);
            komanda.Parameters.AddWithValue("@Deleted", let.Deleted);
            komanda.Parameters.AddWithValue("@LetId", let.Id);



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


        public static int IzbrisiLet(Let let)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Let SET ");
            sb.AppendLine("Deleted= 1 ");
            
            sb.AppendLine("WHERE LetId = @LetId ");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            
            komanda.Parameters.AddWithValue("@LetId", let.Id);



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



        public static int NapraviLet(Let let)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Let VALUES ");
            sb.AppendLine("(@Sifra, @Pilot, @VremePolaska, @VremeDolaska,@PolazniAerodrom, ");
            sb.AppendLine("@DolazniAerodrom, @AvionId, @Cena, 0)");
            

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@Sifra", let.Sifra);
            komanda.Parameters.AddWithValue("@Pilot", let.Pilot);
            komanda.Parameters.AddWithValue("@VremePolaska", let.vremePolaska);
            komanda.Parameters.AddWithValue("@VremeDolaska", let.vremeDolaska);
            komanda.Parameters.AddWithValue("@PolazniAerodrom", let.PolazniAerodrom.Id);
            komanda.Parameters.AddWithValue("@DolazniAerodrom", let.DolazniAerodrom.Id);
            komanda.Parameters.AddWithValue("@AvionId", let.Avion.Id);
            komanda.Parameters.AddWithValue("@Cena", let.Cena);


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

        public static ObservableCollection<Let> VratiPovratneLetove(Let let)
        {
            SqlConnection cnn = Konekcija.KreirajKoekciju();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT Let.LetId, Let.Sifra, Let.Pilot,Let.VremePolaska,Let.VremeDolaska, ");
            sb.AppendLine("Let.PolazniAerodrom,Let.DolazniAerodrom,Let.AvionId,Let.Cena,Let.Deleted FROM Let ");
            sb.AppendLine("INNER JOIN Avion ON let.AvionId = Avion.AvionId WHERE ");
            sb.AppendLine("Avion.AvioKompanijaId = @AvioKompanijaId AND Let.PolazniAerodrom = @PolazniAerodrom ");
            sb.AppendLine("AND Let.DolazniAerodrom = @DolazniAerodrom AND Let.Deleted = 0;");

            SqlCommand komanda = new SqlCommand(sb.ToString(), cnn);

            komanda.Parameters.AddWithValue("@AvioKompanijaId",let.Avion.AvioKompanija.Id);
            komanda.Parameters.AddWithValue("@PolazniAerodrom",let.DolazniAerodrom.Id);
            komanda.Parameters.AddWithValue("@DolazniAerodrom",let.PolazniAerodrom.Id);

            ObservableCollection<Let> letovi = new ObservableCollection<Let>();

            try
            {
                cnn.Open();
                SqlDataReader dr = komanda.ExecuteReader();

                while (dr.Read())
                {
                    Let l = new Let();
                    l.Id = (int)dr["LetId"];
                    l.Sifra = dr["Sifra"].ToString();
                    l.Pilot = dr["Pilot"].ToString();
                    l.vremePolaska = DateTime.Parse(dr["VremePolaska"].ToString());
                    l.vremeDolaska = DateTime.Parse(dr["VremeDolaska"].ToString());
                    l.PolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["PolazniAerodrom"]);
                    l.DolazniAerodrom = AerodromDAO.vratiAerodrom((int)dr["DolazniAerodrom"]);
                    l.Avion = AvionDAO.vratiAvion((int)dr["AvionId"]);
                    l.Cena = (decimal)dr["Cena"];
                    l.Deleted = Convert.ToBoolean(dr["Deleted"]);

                    if (l.DolazniAerodrom.Deleted || l.DolazniAerodrom.Naziv == null)
                    {
                        IzbrisiLet(l);
                    }
                    else if (l.PolazniAerodrom.Deleted || l.PolazniAerodrom.Naziv == null)
                    {
                        IzbrisiLet(l);
                    }
                    else if (l.Avion.Deleted || l.Avion == null)
                    {
                        IzbrisiLet(l);
                    }
                    else
                    {
                        letovi.Add(l);
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


            return letovi;

        }



    }
}
