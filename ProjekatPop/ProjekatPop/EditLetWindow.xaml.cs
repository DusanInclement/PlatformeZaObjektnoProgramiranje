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
    /// Interaction logic for EditLetWindow.xaml
    /// </summary>
    public partial class EditLetWindow : Window
    {

        public enum Stanje { Dodavanje, Izmena}
        private Stanje stanje;
        private Let letG;
        private bool PostojiSifra(string sifra)
        {
            if (LetDAO.vratiLetPrekoSifre(sifra) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxSifra.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Sifra");
                textBoxSifra.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPilot.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Pilot");
                textBoxPilot.Focus();
                return false;
            }
            if (comboBoxPolazniAerodrom.SelectedIndex == -1)
            {
                MessageBox.Show("Morate obeleziti polazni Aerodrom");
                comboBoxPolazniAerodrom.Focus();
                return false;
            }
            if (comboBoxDolazniAerodrom.SelectedIndex == -1)
            {
                MessageBox.Show("Morate obeleziti dolazni Aerodrom");
                comboBoxDolazniAerodrom.Focus();
                return false;
            }
            if (comboBoxAvion.SelectedIndex == -1)
            {
                MessageBox.Show("Morate obeleziti Avion");
                comboBoxAvion.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxCena.Text.Trim()))
            {
                MessageBox.Show("Morate popuniti polje Cena");
                textBoxCena.Focus();
                return false;
            }
            decimal broj;
            if (!decimal.TryParse(textBoxCena.Text.Trim(),out broj))
            {
                MessageBox.Show("Cena mora da bude decimalan broj!");
                textBoxCena.Clear();
                textBoxCena.Focus();
                return false;
            }
            return true;
        }
        private bool Aerodromi()
        {
            Aerodrom a = (Aerodrom) comboBoxPolazniAerodrom.SelectedItem;
            Aerodrom b = (Aerodrom)comboBoxDolazniAerodrom.SelectedItem;
            if (a == b)
            {
                MessageBox.Show("Morate izabrati razlicite aerodrome!");
                return false;
            }
            return true;
        }
        


        public EditLetWindow(Let let, Stanje stanje)
        {
            InitializeComponent();
            this.stanje = stanje;
            this.letG = let;

            this.DataContext = letG;


           

            if (stanje == Stanje.Izmena)
            {
                comboBoxAvion.Items.Clear();
                comboBoxPolazniAerodrom.Items.Clear();
                comboBoxDolazniAerodrom.Items.Clear();

                comboBoxAvion.Items.Add(letG.Avion);
                comboBoxPolazniAerodrom.Items.Add(letG.PolazniAerodrom);
                comboBoxDolazniAerodrom.Items.Add(letG.DolazniAerodrom);
            }
            else
            {
                comboBoxAvion.ItemsSource = Aplikacija.Instance.Avioni.Select(a => a);
                comboBoxPolazniAerodrom.ItemsSource = Aplikacija.Instance.Aerodromi.Select(a => a);
                comboBoxDolazniAerodrom.ItemsSource = Aplikacija.Instance.Aerodromi.Select(a => a);

            }
            

            
        }

        private void buttonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                if (Aerodromi())
                {
                    if (stanje == Stanje.Dodavanje)
                    {
                        //MessageBox.Show(letG.vremePolaska + " " + letG.vremeDolaska);
                        
                        if (!PostojiSifra(textBoxSifra.Text))
                        {
                            if (LetDAO.NapraviLet(letG) == 0)
                            {
                                letG.vremePolaska = (DateTime)datePickerDatumPolaska.Value;
                                letG.vremeDolaska = (DateTime)datePickerDatumDolaska.Value;

                                MessageBox.Show("Uspesno ste napravili Let");
                                Aplikacija.Instance.UcitajLetove();
                                this.DialogResult = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Postoji Let sa tom Sifrom");
                            textBoxSifra.Clear();
                            textBoxSifra.Focus();
                            return;
                        }
                    }
                    else
                    {
                        letG.vremePolaska = (DateTime)datePickerDatumPolaska.Value;
                        letG.vremeDolaska = (DateTime)datePickerDatumDolaska.Value;
                        if (LetDAO.IzmeniLet(letG) == 0)
                        {
                            MessageBox.Show("Uspesno ste izmenili let");
                            DialogResult = true;
                        }
                    }
                }
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (stanje == Stanje.Dodavanje)
            {
                datePickerDatumDolaska.Value = DateTime.Now;
                datePickerDatumPolaska.Value = DateTime.Now;
            }
            if (stanje == Stanje.Izmena)
            {
                textBoxSifra.IsReadOnly = true;
                


            }
        }
    }
}
