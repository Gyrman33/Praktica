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
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        int UserId = 0;
        public Katalog(int id)
        {
            InitializeComponent();
            UserId = id;
            var abc = new appDbContext();
            Lttovar.ItemsSource = abc.Tovars.ToList();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Korzina personal_Account = new Korzina(UserId);
            personal_Account.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var abc = new appDbContext();
            string Tovar = abc.Tovars.SingleOrDefault(x => x.Id == Lttovar.SelectedIndex + 4).Nazv;
            int IDTovar = abc.Tovars.SingleOrDefault(x => x.Id == Lttovar.SelectedIndex + 4).Id;
            int Kolvo = abc.Tovars.SingleOrDefault(x => x.Id == Lttovar.SelectedIndex + 4).Kolvo;
            string Pic = abc.Tovars.SingleOrDefault(x => x.Id == Lttovar.SelectedIndex + 4).Pic;
            int stoimost = abc.Tovars.SingleOrDefault(x => x.Id == Lttovar.SelectedIndex + 4).Stoimost;
            abc.Korzs.Add(new Korz { User = UserId, Nazv = Tovar, Kolvo = Convert.ToInt32(Tb_Kolvo.Text), Pic = Pic, Stoimost = stoimost, TovaraIdi = IDTovar });
            abc.SaveChanges();
        }
    }
}
