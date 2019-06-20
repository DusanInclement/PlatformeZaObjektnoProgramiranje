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
using static ProjekatPop.EditAerodromWindow;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for AerodromiWindow.xaml
    /// </summary>
    public partial class AerodromiWindow : Window
    {
        ICollectionView view;
        private int VratiIndex(Aerodrom av)
        {
            int index = -1;
            for (int i = 0; i < Aplikacija.Instance.Aerodromi.Count; i++)
            {
                if (av.Id == Aplikacija.Instance.Aerodromi[i].Id)
                {
                    index = i;
                }
            }
            return index;

        }
        public AerodromiWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Aerodromi);
            view.Filter = CustomFilter;

            dataGridAerodromi.ItemsSource = view;

            dataGridAerodromi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool CustomFilter(object obj)
        {
            Aerodrom ar = (Aerodrom)obj;

            if (textBoxPretraga.Text.Equals(string.Empty))
            {
                return ar.Deleted == false;
            }
            else
            {
                return ar.Naziv.Contains(textBoxPretraga.Text) && ar.Deleted == false;
            }
        }

        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAerodromi.Columns[0].Visibility = Visibility.Hidden;
            dataGridAerodromi.Columns[4].Visibility = Visibility.Hidden;
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAerodromi.SelectedIndex == -1)
            {
                MessageBox.Show("Morate odabarti Aerodrom koji zelite da promenite");
                dataGridAerodromi.Focus();
                return;
            }
            Aerodrom aerodrom = (Aerodrom)dataGridAerodromi.SelectedItem;
            Aerodrom stari = (Aerodrom)aerodrom.Clone();
            int index = VratiIndex(aerodrom);
            EditAerodromWindow ea = new EditAerodromWindow(aerodrom, Stanje.Izmena);

            if (ea.ShowDialog() == false)
            {
                Aplikacija.Instance.Aerodromi[index] = stari;
            }



            
            
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            EditAerodromWindow ea = new EditAerodromWindow(new Aerodrom(), Stanje.Dodavanje);
            ea.ShowDialog();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAerodromi.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati aerodrom");
                return;
            }
            Aerodrom aerodrom = (Aerodrom)dataGridAerodromi.SelectedItem;

            if (MessageBox.Show("Da li ste sigruni? Brisanjem Aerodroma brisete sve sto je vezano za njega",
                       "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                AerodromDAO.izbrisiAerdrom(aerodrom);
                Aplikacija.Instance.UcitajAerodrome();
                Aplikacija.Instance.UcitajLetove();
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }
        }
    }
}
