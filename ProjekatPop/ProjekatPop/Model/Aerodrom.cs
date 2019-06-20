using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
    public class Aerodrom : ICloneable
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public bool Deleted { get; set; }



        public override string ToString()
        {
            return Grad;
        }

        public object Clone()
        {
            Aerodrom ar = new Aerodrom
            {
                Id = this.Id,
                Sifra = this.Sifra,
                Naziv = this.Naziv,
                Grad = this.Grad,
                Deleted = this.Deleted
            };
            return ar;
        }
    }
}
