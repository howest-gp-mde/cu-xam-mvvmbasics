﻿using System;
using System.ComponentModel;
using System.Linq;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class ClassmateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IClassmateRepository _classmateRepositoy;
        private ISeederService _seederService;

        private Classmate _currentClassmate; // holds classmate being edited

        public ClassmateViewModel()
        {
            //todo: inject this dependencies instead of
            //      instantiating a concrete implementation.
            _classmateRepositoy = new JsonClassmateRepository();
            _seederService = new SeedDataStoreService(_classmateRepositoy);

            //todo: DO NOT call async or long-running operations in the
            //      constructor, move this to a command
            _seederService.EnsureSeeded();
            _currentClassmate = _classmateRepositoy.GetAll().Result.FirstOrDefault();
            
            //initialize the properties with data from domain model
            this.Name = _currentClassmate.Name;
            this.Phone = _currentClassmate.Phone;
            this.Birthdate = _currentClassmate.Birthdate;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }
        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                RaisePropertyChanged(nameof(Birthdate));
            }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - birthdate.Year;
                if (birthdate > DateTime.Now.AddYears(-age)) age--; //adjust for leap year
                return age;
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event if it has handlers attached to it
        /// </summary>
        /// <param name="propertyName">name of the prop that was changed</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
