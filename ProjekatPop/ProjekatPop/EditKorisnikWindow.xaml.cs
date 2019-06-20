using ProjekatPop.DAO;
using ProjekatPop.DataBase;
using ProjekatPop.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public enum Stanje { Izmena,Dodavanje}
        private Stanje stanje;
        private Korisnik korisnik;
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxIme.Text))
            {
                MessageBox.Show("Niste popunili Ime");
                textBoxIme.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Niste popunili Prezime");
                textBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Niste popunili Prezime");
                textBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Niste popunili Email");
                textBoxEmail.Focus();
                return false;
            }
            if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains(".com"))
            {
                MessageBox.Show("Nije validan Email");
                textBoxEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAdresa.Text))
            {
                MessageBox.Show("Niste popunili Adresa");
                textBoxAdresa.Focus();
                return false;
            }
            if (comboBoxPol.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati Pol");
                comboBoxPol.Focus();
                return false;
            }
            if (comboBoxTip.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati Tip");
                comboBoxTip.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
            {
                MessageBox.Show("Niste popunili UserName");
                textBoxUserName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Niste popunili Password");
                textBoxPassword.Focus();
                return false;
            }
            return true;

        }
        private Korisnik VelikoSlovo(Korisnik k)
        {
            k.Ime = k.Ime.Trim().Substring(0, 1).ToUpper() + k.Ime.Trim().Substring(1).ToLower();
            k.Prezime = k.Prezime.Trim().Substring(0, 1).ToUpper() + k.Prezime.Trim().Substring(1).ToLower();
            return k;
        }
        private bool PostojiUserName(string userName)
        {
            if (KorisnikDAO.vratiKorisnikaPrekoUserName(userName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public KorisnikWindow(Korisnik korisnik , Stanje stanje)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.stanje = stanje;
            this.DataContext = korisnik;

            comboBoxPol.Items.Add(Epol.Muski);
            comboBoxPol.Items.Add(Epol.Zenski);
            comboBoxTip.Items.Add(Etip.Admin);
            comboBoxTip.Items.Add(Etip.User);
            
            if (stanje == Stanje.Izmena)
            {
                textBoxUserName.IsReadOnly = true;
            }
            if (stanje == Stanje.Izmena && korisnik.Id == Aplikacija.Instance.LoggedUser.Id)
            {
                comboBoxTip.Items.Clear();
                comboBoxTip.Items.Add(Etip.Admin);
            }


        }

        private void buttonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                
                if (stanje == Stanje.Dodavanje)
                {
                    if (!PostojiUserName(textBoxUserName.Text))
                    {
                        KorisnikDAO.UbaciKorisnika(VelikoSlovo(korisnik));
                        Aplikacija.Instance.UcitajKorisnike();
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Postoji Korisnik sa tim userName-om");
                        textBoxUserName.Clear();
                        textBoxUserName.Focus();
                        return;
                    }
                   
                }
                else
                {
                    
                        KorisnikDAO.IzmeniKorisnika(VelikoSlovo(korisnik));
                        Aplikacija.Instance.UcitajKorisnike();
                        this.DialogResult = true;

                }
            }           
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
