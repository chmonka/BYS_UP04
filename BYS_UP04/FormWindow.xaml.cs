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

namespace BYS_UP04
{
    /// <summary>
    /// Логика взаимодействия для FormWindow.xaml
    /// </summary>
    public partial class FormWindow : Window
    {
       


        public Enrollee Enrollee {get; private set; }
    

        public FormWindow(Enrollee enrollee )
        {
            InitializeComponent();
            Enrollee = enrollee;
            DataContext = Enrollee;


        }

        private void AddForm(object sender, RoutedEventArgs e)
        {



            if (string.IsNullOrEmpty(Surname.Text))
            {
                MessageBox.Show("Заполните поле 'Фамилия' ");

            }

            else if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Заполните поле 'Имя' ");
            }

            else if (string.IsNullOrEmpty(Patronymic.Text))
            {
                MessageBox.Show("Заполните поле 'Отчество' ");
            }

            else if (string.IsNullOrEmpty(Citizenship.Text))
            {
                MessageBox.Show("Заполните поле 'Гражданство' ");
            }

            else if (string.IsNullOrEmpty(PlaceResidences.Text))
            {
                MessageBox.Show("Заполните поле 'Место проживания' ");
                
            }

            else
            {
                DialogResult = true;
            }
            
        }

        private void CityShip(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)combobox.SelectedItem;
            if (comboBoxItem == Other)
            {
                BoxCityShip.Visibility = Visibility.Visible;
            }
            else
            {
                BoxCityShip.Visibility = Visibility.Hidden;
            }
        }

        private void PlaceResidence(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox1=(ComboBox)sender;
            ComboBoxItem comboBoxItem1=(ComboBoxItem)combobox1.SelectedItem;
            if(comboBoxItem1 == PlaceResidenceKostroma)
            {
               ComboBoxPlaceResidence.Visibility = Visibility.Visible;
            }
            else
            {
                ComboBoxPlaceResidence.Visibility = Visibility.Hidden;
            }
        }

        private void Class911(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox2 = (ComboBox)sender;
            ComboBoxItem comboBoxItem2=(ComboBoxItem)combobox2.SelectedItem;
            if (comboBoxItem2 == NoClass) 
            {
                ComboBoxClass.Visibility = Visibility.Visible;
            }
            else
            {
                ComboBoxClass.Visibility = Visibility.Hidden;
            }
        }


        private void DisabilityBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox3 = (ComboBox)sender;
            ComboBoxItem comboBoxItem2 = (ComboBoxItem)combobox3.SelectedItem;
            if (comboBoxItem2 == NoDisabilityBox)
            {
                ButtonDisability.Visibility = Visibility.Hidden;
            }
            else  
            {
                ButtonDisability.Visibility = Visibility.Visible;
            }
        }

        private void OrphanhoodBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox3 = (ComboBox)sender;
            ComboBoxItem comboBoxItem2 = (ComboBoxItem)combobox3.SelectedItem;
            if (comboBoxItem2 == NoOrphanhoodBox)
            {
                ButtonOrphanhoodBox.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonOrphanhoodBox.Visibility = Visibility.Visible;
            }
        }


        private void DatePriema_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Enrollee.DataReception = DatePriema.SelectedDate.GetValueOrDefault();
        }

        private void DateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Enrollee.DataBirth = DateBirth.SelectedDate.GetValueOrDefault();
        }
    }
}
