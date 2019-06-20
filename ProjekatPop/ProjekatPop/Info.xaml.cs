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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {

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
        public string VelikoSlovo(string rec)
        {
            return rec.Trim().Substring(0, 1).ToUpper() + rec.Trim().Substring(1).ToLower();
        }
       


        public Info()
        {
            InitializeComponent();
            comboBoxPol.Items.Add("Muski");
            comboBoxPol.Items.Add("Zenski");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Korisnik k = Aplikacija.Instance.LoggedUser;
           
            textBoxIme.Text = k.Ime;
            textBoxPrezime.Text = k.Prezime;
            textBoxEmail.Text = k.Email;
            textBoxAdresa.Text = k.Adresa;
            if (k.Pol.Equals(Epol.Muski))
            {
                comboBoxPol.SelectedIndex = 0;
            }
            else
            {
                comboBoxPol.SelectedIndex = 1;
            }
            textBoxUserName.Text = k.UserName;
            textBoxPassword.Text = k.Password;
            textBoxTip.Text = k.Tip.ToString();
        }

        private void buttonIzmeni_Click(object sender, RoutedEventArgs e)
        {


            if (Validacija())
            {

                Korisnik k = new Korisnik();
                k.Id = Aplikacija.Instance.LoggedUser.Id;
                k.Ime = VelikoSlovo(textBoxIme.Text);
                k.Prezime = VelikoSlovo(textBoxPrezime.Text);
                k.Email = textBoxEmail.Text;
                k.Adresa = textBoxAdresa.Text;
                
                if (comboBoxPol.SelectedItem.ToString().Equals("Zenski"))
                {
                    k.Pol = Epol.Zenski;
                }
                else
                {
                    k.Pol = Epol.Muski;
                }


                //k.Pol = (Epol)comboBoxPol.SelectedItem;
                k.UserName = textBoxUserName.Text;
                k.Password = textBoxPassword.Text;
                k.Tip = Aplikacija.Instance.LoggedUser.Tip;
                k.Deleted = false;


                
                if (KorisnikDAO.IzmeniKorisnika(k) == 0)
                {
                    MessageBox.Show("Uspesno ste se Izmenili");
                    Aplikacija.Instance.LoggedUser = k;
                    Aplikacija.Instance.UcitajKorisnike();
                    Aplikacija.Instance.UcitajKarte();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Greska");
                }

            }
            else
            {
                MessageBox.Show("Postoji UserName izaberi drugi!");
                textBoxUserName.Focus();
            }
            

        }

        private void buttonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
