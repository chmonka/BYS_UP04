using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS_UP04
{
    internal class Exportexcel
    {
      

        public void CreateExcelfile(ObservableCollection<Enrollee> data)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage staff = new ExcelPackage();
            ExcelWorksheet sheet = staff.Workbook.Worksheets.Add("Лист");
            string[] headers = { 
                "Фамилия", 
                "Имя", 
                "Отчество" , 
                "Дата рождения", 
                "Пол", 
                "Гражданство", 
                "Гражданство(Другое)", 
                "Место проживания", 
                "Город", 
                "Окончание 9(11) классов",
                "Окончание 9(11) классов(Другое)",
                "Средний балл аттестата",
                "СНИЛС",
                "Справка об инвалидности",
                "Сиротсво/Опекуество",
                "Специальность",
                "Номер аттестата",
                "Бюджет/Небюджет",
                "Зачислен(-на)/Незачислен(-на)",
                "Дата приёма"};

            for (int i = 1; i <= headers.Length; i++)
            {
                sheet.Cells[1, i].Value = headers[i - 1];
            }
            int currString = 2;

            foreach (var person in data)
            {
                
                sheet.Cells[currString, 1].Value = person.Surname;
                sheet.Cells[currString, 2].Value = person.Name;
                sheet.Cells[currString, 3].Value = person.Patronymic;
                sheet.Cells[currString, 4].Value = person.DataBirth.ToShortDateString();
                sheet.Cells[currString, 5].Value = person.Floor;
                sheet.Cells[currString, 6].Value = person.Citizenship;
                sheet.Cells[currString, 7].Value = person.CityShip;
                sheet.Cells[currString, 8].Value = person.PlaceResidence;
                sheet.Cells[currString, 9].Value = person.City;
                sheet.Cells[currString, 10].Value = person.Graduation;
                sheet.Cells[currString, 11].Value = person.ClassSchool;
                sheet.Cells[currString, 12].Value = person.Certificate;
                sheet.Cells[currString, 13].Value = person.SNILS;
                sheet.Cells[currString, 14].Value = person.Disability;
                sheet.Cells[currString, 15].Value = person.Orphanhood;
                sheet.Cells[currString, 16].Value = person.Speciality;
                sheet.Cells[currString, 17].Value = person.NumberCertificate;
                sheet.Cells[currString, 18].Value = person.Budget;
                sheet.Cells[currString, 19].Value = person.Enlisted;
                sheet.Cells[currString, 20].Value = person.Budget;
                sheet.Cells[currString, 20].Value = person.DataReception.ToShortDateString();

                currString += 1;
            }

            for (int i = 1; i <= headers.Length; i++)
            {
                sheet.Column(i).AutoFit();
            }
            string DRpath = "Reports";
            if (Directory.Exists(DRpath) == false)
            {
                Directory.CreateDirectory(DRpath);
            }
            string exportfile = "Report.xlsx";
            DRpath = System.IO.Path.Combine(DRpath, exportfile);
            if (File.Exists(DRpath))
                File.Delete(DRpath);
            FileStream objFileStrm = File.Create(DRpath);
            objFileStrm.Close();
            File.WriteAllBytes(DRpath, staff.GetAsByteArray());
            staff.Dispose();



        }
    }
}
