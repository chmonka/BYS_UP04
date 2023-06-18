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
            string[] headers = { "Индитификатор сотрудника", "Фамилия", "Имя", "Отчество", "Дата рождения", "Номер телефона", "Отдел" };
            for (int i = 1; i <= headers.Length; i++)
            {
                sheet.Cells[1, i].Value = headers[i - 1];
            }
            int currString = 2;
            foreach (var person in data)
            {
                
                sheet.Cells[currString, 2].Value = person.Surname;
                sheet.Cells[currString, 3].Value = person.Name;
                sheet.Cells[currString, 5].Value = person.Patronymic;

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
