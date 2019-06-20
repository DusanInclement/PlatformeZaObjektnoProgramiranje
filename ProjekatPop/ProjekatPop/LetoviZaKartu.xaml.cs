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
using ProjekatPop.Model;
using ProjekatPop.DAO;
using static ProjekatPop.KupiKartu;
using System.ComponentModel;
using ProjekatPop.DataBase;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for LetoviZaKartu.xaml
    /// </summary>
    public partial class LetoviZaKartu : Window
    {
        ICollectionView view;
        ObservableCollection<Let> povratniLetovi = new ObservableCollection<Let>();
        ObservableCollection<Let> letovi = new ObservableCollection<Let>();
        public LetoviZaKartu()
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
            //Aplikacija.Instance.Avioni.Select(a => a.Naziv);
            

            dataGridPovratniLet.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dataGridLetovi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        //private bool CustomFilter(object obj)
        //{
        //    Let let = (Let)obj;

        //    if (!string.IsNullOrWhiteSpace(textBoxSifra.Text) || !string.IsNullOrWhiteSpace(textBoxPilot.Text)
        //            || !string.IsNullOrWhiteSpace(textBoxAvion.Text))
        //    {                    
        //            return let.Sifra.Contains(textBoxSifra.Text)
        //            &&  let.Pilot.Contains(textBoxPilot.Text)
        //            && let.Avion.Naziv.Contains(textBoxAvion.Text)
        //            && let.Deleted == false;


        //    }
        //    return let.Deleted == false;


        //}

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

        private void buttonKupiKartu_Click(object sender, RoutedEventArgs e)
        {

            if (dataGridLetovi.SelectedIndex < 0)
            {
                MessageBox.Show("Morate izabrati let");
                return;
            }         
                Let let = (Let)dataGridLetovi.SelectedItem;
                KupiKartu kp = new KupiKartu(let, Stanje.Nova);
                kp.ShowDialog();
            if (dataGridPovratniLet.SelectedIndex > -1)
            {
                Let letP = (Let)dataGridPovratniLet.SelectedItem;
                KupiKartu kpK = new KupiKartu(letP, Stanje.Povratna);
                kpK.ShowDialog();
            }


           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dataGridLetovi.Columns[0].Visibility = Visibility.Hidden;
            //this.dataGridLetovi.Columns[1].Visibility = Visibility.Hidden;
            this.dataGridLetovi.Columns[2].Visibility = Visibility.Hidden;
            this.dataGridLetovi.Columns[9].Visibility = Visibility.Hidden;
            this.dataGridLetovi.Columns[3].Header = "Polazak";
            this.dataGridLetovi.Columns[4].Header = "Destinacija";
            this.dataGridLetovi.Columns[5].Header = "Vreme Polaska";
            this.dataGridLetovi.Columns[6].Header = "Vreme Dolaska";

            //this.dataGridPovratniLet.Columns[0].Visibility = Visibility.Hidden;
            ////this.dataGridLetovi.Columns[1].Visibility = Visibility.Hidden;
            //this.dataGridPovratniLet.Columns[2].Visibility = Visibility.Hidden;
            //this.dataGridPovratniLet.Columns[9].Visibility = Visibility.Hidden;
            //this.dataGridPovratniLet.Columns[3].Header = "Polazak";
            //this.dataGridPovratniLet.Columns[4].Header = "Destinacija";
            //this.dataGridPovratniLet.Columns[5].Header = "Vreme Polaska";
            //this.dataGridPovratniLet.Columns[6].Header = "Vreme Dolaska";





        }

        private void dataGridLetovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridLetovi.SelectedIndex > -1)
            {
                Let let = (Let)dataGridLetovi.SelectedItem;

                povratniLetovi = LetDAO.VratiPovratneLetove(let);
                dataGridPovratniLet.ItemsSource = povratniLetovi;
            }
            else
            {
                povratniLetovi.Clear();
                dataGridPovratniLet.ItemsSource = povratniLetovi;
            }

            this.dataGridPovratniLet.Columns[0].Visibility = Visibility.Hidden;
            //this.dataGridLetovi.Columns[1].Visibility = Visibility.Hidden;
            this.dataGridPovratniLet.Columns[2].Visibility = Visibility.Hidden;
            this.dataGridPovratniLet.Columns[9].Visibility = Visibility.Hidden;
            this.dataGridPovratniLet.Columns[3].Header = "Polazak";
            this.dataGridPovratniLet.Columns[4].Header = "Destinacija";
            this.dataGridPovratniLet.Columns[5].Header = "Vreme Polaska";
            this.dataGridPovratniLet.Columns[6].Header = "Vreme Dolaska";

        }

        private void textBoxSifra_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridLetovi.SelectedIndex = -1;
           
            view.Refresh();
            
        }

        private void textBoxCena_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridLetovi.SelectedIndex = -1;

            view.Refresh();
        }

        private void textBoxPolazniAerodrom_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridLetovi.SelectedIndex = -1;

            view.Refresh();

        }

        private void textBoxDestinacija_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridLetovi.SelectedIndex = -1;

            view.Refresh();
        }

        private void comboBoxAerodrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridLetovi.SelectedIndex = -1;

            view.Refresh();

        }



        //private void textBoxAvion_KeyUp(object sender, KeyEventArgs e)
        //{
        //    dataGridLetovi.SelectedIndex = -1;
        //    view.Refresh();
        //}


    }
}
