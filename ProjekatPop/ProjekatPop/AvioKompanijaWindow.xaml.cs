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
using static ProjekatPop.EditAvioKompanija;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for AvioKompanijaWindow.xaml
    /// </summary>
    public partial class AvioKompanijaWindow : Window
    {
        ICollectionView view;

        private int VratiIndex(AvioKompanija av)
        {
            int index = -1;
            for (int i = 0; i < Aplikacija.Instance.AvioKompanije.Count; i++)
            {
                if (av.Id == Aplikacija.Instance.AvioKompanije[i].Id)
                {
                    index = i;
                }
            }
            return index;

        }
        public AvioKompanijaWindow()
        {
            InitializeComponent();
            //Aplikacija.Instance.UcitajAvioKompanije();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.AvioKompanije);
            view.Filter = CustomFilter;

            dataGridAvioKompanije.ItemsSource = view;
            dataGridAvioKompanije.IsSynchronizedWithCurrentItem = true;
            dataGridAvioKompanije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


        }

        private bool CustomFilter(object obj)
        {
            AvioKompanija av = (AvioKompanija)obj;
            if (textBoxPretraga.Text.Equals(string.Empty))
            {
                return av.Deleted == false;
            }
            else
            {
                return av.Naziv.Contains(textBoxPretraga.Text) && av.Deleted == false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAvioKompanije.Columns[2].Visibility = Visibility.Hidden;
        }

        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            EditAvioKompanija aw = new EditAvioKompanija(new AvioKompanija(), Stanje.Dodavanje);
            aw.ShowDialog();
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAvioKompanije.SelectedIndex == -1)
            {
                MessageBox.Show("Morate oznaciti Avio Kompaniju koju zelite da promenite!");
                return;
            }
            
            AvioKompanija avv = (AvioKompanija)dataGridAvioKompanije.SelectedItem;
            AvioKompanija stari = (AvioKompanija)avv.Clone();
            int index = VratiIndex(avv);
            EditAvioKompanija aw = new EditAvioKompanija(avv, Stanje.Izmena);
            
            if (aw.ShowDialog() == false)
            {
                Aplikacija.Instance.AvioKompanije[index] = stari;
            }

            
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAvioKompanije.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati AvioKompaniju");
                return;
            }
            AvioKompanija avioKompanija = (AvioKompanija)dataGridAvioKompanije.SelectedItem;

            if (MessageBox.Show("Da li ste sigruni? Brisanjem AvioKompanije brisete sve sto je vezano za nju",
                        "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                AvioKompanijaDAO.IzbirisAvioKompaniju(avioKompanija);
                Aplikacija.Instance.UcitajAvioKompanije();
                Aplikacija.Instance.UcitajAvione();
                Aplikacija.Instance.UcitajLetove();
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }

        }

    }
}
