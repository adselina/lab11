using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Generator
    {
        public static Random randomizer = new Random();
        public static SortedList CreateCollectionFirstTask(int numberOfExStudent, int numberOfStudent, int numberOfSchooler)
        {
            int key = 0;
            SortedList al1 = new SortedList();
            Console.WriteLine();
            Person p = new Person();

            for (int i = 0; i < numberOfExStudent; i++)
            {
                do
                {
                    p = new ExramuralStudent();
                } while (al1.ContainsValue(p));
                al1.Add(key, p);
                key++;
            }
            Console.WriteLine();
            for (int i = 0; i < numberOfStudent; i++)
            {
                do
                {
                    p = new Student();

                } while (al1.ContainsValue(p));

                al1.Add(key, p);
                key++;
            }
            Console.WriteLine();
            for (int i = 0; i < numberOfSchooler; i++)
            {
                do
                {
                    p = new Schooler();
                } while (al1.ContainsValue(p));
                al1.Add(key, p);
                key++;
            }
            Console.WriteLine();

            return al1;
        }
        public static SortedDictionary<int, Person> CreateCollectionFirstTask2(int numberOfExStudent, int numberOfStudent, int numberOfSchooler)
        {
            int key = 0;
            SortedDictionary<int, Person> sd1 = new SortedDictionary<int, Person>();
            Console.WriteLine();
            Person p = new Person();
            for (int i = 0; i < numberOfExStudent; i++)
            {
                do
                {
                    p = new ExramuralStudent();
                } while (sd1.ContainsValue(p));
                sd1.Add(key, p);
                key++;
            }
            Console.WriteLine();
            for (int i = numberOfExStudent; i < numberOfStudent + numberOfExStudent; i++)
            {
                do
                {
                    p = new Student();
                } while (sd1.ContainsValue(p));
                sd1.Add(key, p);
                key++;
            }
            Console.WriteLine();
            for (int i = numberOfStudent + numberOfExStudent; i < numberOfSchooler + numberOfStudent + numberOfExStudent; i++)
            {
                do
                {
                    p = new Schooler();
                } while (sd1.ContainsValue(p));
                sd1.Add(key, p);
                key++;
            }
            Console.WriteLine();

            Console.WriteLine("Созданно объектов: " + sd1.Count);
            return sd1;
        }
    }
}
