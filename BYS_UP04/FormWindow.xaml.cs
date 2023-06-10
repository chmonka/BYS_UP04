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
        public FormWindow()
        {
            InitializeComponent();
        }

        private void CityShip(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)combobox.SelectedItem;
            if (comboBoxItem == Other)
            {
                BoxCityShip.Visibility = Visibility.Visible;
            }
        }
    }
}
