using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPop.Model
{
    public class AvioKompanija: ICloneable
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Deleted { get; set; }



        public override string ToString()
        {
            return Naziv;
        }

        public object Clone()
        {
            AvioKompanija avioKompanija = new AvioKompanija
            {
                Id = this.Id,
                Naziv = this.Naziv,
                Deleted = this.Deleted
            };
            return avioKompanija;
            
        }
    }
}
