using System;
using System.Collections.Generic;

namespace Lab1
{
    class Citizen
    {
        private string name_;
        private string surname_;
        private string gender_;
        private int age_;
        private string identNumer_;


        public Citizen(string name, string surname, string gender, int age, string identNumber)
        {
            this.name_ = name;
            this.surname_ = surname;
            this.gender_ = gender;
            this.age_ = age;
            this.identNumer_ = identNumber;
        }

        public string Name_ { get => name_; set => name_ = value; }
        public string Surname_ { get => surname_; set => surname_ = value; }
        public string Gender_ { get => gender_; set => gender_ = value; }
        public int Age_ { get => age_; set => age_ = value; }
        public string IdentNumer_ { get => identNumer_; set => identNumer_ = value; }
    }
}
