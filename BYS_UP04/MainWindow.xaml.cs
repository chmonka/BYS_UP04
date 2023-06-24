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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Microsoft.Win32;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace BYS_UP04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
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
                CityShip = user.CityShip,
                ClassSchool = user.ClassSchool,


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
                    user.ClassSchool = UserWindow.Enrollee.ClassSchool;
                    user.CityShip = UserWindow.Enrollee.CityShip;

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
                        if (item.Name.Contains(textBoxSearch.Text) 
                            || item.Surname.Contains(textBoxSearch.Text)
                            || item.Patronymic.Contains(textBoxSearch.Text)
                            || item.City.Contains(textBoxSearch.Text) 
                            || item.SNILS.Contains(textBoxSearch.Text) 
                            || item.Budget.Contains(textBoxSearch.Text) 
                            || item.Speciality.Contains(textBoxSearch.Text)
                            ||item.Citizenship.Contains(textBoxSearch.Text)                          
                            ||item.Enlisted.Contains(textBoxSearch.Text)
                            ||item.Floor.Contains(textBoxSearch.Text)
                            ||item.Graduation.Contains(textBoxSearch.Text)
                            )
                        {
                            studentList.Add(item);
                        }

                    }
                }
                StudentList.ItemsSource = studentList;
            }

        }

        public void btnView1(object sender, EventArgs e)
        {


            var selectedStudent = StudentList.SelectedItem as Enrollee;
            ObservableCollection<Enrollee> entrants = dbcontext.Enrollees.Local.ToObservableCollection();
           
            SaveFileDialog openFileDialog = new SaveFileDialog();

            openFileDialog.FileName = "Scan"; 
            openFileDialog.DefaultExt = ".png"; 
            openFileDialog.Filter = "Фaйлы изображений (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf"; 
            Nullable<bool> result = openFileDialog.ShowDialog();
          
            if (result == true)
            {

                // Save document
                string filename = openFileDialog.FileName;
                
                if (entrants[selectedStudent.Id - 1 ].DisabilityScan == null)
                {
                    MessageBox.Show("Скан справки о сиротстве/опекунстве не был загружен!", Title = "Oшибкa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                File.WriteAllBytes(filename, entrants[selectedStudent.Id - 1 ].DisabilityScan);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "mspaint.exe";
                startInfo.Arguments = filename;
                Process.Start(startInfo);
            }
        }

        public void btnView2(object sender, EventArgs e)
        {


            var selectedStudent = StudentList.SelectedItem as Enrollee;
            ObservableCollection<Enrollee> entrants = dbcontext.Enrollees.Local.ToObservableCollection();

            SaveFileDialog openFileDialog = new SaveFileDialog();

            openFileDialog.FileName = "Scan";
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Фaйлы изображений (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {

                // Save document
                string filename = openFileDialog.FileName;

                if (entrants[selectedStudent.Id - 1].OrphanhoodScan == null)
                {
                    MessageBox.Show("Скан справки о сиротстве/опекунстве не был загружен!", Title = "Oшибкa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                File.WriteAllBytes(filename, entrants[selectedStudent.Id - 1].OrphanhoodScan);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "mspaint.exe";
                startInfo.Arguments = filename;
                Process.Start(startInfo);
            }
        }

        public void btnView3(object sender, EventArgs e)
        {


            var selectedStudent = StudentList.SelectedItem as Enrollee;
            ObservableCollection<Enrollee> entrants = dbcontext.Enrollees.Local.ToObservableCollection();

            SaveFileDialog openFileDialog = new SaveFileDialog();

            openFileDialog.FileName = "Scan";
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Фaйлы изображений (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {

                // Save document
                string filename = openFileDialog.FileName;

                if (entrants[selectedStudent.Id - 1].NumberCertificateScan == null)
                {
                    MessageBox.Show("Скан справки о сиротстве/опекунстве не был загружен!", Title = "Oшибкa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                File.WriteAllBytes(filename, entrants[selectedStudent.Id - 1].NumberCertificateScan);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "mspaint.exe";
                startInfo.Arguments = filename;
                Process.Start(startInfo);
            }
        }

    }
}

           

        
