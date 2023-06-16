using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

namespace BYS_UP04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBcontext dbcontext = new DBcontext();

        public void Mainwindowloaded(object sender, RoutedEventArgs e)
        {
            dbcontext.Database.EnsureCreated();
            dbcontext.Enrollees.Load();
            DataContext = dbcontext.Enrollees.Local.ToObservableCollection();
        }


        public MainWindow()
        {
            InitializeComponent();
            Loaded += Mainwindowloaded;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FormWindow FormWindow = new FormWindow(new Enrollee());

            if (FormWindow.ShowDialog() == true)
            {
                Enrollee enrollee = FormWindow.Enrollee;
                dbcontext.Enrollees.Add(enrollee);
                dbcontext.SaveChanges();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Enrollee? Staff = List.SelectedItem as Enrollee;

            if (Staff is null) return;
            dbcontext.Enrollees.Remove(Staff);
            dbcontext.SaveChanges();
        }



        private void Info_click(object sender, RoutedEventArgs e)
        {

            Enrollee user = List.SelectedItem as Enrollee;

            if (user is null) return;

            FormWindow UserWindow = new FormWindow(new Enrollee
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                DataBirth = user.DataBirth,
                Floor = user.Floor,
                Citizenship = user.Citizenship,
                PlaceResidence = user.PlaceResidence,
                Graduation = user.Graduation,
                Certificate = user.Certificate,
                SNILS = user.SNILS,
                Disability = user.Disability,
                Orphanhood = user.Orphanhood,
                Speciality = user.Speciality,
                NumberCertificate = user.NumberCertificate,
                Budget = user.Budget,
                Enlisted = user.Enlisted,
                DataReception = user.DataReception,

            });


            if (UserWindow.ShowDialog() == true)
            {

                user = dbcontext.Enrollees.Find(UserWindow.Enrollee.Id);
                if (user != null)
                {

                    user.Name = UserWindow.Enrollee.Name;
                    user.Surname = UserWindow.Enrollee.Surname;
                    user.Patronymic  = UserWindow.Enrollee.Patronymic;
                    user.DataBirth = UserWindow.Enrollee.DataBirth;

                    dbcontext.SaveChanges();
                    List.Items.Refresh();
                }
            }
        }
    }
}

           

        
