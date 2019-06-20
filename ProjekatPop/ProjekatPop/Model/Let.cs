using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
   public class Let
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Pilot { get; set; }
        public Aerodrom PolazniAerodrom { get; set; }
        public Aerodrom DolazniAerodrom { get; set; }
        public DateTime vremePolaska { get; set; }
        public DateTime vremeDolaska { get; set; }        
        
        public Avion Avion { get; set; }
        public decimal Cena { get; set; }
        public bool Deleted { get; set; }



        public override string ToString()
        {
            return Sifra;
        }


    }
}
