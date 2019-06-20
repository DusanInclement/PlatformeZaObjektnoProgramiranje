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
using System.Collections.ObjectModel;
using static ProjekatPop.KorisnikWindow;
using ProjekatPop.DAO;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class KorisniciWindow : Window
    {
        ICollectionView view;

        private int VratiIndex(Korisnik k)
        {
            int index = -1;
            for (int i = 0; i < Aplikacija.Instance.Korisnici.Count; i++)
            {
                if (k.Id == Aplikacija.Instance.Korisnici[i].Id)
                {
                    index = i;
                }
            }
            return index;

        }
        
        public KorisniciWindow()
        {
            InitializeComponent();
            //Aplikacija.Instance.UcitajKorisnike();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Korisnici);
            view.Filter = CustomFilter;
            
            dataGridKorisnici.ItemsSource = view;
            dataGridKorisnici.IsSynchronizedWithCurrentItem = true;

            dataGridKorisnici.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool CustomFilter(object obj)
        {
            Korisnik k = (Korisnik)obj;
            if (!textBoxIme.Text.Equals(string.Empty) 
                || !textBoxPrezime.Equals(string.Empty)
                || !textBoxUserName.Equals(string.Empty)
                || !textBoxTip.Equals(string.Empty))
            {
                return  k.Ime.Contains(textBoxIme.Text)
                        && k.Prezime.Contains(textBoxPrezime.Text)
                        && k.UserName.Contains(textBoxUserName.Text)
                        && k.Tip.ToString().Contains(textBoxTip.Text)
                        && k.Id != Aplikacija.Instance.LoggedUser.Id && k.Tip != Etip.Unregistred;
            }
            else
            {
                return k.Id != Aplikacija.Instance.LoggedUser.Id && k.Tip != Etip.Unregistred;
            }
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dataGridKorisnici.Columns[0].Visibility = Visibility.Hidden;
            dataGridKorisnici.Columns[3].Visibility = Visibility.Hidden;
            dataGridKorisnici.Columns[9].Visibility = Visibility.Hidden;
        }





        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKorisnici.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati korisnika");                
            }
            Korisnik korisnik = (Korisnik)dataGridKorisnici.SelectedItem;

            if (MessageBox.Show("Da li ste sigruni? Brisanjem Korisnika brisete sve sto je vezano za njega",
                        "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                KorisnikDAO.IzbrisiKorisnika(korisnik);
                Aplikacija.Instance.UcitajKorisnike();
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }

        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKorisnici.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektvoati Korisnika kojeg zelite da promenite!");
                return;
            }

            Korisnik korisnik = (Korisnik)dataGridKorisnici.SelectedItem;
            KorisnikWindow kw = new KorisnikWindow(korisnik, Stanje.Izmena);
            Korisnik stari = (Korisnik)korisnik.Clone();
            int index = VratiIndex(korisnik);

            if (kw.ShowDialog() == false)
            {
                Aplikacija.Instance.Korisnici[index] = stari;
            }       
           
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {            
            KorisnikWindow kori = new KorisnikWindow(new Korisnik(), Stanje.Dodavanje);            
            kori.ShowDialog();          
        }

        private void textBoxIme_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxPrezime_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxUserName_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxTip_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
