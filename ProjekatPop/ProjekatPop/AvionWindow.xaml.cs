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
using static ProjekatPop.EditAvionWindow;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for AvionWindow.xaml
    /// </summary>
    public partial class AvionWindow : Window
    {
        ICollectionView view;

        private int VratiIndex(Avion a)
        {
            int index = -1;
            for (int i = 0; i < Aplikacija.Instance.Avioni.Count; i++)
            {
                if (a.Id == Aplikacija.Instance.Avioni[i].Id)
                {
                    index = i;
                }
            }
            return index;

        }
        public AvionWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Avioni);
            view.Filter = CustomFilter;

            dataGridAvioni.ItemsSource = view;

            dataGridAvioni.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



        }

        private bool CustomFilter(object obj)
        {
            Avion a = (Avion)obj;

            if (!string.IsNullOrWhiteSpace(textBoxNaziv.Text) || !string.IsNullOrWhiteSpace(textBoxAvioKompanija.Text))
            {
                return a.Naziv.Contains(textBoxNaziv.Text) && a.AvioKompanija.Naziv.Contains(textBoxAvioKompanija.Text);
            }

            return a.Deleted == false;
        }

        private void textBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAvioni.Columns[0].Visibility = Visibility.Hidden;
            dataGridAvioni.Columns[2].Visibility = Visibility.Hidden;
            dataGridAvioni.Columns[3].Visibility = Visibility.Hidden;
            dataGridAvioni.Columns[5].Visibility = Visibility.Hidden;
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            EditAvionWindow eaw = new EditAvionWindow(new Avion(),Stanje.Dodavanje);
            eaw.ShowDialog();
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAvioni.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati avion");
                return;
            }

            Avion a = (Avion)dataGridAvioni.SelectedItem;
            Avion stari = (Avion)a.Clone();
            int index = VratiIndex(a);
            EditAvionWindow ea = new EditAvionWindow(a, Stanje.Izmena);

            if (ea.ShowDialog() == false)
            {
                Aplikacija.Instance.Avioni[index] = stari;
            }
            
           
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAvioni.SelectedIndex == -1)
            {
                MessageBox.Show("Morate selektovati avion");
                return;
            }

            Avion avion = (Avion)dataGridAvioni.SelectedItem;
            if (MessageBox.Show("Da li ste sigruni? Brisanjem Aviona brisete sve sto je vezano za njega",
                        "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                AvionDAO.IzbirisAvio(avion);
                Aplikacija.Instance.UcitajAvione();
                Aplikacija.Instance.UcitajLetove();
                Aplikacija.Instance.UcitajKarte();
                view.Refresh();
            }
        }

        private void textBoxNaziv_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void textBoxAvioKompanija_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
