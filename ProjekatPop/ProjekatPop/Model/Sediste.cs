using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
    public class Sediste
    {
        public int Id { get; set; }
        public int Red { get; set; }
        public int SedisteURedu { get; set; }
        public EtipSedista tipSedista { get; set; }
       
        public bool Deleted { get; set; }




        public override string ToString()
        {
            return  "Red br." + Red + " /Sediste br. " + SedisteURedu;
        }

    }
}
