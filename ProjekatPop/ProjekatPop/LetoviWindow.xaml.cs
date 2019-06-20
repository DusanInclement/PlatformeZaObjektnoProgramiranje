using ProjekatPop.DAO;
using ProjekatPop.DataBase;
using ProjekatPop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static ProjekatPop.EditLetWindow;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for LetoviWindow.xaml
    /// </summary>
    public partial class LetoviWindow : Window
    {
        ICollectionView view;
        public LetoviWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Letovi);
            view.Filter = CustomFilter;

            dataGridLetovi.ItemsSource = view;


            ObservableCollection<AvioKompanija> lista = Aplikacija.Instance.AvioKompanije;

            AvioKompanija a = new AvioKompanija();
            a.Naziv = "";
            lista.Add(a);
            comboBoxAerodrom.ItemsSource = lista;


            dataGridLetovi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private bool CustomFilter(object obj)
        {
            Let let = (Let)obj;
            if (!string.IsNullOrWhiteSpace(textBoxSifra.Text) || !string.IsNullOrWhiteSpace(textBoxCena.Text)
                || !string.IsNullOrWhiteSpace(textBoxPolazniAerodrom.Text)
                || !string.IsNullOrWhiteSpace(textBoxDestinacija.Text)

                || comboBoxAerodrom.SelectedIndex > -1)
            {
                if (comboBoxAerodrom.SelectedIndex == -1)
                {
                    string b = "";
                    return let.Sifra.Contains(textBoxSifra.Text)
                    && let.Cena.ToString().Contains(textBoxCena.Text)
                    && let.PolazniAerodrom.Grad.ToString().Contains(textBoxPolazniAerodrom.Text)
                    && let.DolazniAerodrom.Grad.ToString().Contains(textBoxDestinacija.Text)
                    && let.Avion.AvioKompanija.Naziv.Contains(b)
                    && let.Deleted == false;
                }
                else
                {
                    return let.Sifra.Contains(textBoxSifra.Text)
                    && let.Cena.ToString().Contains(textBoxCena.Text)
                    && let.PolazniAerodrom.Grad.ToString().Contains(textBoxPolazniAerodrom.Text)
                    && let.DolazniAerodrom.Grad.ToString().Contains(textBoxDestinacija.Text)
                    && let.Avion.AvioKompanija.Naziv.ToString().Contains(comboBoxAerodrom.SelectedItem.ToString())
                    && let.Deleted == false;
                }



            }
            return let.Deleted == false;
        }

        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridLetovi.Columns[0].Visibility = Visibility.Hidden;
            dataGridLetovi.Columns[9].Visibility = Visibility.Hidden;
            
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            EditLetWindow el = new EditLetWindow(new Let(), Stanje.Dodavanje);
            el.ShowDialog();
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLetovi.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati let");
                return;
            }

            Let let = (Let)dataGridLetovi.SelectedItem;
            EditLetWindow el = new EditLetWindow(let, Stanje.Izmena);
            el.ShowDialog();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLetovi.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati let");
                return;
            }

            Let let = (Let)dataGridLetovi.SelectedItem;

            if (MessageBox.Show("Da li ste sigruni? Brisanjem AvioKompanije brisete sve sto je vezano za nju",
                        "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                LetDAO.IzbrisiLet(let);
                Aplikacija.Instance.UcitajLetove();
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }
        }

        private void textBoxDestinacija_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxPolazniAerodrom_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxCena_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxSifra_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void comboBoxAerodrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Refresh();
        }
    }
}
