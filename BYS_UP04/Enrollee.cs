using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS_UP04
{
    public class Enrollee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private string name;
        private string surname;
        private string patronymic;
        private DateTime dataBirth;
        private string floor;
        private string citizenship;
        private string placeResidence;
        private string city;
        private string cityship;
        public  string classSchool;
        private string graduation;
        private double certificate;
        private string sNILS;
        private string disability;
        private byte[] disabilityScan;
        private string orphanhood;
        private byte[] orphanhoodScan;
        private string speciality;
        private string numberCertificate;
        private byte[] numberCertificateScan;
        private string budget;
        private string enlisted;
        private DateTime dataReception;

        public Enrollee()
        {

        }
        public Enrollee(  
            string Name,
            byte[] disabilityScan,
            string Surname, 
            string Patronymic,
            string citizenship,
            DateTime dataBirth,
            string placeResidence,
            string city,
            string cityship,
            string classSchool,
            string graduation,
            double certificate,
            byte[] orphanhoodScan,
            byte[] numberCertificateScan,
            string sNILS,
            string disability,
            string orphanhood,
            string speciality,
            string numberCertificate,
            string budget,
            string enlisted,
            DateTime dataReception

            )

        {
            int id = Id;
            this.Id= id;
            this.name = Name;
            DisabilityScan = disabilityScan;
            this.surname = Surname;
            this.patronymic = Patronymic;
            Citizenship = citizenship;
            DataBirth = dataBirth;
            PlaceResidence = placeResidence;
            City = city;
            this.cityship = cityship;
            ClassSchool = classSchool;
            Graduation = graduation;
            Certificate = certificate;
            SNILS = sNILS;
            OrphanhoodScan = orphanhoodScan;
            NumberCertificateScan = numberCertificateScan;
            Disability = disability;
            Orphanhood = orphanhood;
            Speciality = speciality;
            NumberCertificate = numberCertificate;
            Budget = budget;
            Enlisted = enlisted;
            DataReception = dataReception;
            this.citizenship = Citizenship;
            this.placeResidence= PlaceResidence;
            this.city = City;
            this.certificate = Certificate;
            this.sNILS = SNILS;
            this.disability = Disability;
            this.orphanhood = Orphanhood;
            this.speciality = Speciality;
            this.numberCertificate = NumberCertificate;
            this.budget = Budget;
            this.enlisted = Enlisted;
            this.dataReception = DataReception;
            this.floor=Floor;
            this.dataBirth=DataBirth;

            
            

        }


        public byte[] NumberCertificateScan
        {
            get => numberCertificateScan;
            set
            {
                numberCertificateScan = value;
                OnPropertyChanged(nameof(NumberCertificateScan));
            }
        }

        public byte[] OrphanhoodScan
        {
            get => orphanhoodScan;
            set
            {
                orphanhoodScan = value;
                OnPropertyChanged(nameof(OrphanhoodScan));
            }
        }


        public byte[] DisabilityScan
        {
            get => disabilityScan;
            set
            {
                disabilityScan = value;
                OnPropertyChanged(nameof(DisabilityScan));
            }
        }


        public string ClassSchool
        {
            get => classSchool;
            set
            {
                classSchool = value;
                OnPropertyChanged(nameof(ClassSchool));
            }
        }

        public string CityShip
        {
            get => cityship;
            set
            {
                cityship = value;
                OnPropertyChanged(nameof(CityShip));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public DateTime DataBirth
        {
            get => dataBirth;
            set
            {
                dataBirth = value;
                OnPropertyChanged(nameof(DataBirth));
            }
        }

        public string Floor
        {
            get => floor;
            set
            {
                floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }

        public string Citizenship
        {
            get => citizenship;
            set
            {
                citizenship = value;
                OnPropertyChanged(nameof(Citizenship));
            }
        }

        public string PlaceResidence
        {
            get => placeResidence;
            set
            {
                placeResidence = value;
                OnPropertyChanged(nameof(PlaceResidence));
            }
        }


        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(PlaceResidence));
            }
        }

        public string Graduation
        {
            get => graduation;
            set
            {
                graduation = value;
                OnPropertyChanged(nameof(Graduation));
            }
        }

        public double Certificate
        {
            get => certificate;
            set
            {
                certificate = value;
                OnPropertyChanged(nameof(Certificate));
            }
        }

        public string SNILS
        {
            get => sNILS;
            set
            {
                sNILS = value;
                OnPropertyChanged(nameof(SNILS));
            }
        }

        public string Disability
        {
            get => disability;
            set
            {
                disability = value;
                OnPropertyChanged(nameof(Disability));
            }
        }

        public string Orphanhood
        {
            get => orphanhood;
            set
            {
                orphanhood = value;
                OnPropertyChanged(nameof(Orphanhood));
            }
        }

        public string Speciality
        {
            get => speciality;
            set
            {
                speciality = value;
                OnPropertyChanged(nameof(Speciality));
            }
        }

        public string NumberCertificate
        {
            get => numberCertificate;
            set
            {
                numberCertificate = value;
                OnPropertyChanged(nameof(NumberCertificate));
            }
        }

        public string Budget
        {
            get => budget;
            set
            {
                budget = value;
                OnPropertyChanged(nameof(Budget));
            }
        }

        public string Enlisted
        {
            get => enlisted;
            set
            {
                enlisted = value;
                OnPropertyChanged(nameof(Enlisted));
            }
        }

        public DateTime DataReception
        {
            get => dataReception;
            set
            {
                dataReception = value;
                OnPropertyChanged(nameof(DataReception));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}

