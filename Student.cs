using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Student : Person, IExecutable, ICloneable
    {
        private int course;
        private string status = "Студент";
        
        public int Course
        {
            get { return course; }
            set { if (value > 0 && value < 5) { course = value; } else { course = 1; } }
        }//курс от 1 до 4 
        
        public Person BasePerson()
        {
            return new Person(this.Name, this.Age);
        }
        public Student() : base()
        {
            Course = new Random().Next(1, 5);
        } //конструктор с параметром

        public Student(string name, int age, int course) : base(name, age)
        {
            this.Course = course;
        } //конструктор с параметром

        override public void Show()
        {
            Console.WriteLine(this.ToString());
            //Console.WriteLine($"{status}, имя: {Name}, курс: {Course}");
        }
 
        new public object Clone()
        {
            Student temp = new Student(Name, Age, course);
            return temp;
        }
        new public Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&
                   course == student.course &&
                   status == student.status &&
                   Course == student.Course;
        }
        
        override public string ToString()
        {
            //return status + ": " + Name + ", Курс " + Course;
            return status + ": " + Name + ", возраст:" + Age + ", Курс " + Course;
        }

        public override int GetHashCode()
        {
            var hashCode = -625544507;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            hashCode = hashCode * -1521134295 + Course.GetHashCode();
            return hashCode;
        }
    }
}
