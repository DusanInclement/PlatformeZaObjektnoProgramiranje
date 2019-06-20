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
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Profil()
        {
            InitializeComponent();
        }

        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            Info i = new Info();
            i.ShowDialog();
        }

        private void buttonKupiKartu_Click(object sender, RoutedEventArgs e)
        {
            LetoviZaKartu lzk = new LetoviZaKartu();
            lzk.ShowDialog();
        }

        private void buttonMojiKarte_Click(object sender, RoutedEventArgs e)
        {
            MojeKarte mk = new MojeKarte();
            mk.ShowDialog();
        }
    }
}
