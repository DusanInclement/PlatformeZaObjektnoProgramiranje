using ProjekatPop.DAO;
using ProjekatPop.DataBase;
using ProjekatPop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for KupiKartu.xaml
    /// </summary>
    public partial class KupiKartu : Window
    {
        public enum Stanje { Nova,Povratna}
        private Stanje stanjeG;
        ICollectionView view;
        private Let mainLet = new Let();

        private bool Validacija()
        {
            if (string.IsNullOrEmpty(textBoxIme.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Ime");
                textBoxIme.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBoxPrezime.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Ime");
                textBoxPrezime.Focus();
                return false;
            }
            return true;
        }
        private void ZauszetaMesta()
        {
            List<Karta> karte = KartaDAO.VratiKarteULetu(mainLet);

            if (karte != null)
            {
                foreach (Karta k in karte)
                {
                    if (k.Sediste.tipSedista.Equals(EtipSedista.Biznis))
                    {
                        foreach (Sediste mainK in mainLet.Avion.SedistaBiznisKlase)
                        {
                            if (k.Sediste.Red == mainK.Red && k.Sediste.SedisteURedu == mainK.SedisteURedu)
                            {
                                mainK.Deleted = true;
                            }
                        }
                    }
                    if (k.Sediste.tipSedista.Equals(EtipSedista.Ekonomska))
                    {
                        foreach (Sediste mainK in mainLet.Avion.SedistaEkonomskeKlase)
                        {
                            if (k.Sediste.Red == mainK.Red && k.Sediste.SedisteURedu == mainK.SedisteURedu)
                            {
                                mainK.Deleted = true;
                            }
                        }
                    }
                }
            }

        }
        public KupiKartu(Let let, Stanje stanje)
        {
            mainLet = let;
            InitializeComponent();

            this.stanjeG = stanje;


            ZauszetaMesta();
            List<Sediste> listSedista = new List<Sediste>();
            listSedista = let.Avion.SedistaBiznisKlase;
            foreach (Sediste s in let.Avion.SedistaEkonomskeKlase)
            {
                listSedista.Add(s);
            }

            view = CollectionViewSource.GetDefaultView(listSedista);
            view.Filter = CustomFilter;

            

            dataGridSedista.ItemsSource = view;
            textBoxSifra.Text = let.Sifra;
            textBoxPilot.Text = let.Pilot;
            textBoxVremePolaska.Text = let.vremePolaska.ToString();
            textBoxVremeDolaska.Text = let.vremeDolaska.ToString();
            textBoxPolazniAerodrom.Text = let.PolazniAerodrom.ToString();
            textBoxDolazniAerodrom.Text = let.DolazniAerodrom.ToString();
            textBoxNazivAviona.Text = let.Avion.ToString();

            if (stanjeG == Stanje.Povratna)
            {
                decimal cenaPovratna = let.Cena - (let.Cena * 0.5M);
                textBoxCenaLeta.Text = cenaPovratna.ToString();
            }
            else
            {
                textBoxCenaLeta.Text = let.Cena.ToString();
            }          

            dataGridSedista.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (Aplikacija.Instance.LoggedUser != null)
            {
                textBoxIme.IsReadOnly = true;
                textBoxPrezime.IsReadOnly = true;
                textBoxIme.Text = Aplikacija.Instance.LoggedUser.Ime;
                textBoxPrezime.Text = Aplikacija.Instance.LoggedUser.Prezime;
            }


        }

        private bool CustomFilter(object obj)
        {
            Sediste sediste = (Sediste)obj;
            
            return sediste.Deleted == false; 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.dataGridSedista.Columns[0].Visibility = Visibility.Hidden;

            //this.dataGridEkonomskaSedista.Columns[3].Visibility = Visibility.Hidden;

            this.dataGridSedista.Columns[4].Visibility = Visibility.Hidden;
            this.dataGridSedista.Columns[2].Header = "Sediste u Redu";
            this.dataGridSedista.Columns[3].Header = "Tip Sedista";



        }

        private void buttonKupiKartu_Click(object sender, RoutedEventArgs e)
        {
            
            Korisnik korisnik = new Korisnik();

            if (dataGridSedista.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati sediste!");
                return;
            }

            Sediste s = (Sediste)dataGridSedista.SelectedItem;


            Karta k = new Karta();

            k.Let = mainLet;
            k.Sediste = s;
            if (Aplikacija.Instance.LoggedUser != null)
            {
                k.Korisnik = Aplikacija.Instance.LoggedUser;
            }
            else
            {
                if (Validacija())
                {
                    korisnik.Ime = textBoxIme.Text;
                    korisnik.Prezime = textBoxPrezime.Text;
                    korisnik.Email = string.Empty;
                    korisnik.Adresa = string.Empty;
                    korisnik.Pol = null;
                    korisnik.UserName = string.Empty;
                    korisnik.Password = string.Empty;
                    korisnik.Tip = Etip.Unregistred;
                    korisnik.Deleted = false;
                    int id = KorisnikDAO.UbaciKorisnika(korisnik);
                    Aplikacija.Instance.UcitajKorisnike();
                    korisnik.Id = id;
                    k.Korisnik = korisnik;

                }
                else
                {
                    return;
                }             
            }
            k.Kapija = "kapija";
            if (k.Sediste.tipSedista == EtipSedista.Biznis)
            {
                decimal cena = decimal.Parse(textBoxCenaLeta.Text);
                k.Cena = cena + (cena * 0.3m);
            }
            else
            {
                k.Cena = decimal.Parse(textBoxCenaLeta.Text);
            }
            
            k.Deleted = false;

            if (KartaDAO.NaparviKartu(k) == 0)
            {
                MessageBox.Show("Kupili ste kartu");
                Aplikacija.Instance.UcitajKarte();
                this.Close();
            }

        }
    }
}
