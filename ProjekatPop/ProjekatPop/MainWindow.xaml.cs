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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ProjekatPop.Model;
using ProjekatPop.DAO;

namespace ProjekatPop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
            {
                MessageBox.Show("Morate uneti UserName");
                textBoxUserName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password))
            {
                MessageBox.Show("Morate uneti Passowrd");
                passwordBoxPassword.Focus();
                return false;
            }

            return true;
        }
       

        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                string UserName = textBoxUserName.Text;
                string Password = passwordBoxPassword.Password;

                Korisnik k = new Korisnik();
                k = KorisnikDAO.vratiKorisnikaPrekoUserName(UserName);

                if (k != null)
                {
                    if (k.Password.Equals(Password))
                    {

                        Aplikacija.Instance.LoggedUser = k;
                        if (Aplikacija.Instance.LoggedUser.Tip == Etip.Admin)
                        {
                            textBoxUserName.Clear();
                            passwordBoxPassword.Clear();                           
                            AdminPanel ap = new AdminPanel();
                            ap.ShowDialog();

                        }
                        else 
                        {
                            textBoxUserName.Clear();
                            passwordBoxPassword.Clear();
                            Profil p = new Profil();
                            p.ShowDialog();
                        }
                        



                    }
                    else
                    {
                        MessageBox.Show("Pogresna sifra");
                        passwordBoxPassword.Clear();
                        passwordBoxPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Pogresan username");
                    passwordBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
            }
        }    

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.ShowDialog();

        }

        private void buttonUnRegister_Click(object sender, RoutedEventArgs e)
        {
            
                LetoviZaKartu z = new LetoviZaKartu();
                z.ShowDialog();
            
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
    }
}
