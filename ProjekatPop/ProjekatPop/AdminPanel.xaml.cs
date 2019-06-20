using ProjekatPop.DataBase;
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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void buttonProfil_Click(object sender, RoutedEventArgs e)
        {
            Profil p = new Profil();
            p.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Aplikacija.Instance.LoggedUser = null;
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisniciWindow kw = new KorisniciWindow();
            kw.ShowDialog();
        }

        private void buttonAvioni_Click(object sender, RoutedEventArgs e)
        {
            AvionWindow aw = new AvionWindow();
            aw.ShowDialog();
        }

        private void buttonAvionKompanija_Click(object sender, RoutedEventArgs e)
        {
            AvioKompanijaWindow avw = new AvioKompanijaWindow();
            avw.ShowDialog();
        }

        private void buttonAerodromi_Click(object sender, RoutedEventArgs e)
        {
            AerodromiWindow aw = new AerodromiWindow();
            aw.ShowDialog();
        }

        private void buttonLetovi_Click(object sender, RoutedEventArgs e)
        {
            LetoviWindow lw = new LetoviWindow();
            lw.ShowDialog();
        }

        private void buttonKarte_Click(object sender, RoutedEventArgs e)
        {
            KarteWindow kw = new KarteWindow();
            kw.ShowDialog();
        }
    }
}
