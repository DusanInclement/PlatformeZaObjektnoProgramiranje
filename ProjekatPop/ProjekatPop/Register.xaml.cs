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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
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
        private string VelikoSlovo(string rec)
        {
            return rec.Trim().Substring(0, 1).ToUpper() + rec.Trim().Substring(1).ToLower();
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

        public Register()
        {
            InitializeComponent();
            comboBoxPol.Items.Add(Epol.Muski);
            comboBoxPol.Items.Add(Epol.Zenski);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {                  
                if (!PostojiUserName(textBoxUserName.Text))
                {
                    Korisnik k = new Korisnik();
                    k.Ime = VelikoSlovo(textBoxIme.Text);
                    k.Prezime = VelikoSlovo(textBoxPrezime.Text);
                    k.Email = textBoxEmail.Text;
                    k.Adresa = textBoxAdresa.Text;
                    k.Pol = (Epol)comboBoxPol.SelectedItem;
                    k.UserName = textBoxUserName.Text;
                    k.Password = textBoxPassword.Text;
                    k.Tip = Etip.User;
                    k.Deleted = false;

                    if (KorisnikDAO.UbaciKorisnika(k) > 0)
                    {
                        MessageBox.Show("Uspesno ste se Registrovali");
                        Aplikacija.Instance.UcitajKorisnike();
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
        }
    }
}
