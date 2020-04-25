using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class TestCollection
    {
        public Stack<string> collection_1String;
        public Stack<Person> collection_1TKey;

        public SortedDictionary<Person, Student> collection_2TKeyTValue;
        public SortedDictionary<string, Student> collection_2StringTValue;

        public int Length;

        public Student firstMain;
        public Student middleMain;
        public Student lastMain;

        public TestCollection(int length)
        {

            collection_1String = new Stack<string>();
            collection_1TKey = new Stack<Person>();

            collection_2StringTValue = new SortedDictionary<string, Student>();
            collection_2TKeyTValue = new SortedDictionary<Person, Student>();

            Length += length;
            Person tempKey;
            Student tempValue;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    tempValue = new Student();
                    tempKey = tempValue.BasePerson();
                } while (collection_2TKeyTValue.ContainsKey(tempKey));

                tempKey = tempValue.BasePerson();

                collection_2TKeyTValue.Add(tempKey, tempValue);
                collection_2StringTValue.Add(tempKey.ToString(), tempValue);

               
            }
            int j = 0;
            foreach (KeyValuePair<Person, Student> entry in collection_2TKeyTValue)
            {
                tempKey = entry.Key;
                tempValue = entry.Value;
                collection_1String.Push(tempKey.ToString());
                collection_1TKey.Push(tempKey);

                if (j == 0)
                {
                    firstMain = tempValue;
                }
                if (j == Length / 2)
                {
                    middleMain = tempValue;
                }
                if (j == Length - 1)
                {
                    lastMain = tempValue;
                }
                j++;
            }
             
        }
        public void Add(Student student)
        {
            Person key = student.BasePerson();
            Student value = student;

            if (!collection_2TKeyTValue.ContainsValue(value))
            {
                Length += 1;

                collection_1String.Push(key.ToString());
                collection_1TKey.Push(key);

                collection_2TKeyTValue.Add(key, value);
                collection_2StringTValue.Add(key.ToString(), value);

                Console.WriteLine("элемент успешно добавлен");
            }
            else
            {
                Console.WriteLine("Данный элемент уже существует в коллекции");
            }
        }
        public void Remove()
        {
            Person student = collection_1TKey.Peek();


            Length -= 1;

            collection_1String.Pop();
            collection_1TKey.Pop();

            collection_2TKeyTValue.Remove(student);
            collection_2StringTValue.Remove(student.ToString());


            Console.WriteLine($"Первый элемент {student} удален");

        }
    }
   
}
