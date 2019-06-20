using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using ProjekatPop.Model;
using ProjekatPop.DAO;

namespace ProjekatPop.DataBase
{
    class Aplikacija
    {
        public ObservableCollection<Aerodrom> Aerodromi { get; set; }
        public ObservableCollection<AvioKompanija> AvioKompanije { get; set; }
        public ObservableCollection<Avion> Avioni { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Let> Letovi { get; set; }
        public ObservableCollection<Sediste> Sedista { get; set; }
        public ObservableCollection<Karta> Karte { get; set; }
        public Korisnik LoggedUser { get; set; }

        public static Aplikacija instance = null;


        private Aplikacija()
        {
            this.LoggedUser = null;
            this.Aerodromi = new ObservableCollection<Aerodrom>();
            this.Letovi = new ObservableCollection<Let>();
            this.Korisnici = new ObservableCollection<Korisnik>();
            this.AvioKompanije = new ObservableCollection<AvioKompanija>();
            this.Avioni = new ObservableCollection<Avion>();
            this.Sedista = new ObservableCollection<Sediste>();
            this.Karte = new ObservableCollection<Karta>();

            UcitajKarte();
            UcitajLetove();
            UcitajAvione();
            UcitajAvioKompanije();
            UcitajAerodrome();
            UcitajKorisnike();
            
           
            
           

        }


        public static Aplikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Aplikacija();
                }
                return instance;
            }
        }


        public void UcitajKorisnike()
        {
            Korisnici.Clear();

            foreach (Korisnik k in KorisnikDAO.VratiKorisnike())
            {
                this.Korisnici.Add(k);
            }

        }

        public void UcitajAvioKompanije()
        {
            AvioKompanije.Clear();           
            foreach (AvioKompanija av in AvioKompanijaDAO.vratiAvioKompanije())
            {
                this.AvioKompanije.Add(av);
            }
        }

        public void UcitajAvione()
        {
            Avioni.Clear();

            foreach (Avion av in AvionDAO.vratiAvione())
            {
                this.Avioni.Add(av);
            }
            

        }

        public void UcitajKarte()
        {
            Karte.Clear();

            foreach (Karta av in KartaDAO.vratiKarte())
            {
                this.Karte.Add(av);
            }

        }

        public void UcitajAerodrome()
        {
            Aerodromi.Clear();
            foreach (Aerodrom av in AerodromDAO.vratiAerodrome())
            {
                this.Aerodromi.Add(av);
            }

        }

        public void UcitajLetove()
        {
            Letovi.Clear();
            foreach (Let l in LetDAO.VratiLetove())
            {
                this.Letovi.Add(l);
            }
        }




    }
}
