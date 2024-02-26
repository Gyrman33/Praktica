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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aut_Click(object sender, RoutedEventArgs e)
        {
            var log = login.Text;
            var pass = password.Text;
            var context = new appDbContext();

            var user = context.Users.SingleOrDefault(x =>x.login==log);
            var user2 = context.Users.SingleOrDefault(x =>x.password==pass);
            if(user is null && user2 is null)
            {
                MessageBox.Show("Как так,давай попробуй заново вести данные");
                return;
            }
            else
            {
                MessageBox.Show("Красава ты все правильно сделан");
                var id = context.Users.Where(x => x.login == login.Text).SingleOrDefault().Id;
                Katalog  kat = new Katalog(id);
                kat.Show();
                this.Hide();
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registrarion win = new Registrarion();
            win.Show();
        }
    }
}
