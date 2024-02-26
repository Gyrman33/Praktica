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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Window
    {
        int user = 0;
        public Korzina(int id)
        {
            InitializeComponent();
            var con = new appDbContext();
            user = id;
            MainWindow mainWindow = new MainWindow();

            Korzs.ItemsSource = con.Korzs.Where(x => x.User == user).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Katalog katalog = new Katalog(user);
            katalog.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var con = new appDbContext();
            var Deletethis = con.Korzs.FirstOrDefault(x => x.TovaraIdi == con.Korzs.FirstOrDefault(x => x.User == user).TovaraIdi);
            if (Deletethis != null)
            {
                con.Korzs.Remove((Korz)Deletethis);
                con.SaveChanges();
                Korzs.ItemsSource = con.Korzs.Where(x => x.User == user).ToList();
            }
            else
            {
                MessageBox.Show("Элемент не найден");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var con = new appDbContext();
            var sum = con.Korzs.Where(x => x.User == user).Sum(x => x.Stoimost * x.Kolvo);
            MessageBox.Show("К оплате " + sum + "$");
            con.Tovars.FirstOrDefault(x => x.Id == con.Korzs.FirstOrDefault(x => x.User == user).TovaraIdi).Kolvo -= con.Korzs.FirstOrDefault(x => x.User == user).Kolvo;
            con.SaveChanges();
        }
    }
}
