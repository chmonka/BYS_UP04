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
        private string dataBirth;
        private string floor;
        private string citizenship;
        private string placeResidence;
        private string graduation;
        private byte[] certificate;
        private string sNILS;
        private byte[] disability;
        private byte[] orphanhood;
        private string speciality;
        private double numberCertificate;
        private string budget;
        private string enlisted;
        private string dataReception;

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

        public string DataBirth
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

        public string Graduation
        {
            get => graduation;
            set
            {
                graduation = value;
                OnPropertyChanged(nameof(Graduation));
            }
        }

        public byte[] Certificate
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

        public byte[] Disability
        {
            get => disability;
            set
            {
                disability = value;
                OnPropertyChanged(nameof(Disability));
            }
        }

        public byte[] Orphanhood
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

        public double NumberCertificate
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

        public string DataReception
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

