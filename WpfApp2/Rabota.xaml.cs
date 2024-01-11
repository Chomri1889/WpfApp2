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
using System.Xml.Linq;
using System.Xml.XPath;
using System.ComponentModel;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Rabota.xaml
    /// </summary>
    public partial class Rabota : Window
    {
        
        public Rabota()
        {
            InitializeComponent();
        }
        XDocument doc = XDocument.Load("Rabota.xml");
        XDocument doc2 = XDocument.Load("Sotrudniki.xml");
        public void Rabotad_Initialize()
        {
            var rabotad = (from x in doc.Element("rabotad").Elements("rabota")
                            orderby x.Element("ID_Rab").Value
                            select new
                            {
                                ID = x.Element("ID_Rab").Value,
                                Название = x.Element("ID_Name").Value,
                                Вид_Деятельности = x.Element("Vid_Deat").Value,
                                Адрес = x.Element("ID_Adres").Value,
                                Телефон = x.Element("ID_Telefon").Value
                            }).ToList();
            dataGrid.ItemsSource = rabotad;
        }
        public void Sotrudniki_Initialize()
        {
            var sotrudniki = (from d in doc2.Element("sotrudniki").Elements("sotrudnik")
                              orderby d.Element("One_Name").Value
                              select new
                              {
                                  Имя = d.Element("One_Name").Value,
                                  Фамилия = d.Element("Two_Name").Value,
                                  Отчество = d.Element("Tree_Name").Value,
                                  Код_соискателя = d.Element("ID_TextBox").Value,

                                  Квалификация = d.Element("Adress_TextBox").Value,
                                  Вид_Деятельности = d.Element("Dejat_TextBox").Value,
                                  Иные_Данные = d.Element("Telefon_TextBox").Value,
                                  Предполагаемый_размер_заработной_платы = d.Element("Telefon_Cent").Value,
                              }).ToList();
            dataGrid2.ItemsSource = sotrudniki;

        }
        private void Loading2(object sender, RoutedEventArgs e)
        {
            Sotrudniki_Initialize();
        }
        private void Safe_Button_Click(object sender, RoutedEventArgs e)
        /// Кнопка сохранения 

        {
            doc.Element("rabotad").Add(new XElement("rabota",
                new XElement("ID_Rab", ID_Box.Text),
                new XElement("ID_Name", Code_Box.Text),
                new XElement("Vid_Deat", Date_Taking_Box.Text),
                new XElement("ID_Adres", Date_Box.Text),
                new XElement("ID_Telefon", Date_Tel.Text)));
                doc.Save("Rabota.xml");
                MessageBox.Show("Сохранено");
                Rabotad_Initialize();
                ID_Box.Text = "";
                Code_Box.Text = "";
                Date_Taking_Box.Text = "";
                Date_Box.Text = "";
                Date_Tel.Text = "";
        }
        private void Izmen_Button_Click(object sender, RoutedEventArgs e)
        {
            object СInfo3 = (dataGrid.SelectedCells[0].Column.GetCellContent(dataGrid.SelectedItem) as TextBlock).Text;
            doc.Element("rabota").Elements("rabota").First(pc => pc.Element("ID_Rab").Value == СInfo3).ReplaceAll(
                new XElement("ID_Rab", ID_Box.Text),
                new XElement("ID_Name", Code_Box.Text),
                new XElement("Vid_Deat", Date_Taking_Box.Text),
                new XElement("ID_Adres", Date_Box.Text),
                new XElement("ID_Telefon", Date_Tel.Text)
                );
            doc.Save("Rabota.xml");
            MessageBox.Show("Изменено");
            Rabotad_Initialize();
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                object Id_delka = (dataGrid.SelectedCells[0].Column.GetCellContent(dataGrid.SelectedItem) as TextBlock).Text;
                    doc.Element("rabotad").Elements("rabota").First(b => b.Element("ID_Rab").Value == Id_delka).Remove();
                    MessageBox.Show("Данные удалены");
                    Rabotad_Initialize();

            }
            else MessageBox.Show("Запись не найдена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            Rabotad_Initialize();
        }
        public void ID_TextBox(object sender, TextChangedEventArgs e)
        {
          
            
                var sotrudniki = (from x in doc.Element("sotrudniki").Elements("sotrudnik")
                                  orderby x.Element("ID_Soisk").Value
                                  select new
                                  {
                                      Имя = x.Element("ID_Soisk").Value,
                                      Фамилия = x.Element("Id_Name_Fam").Value,
                                      Отчество = x.Element("Id_Name_Ot").Value,
                                      Код_соискателя = x.Element("ID_Soisk").Value,

                                      Квалификация = x.Element("Name_TextBox").Value,
                                      Вид_Деятельности = x.Element("Date_Deat").Value,
                                      Иные_Данные = x.Element("Date_Box").Value,
                                      Предполагаемый_размер_заработной_платы = x.Element("Date_Cen").Value,
                                  }).ToList();
                dataGrid2.ItemsSource = sotrudniki;
            
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            doc2.Element("sotrudniki").Add(new XElement("sotrudnik",
               new XElement("ID_TextBox", ID_Soisk.Text),
               new XElement("Two_Name", Two_Name.Text),
                new XElement("One_Name", Id_Name.Text), 
                new XElement("Tree_Name", Tree_Name.Text),
                new XElement("Dejat_TextBox", Date_Deat.Text), 
                new XElement("Adress_TextBox", Date_Kvalific.Text),
                new XElement("Telefon_TextBox", Date_Box2.Text),
                new XElement("Telefon_Cent", Date_Cen.Text)));
            doc2.Save("Sotrudniki.xml");
            MessageBox.Show("Данные добавлены");
            
        }
        private void Safefen_Button_Click(object sender, RoutedEventArgs e)
        {

            doc2.Element("sotrudniki").Add(new XElement("sotrudnik",
               new XElement("ID_TextBox", ID_Soisk.Text),
               new XElement("Two_Name", Two_Name.Text),
                new XElement("One_Name", Id_Name.Text),
                new XElement("Tree_Name", Tree_Name.Text),
                new XElement("Dejat_TextBox", Date_Deat.Text),
                new XElement("Adress_TextBox", Date_Kvalific.Text),
                new XElement("Telefon_TextBox", Date_Box2.Text),
                new XElement("Telefon_Cent", Date_Cen.Text)));
            doc2.Save("Sotrudniki.xml");
            MessageBox.Show("Сохранено");
            Sotrudniki_Initialize();
            ID_Soisk.Text = "";
            Two_Name.Text = "";
            Id_Name.Text = "";
            Tree_Name.Text = "";
            Date_Deat.Text = "";
            Date_Kvalific.Text = "";
            Date_Box2.Text = "";
            Date_Cen.Text = "";
        }
        private void Del_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                object Id_del2 = (dataGrid2.SelectedCells[3].Column.GetCellContent(dataGrid2.SelectedItem) as TextBlock).Text;
                doc2.Element("sotrudniki").Elements("sotrudnik").First(nb => nb.Element("ID_TextBox").Value == Id_del2).Remove();
                doc2.Save("Sotrudniki.xml");
                MessageBox.Show("Данные удалены");
                Sotrudniki_Initialize();

            }
            else MessageBox.Show("Запись не найдена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            Sotrudniki_Initialize();
        }
        private void Izmenenia_Button_Click(object sender, RoutedEventArgs e)
        {
            object СInfo26 = (dataGrid2.SelectedCells[0].Column.GetCellContent(dataGrid2.SelectedItem) as TextBlock).Text;
            doc2.Element("sotrudniki").Elements("sotrudnik").First(k => k.Element("ID_TextBox").Value == СInfo26).ReplaceAll(
               new XElement("ID_TextBox", ID_Soisk.Text),
               new XElement("Two_Name", Two_Name.Text),
                new XElement("One_Name", Id_Name.Text),
                new XElement("Tree_Name", Tree_Name.Text),
                new XElement("Dejat_TextBox", Date_Deat.Text),
                new XElement("Adress_TextBox", Date_Kvalific.Text),
                new XElement("Telefon_TextBox", Date_Box2.Text),
                new XElement("Telefon_Cent", Date_Cen.Text));
            doc2.Save("Sotrudniki.xml");
            MessageBox.Show("Изменено");
            Sotrudniki_Initialize();

        }
        private void Loading(object sender, RoutedEventArgs e)
        {
            Rabotad_Initialize();
        }

        private void Dogovor_Click(object sender, RoutedEventArgs e)
        {
            
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();

        }

        private void Poisk(object sender, RoutedEventArgs e)
        {
            var search33 = from xe in doc2.Element("sotrudniki").Elements("sotrudnik")
                         where xe.Element("ID_TextBox").Value == clientsearch.Text
                         orderby xe.Element("ID_TextBox").Value
                         select new
                         {
                             Имя = xe.Element("One_Name").Value,
                             Фамилия = xe.Element("Two_Name").Value,
                             Отчество = xe.Element("Tree_Name").Value,
                             Код_соискателя = xe.Element("ID_TextBox").Value,

                             Квалификация = xe.Element("Dejat_TextBox").Value,
                             Вид_Деятельности = xe.Element("Adress_TextBox").Value,
                             Иные_Данные = xe.Element("Telefon_TextBox").Value,
                             Предполагаемый_размер_заработной_платы = xe.Element("Telefon_Cent").Value,
                         };
            dataGrid2.ItemsSource = search33;
        }
        private void Poisk_two_Click(object sender, RoutedEventArgs e)
        {
            var search2 = from xi in doc.Element("rabotad").Elements("rabota")
                         where xi.Element("ID_Rab").Value == clientsearch2.Text
                         orderby xi.Element("ID_Rab").Value
                         select new
                         {
                             ID = xi.Element("ID_Rab").Value,
                             Название = xi.Element("ID_Name").Value,
                             Вид_Деятельности = xi.Element("Vid_Deat").Value,
                             Адрес = xi.Element("ID_Adres").Value,
                             Телефон = xi.Element("ID_Telefon").Value,
                         };
            dataGrid.ItemsSource = search2;
        }
    }


}
