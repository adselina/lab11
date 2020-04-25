using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Schooler : Person, IExecutable, ICloneable //производный класс
    {
        private int year;
        private string status = "Школьник";
        public int Year
        {
            get { return year; }
            set { if (value > 0 && value < 12) { year = value; } else { year = 1; } }
        } //класс от 1 до 11
        public Schooler() : base()
        {
            Year = new Random().Next(1, 12); 
        }
        public Schooler(string name, int age, int year) : base(name, age)
        {
            this.Year = year;
        }

        override public void Show()
        {
            Console.WriteLine(this.ToString());
            //Console.WriteLine($"{status}, имя: {Name}, класс: {Year}");
        }
        new public object Clone()
        {
            Schooler temp = new Schooler(Name, Age, year);
            return temp;
        }

        new public Schooler ShallowCopy()
        {
            return (Schooler)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return obj is Schooler schooler &&
                   base.Equals(obj) &&
                   year == schooler.year &&
                   status == schooler.status &&
                   Year == schooler.Year;
        }
        
        public override string ToString()
        {
            return status + ": " + Name + ", возраст:" + Age + ", Класс " + Year;
        }

        public override int GetHashCode()
        {
            var hashCode = -245957495;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
