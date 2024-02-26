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
    /// Логика взаимодействия для Registrarion.xaml
    /// </summary>
    public partial class Registrarion : Window
    {
        public Registrarion()
        {
            InitializeComponent();
        }

        private void obratno_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow ss = new MainWindow();
            ss.Show();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            var log = login.Text;
            var pass = passw.Text;
            var context = new appDbContext();
            var user_exists = context.Users.FirstOrDefault(x =>x.login == log);
            if (user_exists != null)
            {
                MessageBox.Show("Такой пользователь уже зарегистрирован");
                return;
            }
            var user = new User { login = log, password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрированы");
        }
    }
}
