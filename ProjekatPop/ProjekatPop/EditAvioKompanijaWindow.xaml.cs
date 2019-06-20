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
using System.Collections.ObjectModel;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for EditAvioKompanija.xaml
    /// </summary>
    public partial class EditAvioKompanija : Window
    {
        private AvioKompanija avioKompanija = new AvioKompanija();
        public enum Stanje { Dodavanje, Izmena}
        private Stanje stanje;

        private bool Vlidacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Naziv");
                textBoxNaziv.Focus();
                return false;
            }
            return true;
        }
        public EditAvioKompanija(AvioKompanija avioKompanijaP, Stanje stanje)
        {
            InitializeComponent();
            this.avioKompanija = avioKompanijaP;
            this.stanje = stanje;

            this.DataContext = avioKompanija;
        }

        private void buttonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Vlidacija())
            {
                this.DialogResult = true;
                if (stanje == Stanje.Dodavanje)
                {
                    AvioKompanijaDAO.DodajAvioKompaniju(avioKompanija);
                    Aplikacija.Instance.UcitajAvioKompanije();
                    
                }
                else
                {
                    AvioKompanijaDAO.IzmeniAvioKompaniju(avioKompanija);
                    
                    //Aplikacija.Instance.UcitajAvioKompanije();
                }
            }           
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
