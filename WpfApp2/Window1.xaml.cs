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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //вход
            if (Soisk.Text.Length > 0 && Rab.Text.Length > 0 && Dolg.Text.Length > 0 && Cent.Text.Length > 0)
            {
                MessageBox.Show("Договор заключен");
            }
            else MessageBox.Show("Вы не заполнили поля");
            Soisk.Text = "";
            Rab.Text = "";
            Dolg.Text = "";
            Cent.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Rabota rabota = new Rabota();
            rabota.Show();
            this.Close();
        }

    
    }
}
