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
    /// Interaction logic for EditAerodromWindow.xaml
    /// </summary>
    public partial class EditAerodromWindow : Window
    {
        public enum Stanje { Dodavanje,Izmena}
        private Stanje stanje;
        private Aerodrom aerodromG;

        private bool PostojiSifra(string sifra)
        {
            foreach (Aerodrom a in Aplikacija.Instance.Aerodromi)
            {
                if (a.Sifra == sifra)
                {
                    MessageBox.Show("Postoji Sifra");
                    textBoxSifra.Clear();
                    textBoxSifra.Focus();
                    return false;
                }                
            }
            return true;
        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxSifra.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Sifra");
                textBoxSifra.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Naziv");
                textBoxNaziv.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGrad.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Grad");
                textBoxGrad.Focus();
                return false;
            }
            return true;
        }
        private string VratiVelika(string sifra)
        {
            return sifra.Substring(0).ToUpper();
        }

        public EditAerodromWindow(Aerodrom aerodrom,Stanje stanje)
        {
            InitializeComponent();
            this.stanje = stanje;
            this.aerodromG = aerodrom;

            this.DataContext = aerodromG;

            if (stanje == Stanje.Izmena)
            {
                textBoxSifra.IsReadOnly = true;
            }
        }

        private void buttonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                if (stanje == Stanje.Dodavanje)
                {
                    aerodromG.Sifra = VratiVelika(aerodromG.Sifra);
                    if (PostojiSifra(aerodromG.Sifra))
                    {                        
                        if (AerodromDAO.napraviAerodrom(aerodromG) == 0)
                        {
                            MessageBox.Show("Uspesno ste napravili aerodrom");
                            Aplikacija.Instance.UcitajAerodrome();
                            this.DialogResult = true;
                        }
                    }
                    else
                    {
                        return;
                    }                    
                }
                else
                {
                    AerodromDAO.izmeniAerodrom(aerodromG);
                    DialogResult = true;
                }
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
        }
    }
}
