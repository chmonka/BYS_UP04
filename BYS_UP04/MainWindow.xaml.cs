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
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;



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

            Enrollee? Staff = StudentList.SelectedItem as Enrollee;

            if (Staff is null) return;
            dbcontext.Enrollees.Remove(Staff);
            dbcontext.SaveChanges();
        }



        private void Info_click(object sender, RoutedEventArgs e)
        {

            Enrollee user = StudentList.SelectedItem as Enrollee;

            if (user is null) return;

            FormWindow UserWindow = new FormWindow(new Enrollee
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                DataBirth = user.DataBirth,
                Floor = user.Floor,
                Citizenship = user.Citizenship,
                PlaceResidence = user.PlaceResidence,
                City = user.City,
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
                    user.Id = UserWindow.Enrollee.Id;
                    user.Name = UserWindow.Enrollee.Name;
                    user.Surname = UserWindow.Enrollee.Surname;
                    user.Patronymic = UserWindow.Enrollee.Patronymic;
                    user.DataBirth = UserWindow.Enrollee.DataBirth;
                    user.Floor = UserWindow.Enrollee.Floor;
                    user.Citizenship = UserWindow.Enrollee.Citizenship;
                    user.PlaceResidence = UserWindow.Enrollee.PlaceResidence;
                    user.City = UserWindow.Enrollee.City;
                    user.Graduation = UserWindow.Enrollee.Graduation;
                    user.Certificate = UserWindow.Enrollee.Certificate;
                    user.SNILS = UserWindow.Enrollee.SNILS;
                    user.Disability = UserWindow.Enrollee.Disability;
                    user.Orphanhood = UserWindow.Enrollee.Orphanhood;
                    user.Speciality = UserWindow.Enrollee.Speciality;
                    user.NumberCertificate = UserWindow.Enrollee.NumberCertificate;
                    user.Budget = UserWindow.Enrollee.Budget;
                    user.Enlisted = UserWindow.Enrollee.Enlisted;
                    user.DataReception = UserWindow.Enrollee.DataReception;

                    dbcontext.SaveChanges();
                    StudentList.Items.Refresh();
                }
            }
        }

        private void CreateExcelfile(object sender, RoutedEventArgs e)
        {
            Exportexcel ExcelExport = new Exportexcel();
            ExcelExport.CreateExcelfile(dbcontext.Enrollees.Local.ToObservableCollection());
        }


        List<Enrollee> filterModeList = new List<Enrollee>();
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeList.Clear();

            if (textBoxSearch.Text.Equals(""))
            {
                List<Enrollee> studentList = new List<Enrollee>();
                using (var db = new DBcontext())
                {
                    var query = from b in db.Enrollees select b;
                    foreach (var item in query)
                    {
                        studentList.Add(item);
                    }
                }
                StudentList.ItemsSource = studentList;
            }
            else
            {
                List<Enrollee> studentList = new List<Enrollee>();
                using (var db = new DBcontext())
                {
                    var query = from b in db.Enrollees select b;
                    foreach (var item in query)
                    {
                        if (item.Name.Contains(textBoxSearch.Text) || item.Surname.Contains(textBoxSearch.Text)
                            || item.Patronymic.Contains(textBoxSearch.Text))
                        {
                            studentList.Add(item);
                        }
                        
                    }
                }
                StudentList.ItemsSource = studentList;
            }

        }
    }
}
           

        
