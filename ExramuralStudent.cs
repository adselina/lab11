using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class ExramuralStudent : Student, IExecutable, ICloneable
    {
        private int examMark1;
        private int examMark2;
        private string status = "Студент-заочник";

        public int ExamMark1
        {
            get { return examMark1; }
            set { if (value > 0 && value <= 10) { examMark1 = value; } else { examMark1 = 0; } }
        } // оценка от 1 до 10; если нет - возвращается 0
        public int ExamMark2
        {
            get { return examMark2; }
            set { if (value > 0 && value <= 10) { examMark2 = value; } else { examMark2 = 0; } }
        } // оценка от 1 до 10; если нет - возвращается 0

        public ExramuralStudent(string name, int age, int course, int examMark1, int examMark2) : base(name, age, course)
        {
            this.ExamMark1 = examMark1;
            this.ExamMark2 = examMark2;
        }
        public ExramuralStudent() : base()
        {
            Random rnd2 = new Random();

            ExamMark1 = rnd2.Next(1, 11);
            ExamMark2 = rnd2.Next(1, 11);
        }

        override public void Show()
        {
            Console.WriteLine(this.ToString());
            //Console.WriteLine($"{status}, имя: {Name}, курс: {Course} оценки за экзамены: {examMark1}, {examMark2}");
        }


        new public object Clone()
        {
            ExramuralStudent temp = new ExramuralStudent(Name, Age, Course, ExamMark1, ExamMark2);
            return temp;
        }
        new public ExramuralStudent ShallowCopy()
        {
            return (ExramuralStudent)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return obj is ExramuralStudent student &&
                   base.Equals(obj) &&
                   status == student.status &&
                   ExamMark1 == student.ExamMark1 &&
                   ExamMark2 == student.ExamMark2;
        }
        
        
        public override string ToString()
        {
            return status + ": " + Name + ", возраст:" + Age+", Курс " + Course + ", Оценки за экзамены: " + ExamMark1 + " " + ExamMark2;
        }

        public override int GetHashCode()
        {
            var hashCode = -542325170;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            hashCode = hashCode * -1521134295 + ExamMark1.GetHashCode();
            hashCode = hashCode * -1521134295 + ExamMark2.GetHashCode();
            return hashCode;
        }
    }

    
}
