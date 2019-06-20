using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
    public class Avion : ICloneable
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Sediste> SedistaEkonomskeKlase { get; set; }
        public List<Sediste> SedistaBiznisKlase { get; set; }
        public AvioKompanija AvioKompanija { get; set; }
        public bool Deleted { get; set; }






        public void puniListuEkon(int a, int b)
        {
            List<Sediste> lista = new List<Sediste>();
            int idE = 1; 
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    Sediste s = new Sediste();
                    s.Id = idE;
                    s.Red = i;
                    s.SedisteURedu = j;
                    s.tipSedista = EtipSedista.Ekonomska;
                    s.Deleted = false;
                    lista.Add(s);
                    idE++;
                }
            }
            this.SedistaEkonomskeKlase = lista;
        }

        public void puniListuBiz(int a, int b)
        {
            List<Sediste> lista = new List<Sediste>();
            int idE = 1;
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {

                    Sediste s = new Sediste();
                    s.Id = idE;
                    s.Red = i;
                    s.SedisteURedu = j;
                    s.tipSedista = EtipSedista.Biznis;
                    s.Deleted = false;
                    lista.Add(s);
                    idE++;
                }
            }
            this.SedistaBiznisKlase = lista;
        }

        public override string ToString()
        {
            return Naziv;
        }

        public object Clone()
        {
            Avion avion = new Avion
            {
                Id = this.Id,
                Naziv = this.Naziv,
                SedistaEkonomskeKlase = this.SedistaEkonomskeKlase,
                SedistaBiznisKlase = this.SedistaBiznisKlase,
                AvioKompanija = this.AvioKompanija,
                Deleted = this.Deleted
            };
            return avion;
        }
    }
}
