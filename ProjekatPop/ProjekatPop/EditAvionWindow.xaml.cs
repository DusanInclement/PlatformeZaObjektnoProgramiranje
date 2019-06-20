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
    /// Interaction logic for EditAvionWindow.xaml
    /// </summary>
    public partial class EditAvionWindow : Window
    {
        public enum Stanje { Dodavanje,Izmena};
        private Stanje stanje;
        private Avion avionG;

        private List<int> VratiBrojRedovaEiBKlase(Avion avion)
        {
            List<int> lista = AvionDAO.vratiBrSedita(avion);

            return lista;
        }
        private bool Validacija()
        {
            int broj;
            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Naziv");
                textBoxNaziv.Focus();
                return false;
            }
            if (comboBoxAvioKompanija.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati AvioKompaniju");
                comboBoxAvioKompanija.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxBrREkonKl.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Broj redova Ekonomske klase");
                textBoxBrREkonKl.Focus();
                return false;
            }
            if (int.TryParse(textBoxBrREkonKl.Text,out broj) == false)
            {
                MessageBox.Show("Morate uneti broj za Broj Redova i Broj Sedista");
                textBoxBrREkonKl.Clear();
                textBoxBrREkonKl.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxBrSuREkonKl.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Broj sedista u redu Ekonomske klase");
                textBoxBrSuREkonKl.Focus();
                return false;
            }
            if (int.TryParse(textBoxBrSuREkonKl.Text, out broj) == false)
            {
                MessageBox.Show("Morate uneti broj za Broj Redova i Broj Sedista");
                textBoxBrSuREkonKl.Clear();
                textBoxBrSuREkonKl.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxBrRBizKl.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Broj redova Biznis klase");
                textBoxBrRBizKl.Focus();
                return false;
            }
            if (int.TryParse(textBoxBrRBizKl.Text, out broj) == false)
            {
                MessageBox.Show("Morate uneti broj za Broj Redova i Broj Sedista");
                textBoxBrRBizKl.Clear();
                textBoxBrRBizKl.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxBrSuRBizKl.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Broj sedista u redu Biznis klase");
                textBoxBrSuRBizKl.Focus();
                return false;
            }
            if (int.TryParse(textBoxBrSuRBizKl.Text, out broj) == false)
            {
                MessageBox.Show("Morate uneti broj za Broj Redova i Broj Sedista");
                textBoxBrSuRBizKl.Clear();
                textBoxBrSuRBizKl.Focus();
                return false;
            }

            return true;
        }



        public EditAvionWindow(Avion avion, Stanje stanje)
        {
            InitializeComponent();
            this.avionG = avion;
            this.stanje = stanje;
          

            if (stanje == Stanje.Izmena)
            {
                //List<int> lista = VratiBrojRedovaEiBKlase(avion);
                //textBoxBrREkonKl.Text = lista[0].ToString();
                //textBoxBrREkonKl.IsReadOnly = true;
                //textBoxBrSuREkonKl.Text = lista[1].ToString();
                //textBoxBrSuREkonKl.IsReadOnly = true;
                //textBoxBrRBizKl.Text = lista[2].ToString();
                //textBoxBrRBizKl.IsReadOnly = true;
                //textBoxBrSuRBizKl.Text = lista[3].ToString();
                //textBoxBrSuRBizKl.IsReadOnly = true;
                


                labelBrREKON.Content = "Broj Sedista Ekonomske klase: ";
                textBoxBrREkonKl.Text = avion.SedistaEkonomskeKlase.Count.ToString();
                textBoxBrREkonKl.IsReadOnly = true;
                labelBeSedistaEkon.Content = "Broj Sedista Biznis klase: ";
                textBoxBrSuREkonKl.Text = avion.SedistaBiznisKlase.Count.ToString();
                textBoxBrSuREkonKl.IsReadOnly = true;

                textBoxBrSuRBizKl.Visibility = Visibility.Hidden;
                textBoxBrRBizKl.Visibility = Visibility.Hidden;
                labelBrRBIZ.Visibility = Visibility.Hidden;
                labelBRojSedistBIz.Visibility = Visibility.Hidden;

            }

            if (stanje == Stanje.Izmena)
            {
                comboBoxAvioKompanija.Items.Clear();
                //comboBoxPolazniAerodrom.Items.Clear();
                //comboBoxDolazniAerodrom.Items.Clear();

                comboBoxAvioKompanija.Items.Add(avionG.AvioKompanija);
                //comboBoxPolazniAerodrom.Items.Add(letG.PolazniAerodrom);
                //comboBoxDolazniAerodrom.Items.Add(letG.DolazniAerodrom);
            }
            else
            {
                comboBoxAvioKompanija.ItemsSource = Aplikacija.Instance.AvioKompanije.Select(a => a);

            }


            DataContext = avionG;
            
            
        }

        private void buttonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            
                if (stanje == Stanje.Dodavanje)
                {
                    if (Validacija())
                    {
                    //avionG.AvioKompanija = AvioKompanijaDAO.vratiAvioKompanijuPrekoImena(comboBoxAvioKompanija.SelectedItem.ToString());



                    List<int> lista = new List<int>();
                    lista.Add(int.Parse(textBoxBrREkonKl.Text));
                    lista.Add(int.Parse(textBoxBrSuREkonKl.Text));
                    lista.Add(int.Parse(textBoxBrRBizKl.Text));
                    lista.Add(int.Parse(textBoxBrSuRBizKl.Text));

                    if (AvionDAO.NapraviAvion(avionG, lista) == 0)
                    {
                        MessageBox.Show("Uspesno se napravili avion");
                        Aplikacija.Instance.UcitajAvione();
                        this.DataContext = true;
                        this.Close();
                    }
                }
            }
                else
                {
                //MessageBox.Show(avionG.AvioKompanija.Id + " " + avionG.AvioKompanija.Naziv);
                //avionG.AvioKompanija = AvioKompanijaDAO.vratiAvioKompanijuPrekoImena(comboBoxAvioKompanija.SelectedItem.ToString());

                AvionDAO.IzmeniAvion(avionG);
                Aplikacija.Instance.UcitajAvione();
                this.DialogResult = true;

            }

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
