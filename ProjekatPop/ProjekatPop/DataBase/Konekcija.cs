using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjekatPop.DataBase
{
    public class Konekcija
    {
        public static SqlConnection KreirajKoekciju()
        {
            string cnnMagacina = Properties.Settings.Default.AvioServisConnectionString;
            SqlConnection konekcija = new SqlConnection(cnnMagacina);

            return konekcija;
        }
    }
}
