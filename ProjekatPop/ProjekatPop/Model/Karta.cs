using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
    public class Karta
    {
        public int KartaId { get; set; }
        public Let Let { get; set; }
        public Sediste Sediste { get; set; }
        public Korisnik Korisnik { get; set; }
        public string Kapija { get; set; }
        public decimal Cena { get; set; }
        public bool Deleted { get; set; }



        public override string ToString()
        {
            return Let.Sifra + " " + Sediste.Red + " " + Sediste.SedisteURedu + " " + Sediste.tipSedista + " "
                + Korisnik.Ime + " " + Korisnik.Prezime + " " + Kapija + " " + Let.vremePolaska.ToString()
                  + " " + Let.vremeDolaska.ToString()  + " " + Let.PolazniAerodrom.Naziv + " " + Let.DolazniAerodrom.Naziv; 
        }


    }
}
