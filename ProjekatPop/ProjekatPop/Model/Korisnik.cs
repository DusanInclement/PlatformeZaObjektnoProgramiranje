using ProjekatPop.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatPop.Model
{
    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChange("Id"); }
        }

        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChange("Ime"); }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChange("Prezime"); }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChange("Adresa"); }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChange("UserName"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChange("Password"); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChange("Email"); }
        }

        private Epol? pol;
        public Epol? Pol
        {
            get { return pol; }
            set { pol = value; OnPropertyChange("Pol"); }
        }

        private Etip tip;
        public Etip Tip
        {
            get { return tip; }
            set { tip = value; OnPropertyChange("Tip"); }
        }

        private bool deleted;
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public object Clone()
        {
            Korisnik korisnik = new Korisnik
            {
                Id = this.Id,
                Ime = this.Ime,
                Prezime = this.Prezime,
                Adresa = this.Adresa,
                Email = this.Email,
                UserName = this.UserName,
                Password = this.Password,
                Tip = this.Tip,
                Pol = this.Pol,
                Deleted = this.Deleted
            };
            return korisnik;
        }
    }



}
