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
    /// Interaction logic for KarteWindow.xaml
    /// </summary>
    public partial class KarteWindow : Window
    {
        ICollectionView view;
        public KarteWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Karte);
            view.Filter = CustomFilter;

            dataGridKarte.ItemsSource = view;

            dataGridKarte.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool CustomFilter(object obj)
        {
            Karta k = (Karta)obj;
            if (!string.IsNullOrWhiteSpace(textBoxBrLeta.Text) ||
                !string.IsNullOrWhiteSpace(textBoxIme.Text) ||
                !string.IsNullOrWhiteSpace(textBoxPolazniG.Text) ||
                !string.IsNullOrWhiteSpace(textBoxDolazniG.Text) ||
                !string.IsNullOrWhiteSpace(textBoxTipS.Text) )
            {
                return k.Let.Sifra.Contains(textBoxBrLeta.Text) &&
                       k.Korisnik.Ime.Contains(textBoxIme.Text) &&
                       k.Let.PolazniAerodrom.Grad.Contains(textBoxPolazniG.Text) &&
                       k.Let.DolazniAerodrom.Grad.Contains(textBoxDolazniG.Text) &&
                       k.Sediste.tipSedista.ToString().Contains(textBoxTipS.Text);
            }
            return k.Deleted == false;
        }

        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridKarte.Columns[0].Visibility = Visibility.Hidden;
            dataGridKarte.Columns[6].Visibility = Visibility.Hidden;
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKarte.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati kartu za brisanje");
                return;
            }

            Karta karta = (Karta)dataGridKarte.SelectedItem;
            if (MessageBox.Show("Da li ste sigruni da zelite da obrisete kartu",
                       "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                KartaDAO.IzbrisiKartu(karta);                
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }
        }

        private void textBoxBrLeta_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxIme_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxPolazniG_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxDolazniG_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxTipS_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKarte.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati kartu");
                return;
            }
            Karta k = (Karta)dataGridKarte.SelectedItem;
            EditSedisteWindow ew = new EditSedisteWindow(k);
            ew.ShowDialog();
        }
    }
}
