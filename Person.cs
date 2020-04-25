using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Person :  IExecutable, IComparable, ICloneable //базовый класс
    {
        private string name;
        private int age;
        private string status = "Человек";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        } //конструктор с параметром
        public Person()
        {
            Random rnd = new Random();
            List<string> listFemaleName = new List<string>() { "Анна", "Елизавета", "Кристина", "Марина", "Вера", "Екатерина", "Елена", "Анастасия", "Юлия", "Дарья"};
            List<string> listFemaleSurname = new List<string>() { "Селина", "Воронова", "Немтинова", "Шишмакова", "Иванова", "Петрова", "Казаринова", "Белоусова" };
            List<string> listFemaleSecondName = new List<string>() { "Ивановна", "Николаевна", "Григориевна", "Дмитриевна", "Александровна", "Михаиловна", "Андреевна", "Алеексеевна", "Вячеславовна", "Викториевна" };

            List<string> listMaleName = new List<string>() { "Иван", "Николай", "Григорий", "Артур", "Савелий", "Михаил", "Дмитрий", "Алексей", "Вячеслав", "Виктор", "Василий", "Федор", "Олег", "Александр", "Демид", "Игорь", "Арсений", "Глеб" };
            List<string> listMaleSurname = new List<string>() { "Селин", "Воронов", "Немтинов", "Шишмаков", "Иванов", "Петров", "Казаринов", "Белоусов" };
            List<string> listMaleSecondName = new List<string>() { "Иванович", "Николаевич", "Григорьевич", "Дмитриевич", "Александрович", "Михаилович", "Алексеевич", "Андреевич", "Вячеславович", "Викторович" };

            if (new Random().Next(2) == 0)
            {
                rnd = new Random();
                this.Name = listFemaleSurname[rnd.Next(0, listFemaleSurname.Count)] + " " + listFemaleName[rnd.Next(0, listFemaleName.Count)] + " " + listFemaleSecondName[rnd.Next(0, listFemaleName.Count)];
            }
            else
            {
                this.Name = listMaleSurname[rnd.Next(0, listMaleSurname.Count)] + " " + listMaleName[rnd.Next(0, listFemaleName.Count)] + " " + listMaleSecondName[rnd.Next(0, listFemaleName.Count)];
            }

            this.Age = rnd.Next(0,100);
            
        } //конструктор без параметра

        virtual public void Show()
        {
            Console.WriteLine(this.ToString());
            //Console.WriteLine($"{status}, имя: {name}");
        }

        public int CompareTo(object obj)
        {
            int i = 0;
            Person p = obj as Person;

            do
            {
                if (this.name[i] > p.name[i])
                {
                    return 1;
                }
                else if (this.name[i] < p.name[i])
                {
                    return -1;
                }
                else
                { i++; }
            } while (i < Math.Min(this.name.Length, p.name.Length));
            return 0;
        }

        public object Clone()
        {
            Person temp = new Person(Name, Age);
            return temp;
        }
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        override public bool Equals(object ob)
        {
            if (name == ((Person)ob).Name && status == ((Person)ob).Status) return true;
            else return false;
        }
        override public string ToString()
        {
            return name + ", возраст:" + Age;
        }

        public override int GetHashCode()
        {
            var hashCode = 545283077;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}
