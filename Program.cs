using System;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary;
using System.Diagnostics;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoise = 1;
            while (menuChoise != 0)
            {
                menuChoise = MainMenuChoise();
                Console.Clear();
                switch (menuChoise)
                {
                    case 1:
                        Collection1();
                        break;
                    case 2:
                        Collection2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        break;

                }
            }

        }

        #region(Task_1 SortedList)
        private static void Collection1()
        {
            Console.WriteLine("Данная программа создаёт и выводит на печать первоначальное количество объектов заданного типа " +
                  "\nи содержит ряд функций для работы с этими объектами");
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            int numberOfExStudent = ReadNumber(0, 2000, "Введите начальное количество студентов-заочников: ");
            int numberOfStudent = ReadNumber(0, 2000, "Введите начальное количество студентов: ");
            int numberOfSchooler = ReadNumber(0, 2000, "Введите начальное количество школьников: ");
            SortedList sortedList1 = Generator.CreateCollectionFirstTask(numberOfExStudent, numberOfStudent, numberOfSchooler);
            PrintAllInformation(sortedList1);

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            int menuChoise = 1;
            while (menuChoise != 0)
            {
                menuChoise = Task12_menu();
                switch (menuChoise)
                {
                    //_____ДОБАВЛЕНИЕ_____//
                    case 1:
                        switch (ObjectMenu())
                        {
                            case 1:
                                int keyAddObject = NewKey(sortedList1);
                                ExramuralStudent exSt = new ExramuralStudent();

                                sortedList1.Add(keyAddObject, exSt);
                                Console.WriteLine($"Элемент: {exSt}, успешно добавлен");
                                break;
                            case 2:
                                keyAddObject = NewKey(sortedList1);
                                Student st = new Student();
                                sortedList1.Add(keyAddObject, st);
                                Console.WriteLine($"Элемент: {st}, успешно добавлен");
                                break;
                            case 3:
                                keyAddObject = NewKey(sortedList1);
                                Schooler sc = new Schooler();
                                sortedList1.Add(keyAddObject, sc);
                                Console.WriteLine($"Элемент: {sc}, успешно добавлен");
                                break;
                        }
                        break;

                    //_____УДАЛЕНИЕ_____//
                    case 2:
                        int removeObject = ReadNumber(-1, 100000, "Введите ключ объекта для удаления: ");
                        if (sortedList1.ContainsKey(removeObject))
                        {
                            Person p = (Person)sortedList1[removeObject];
                            
                            sortedList1.Remove(removeObject);
                            Console.WriteLine($"Элемент {p} успешно удален");
                        }
                        else
                        {
                            Console.WriteLine("Элемента с таким ключем не существует");
                        }

                        break;

                    //_____ПОДСЧЕТ_____//
                    case 3:

                        int count = 0;

                        foreach (Person item in sortedList1.Values)
                        {
                            ExramuralStudent student = item as ExramuralStudent;
                            if (student is ExramuralStudent)
                            {
                                count += 1;
                            }
                        }
                        Console.WriteLine("\nКоличество студентов-заочников: " + count);

                        count = 0;
                        foreach (Person item in sortedList1.Values)
                        {
                            Student student = item as Student;
                            if (student is Student && !(student is ExramuralStudent))
                            {
                                count += 1;
                            }
                        }
                        Console.WriteLine("\nКоличество студентов: " + count);

                        count = 0;
                        foreach (Person item in sortedList1.Values)
                        {
                            Schooler schooler = item as Schooler;
                            if (schooler is Schooler)
                            {
                                count += 1;
                            }
                        }
                        Console.WriteLine("\nКоличество школьников: " + count);
                        break;

                    //_____ПЕЧАТЬ РАЗНЫХ ТИПОВ КОЛЛЕКЦИИ_____//
                    case 4:
                        bool persons = false;


                        Console.WriteLine("1. Студент-заочник" +
                            "\n2. Студент" +
                            "\n3. Школьник" +
                            "\n4. Печать всей коллекции");

                        int choice = ReadNumber(0, 5, "Выберите тип объекта: ");

                        switch (choice)
                        {
                            case 1:
                                foreach (Person item in sortedList1.Values)
                                {
                                    ExramuralStudent exStudent = item as ExramuralStudent;
                                    if (exStudent is ExramuralStudent)
                                    {
                                        exStudent.Show();
                                        persons = true;
                                    }
                                }
                                if (!persons)
                                {
                                    Console.WriteLine("Студентов заочников в коллекции нет");
                                }
                                break;

                            case 2:
                                foreach (Person item in sortedList1.Values)
                                {
                                    Student student = item as Student;
                                    if (student is Student && !(student is ExramuralStudent))
                                    {
                                        student.Show();
                                        persons = true;
                                    }
                                }
                                if (!persons)
                                {
                                    Console.WriteLine("Студентов в коллекции нет");
                                }
                                break;

                            case 3:
                                foreach (Person item in sortedList1.Values)
                                {
                                    Schooler schooler = item as Schooler;
                                    if (schooler is Schooler)
                                    {
                                        schooler.Show();
                                        persons = true;
                                    }

                                }
                                if (!persons)
                                {
                                    Console.WriteLine("Школьников в коллекции нет");
                                }
                                break;
                            case 4:
                                PrintAllInformation(sortedList1);
                                break;
                        }

                        break;

                    //_____ПОДСЧЕТ СРЕДНЕЙ ОЦЕНКИ У СТУДЕНТОВ-ЗАОЧНИКОВ_____//
                    case 5:
                        ArrayList removeKeyList = new ArrayList();
                        foreach (Person item in sortedList1.Values)
                        {
                            ExramuralStudent student = item as ExramuralStudent;
                            if (student is ExramuralStudent && student.ExamMark1 <= 3 && student.ExamMark2 <= 3)
                            {
                                removeKeyList.Add(item);
                            }
                        }
                        if (removeKeyList.Count == 0)
                        {
                            Console.WriteLine("Никто не отчислен");
                        }
                        else
                        {
                            for (int i = 0; i < removeKeyList.Count; i++)
                            {
                                sortedList1.Remove(sortedList1.IndexOfValue(removeKeyList[i]));
                            }
                            Console.WriteLine("Студенты отчислены");
                        }

                        break;

                    //_____ПОИСК_____//
                    case 6:
                        SortedList sortedList2 = Clone(sortedList1);

                        bool itemFinded = false;
                        switch (ObjectMenu())
                        {

                            case 1:

                                ExramuralStudent st1 = GetExStudent();
                                if (sortedList2.ContainsValue(st1))
                                {
                                    itemFinded = true;
                                }
                                break;

                            case 2:

                                Student st2 = GetStudent();
                                if (sortedList2.ContainsValue(st2))
                                {
                                    itemFinded = true;
                                }

                                break;

                            case 3:

                                Schooler st3 = GetSchooler();
                                if (sortedList2.ContainsValue(st3))
                                {
                                    itemFinded = true;
                                }
                                break;
                        }

                        if (itemFinded == true)
                        {
                            Console.WriteLine("Объект найден");
                        }
                        else
                        {
                            Console.WriteLine("Объект не найден");
                        }
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private static void PrintAllInformation(SortedList sortedList)
        {
            foreach (Person item in sortedList.Values)
            {
                Console.Write("Key: " + sortedList.GetKey(sortedList.IndexOfValue(item)) + "    ");
                item.Show();
            }
        }//Печать всей коллекции
        private static SortedList Clone(SortedList sortedList)
        {

            SortedList sortedList2 = new SortedList();

            foreach (Person item in sortedList.Values)
            {
                ExramuralStudent student = item as ExramuralStudent;
                if (student is ExramuralStudent)
                {
                    sortedList2.Add(sortedList.GetKey(sortedList.IndexOfValue(item)), student.Clone());
                }
            }

            foreach (Person item in sortedList.Values)
            {
                Student student = item as Student;
                if (student is Student && !(student is ExramuralStudent))
                {
                    sortedList2.Add(sortedList.GetKey(sortedList.IndexOfValue(item)), student.Clone());
                }
            }

            foreach (Person item in sortedList.Values)
            {
                Schooler schooler = item as Schooler;
                if (schooler is Schooler)
                {
                    sortedList2.Add(sortedList.GetKey(sortedList.IndexOfValue(item)), schooler.Clone());

                }
            }



            return sortedList2;
        }// клонирование коллекции


        #endregion

        #region(Task_2  SortedDictionary)
        private static void Collection2()
        {
            Console.WriteLine("Данная программа создаёт и выводит на печать первоначальное количество объектов заданного типа " +
                  "\nи содержит ряд функций для работы с этими объектами");
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            int numberOfExStudent = ReadNumber(0, 501, "Введите начальное количество студентов-заочников: ");
            int numberOfStudent = ReadNumber(0, 501, "Введите начальное количество студентов: ");
            int numberOfSchooler = ReadNumber(0, 501, "Введите начальное количество школьников: ");
            SortedDictionary<int, Person> sortedDict1 = Generator.CreateCollectionFirstTask2(numberOfExStudent, numberOfStudent, numberOfSchooler);
            PrintAllInformation(sortedDict1);

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            int menuChoise = 1;
            while (menuChoise != 0)
            {
                Console.Clear();
                menuChoise = Task12_menu();
                switch (menuChoise)
                {
                    //_____ДОБАВЛЕНИЕ_____//                                     
                    case 1:
                        switch (ObjectMenu())
                        {
                            case 1:
                                int keyAddObject = NewKey(sortedDict1);
                                sortedDict1.Add(keyAddObject, new ExramuralStudent());
                                Console.WriteLine("Элемент успешно добавлен");
                                break;
                            case 2:
                                keyAddObject = NewKey(sortedDict1);
                                sortedDict1.Add(keyAddObject, new Student());
                                Console.WriteLine("Элемент успешно добавлен");
                                break;
                            case 3:
                                keyAddObject = NewKey(sortedDict1);
                                sortedDict1.Add(keyAddObject, new Schooler());
                                Console.WriteLine("Элемент успешно добавлен");
                                break;
                        }
                        
                        
                        
                        break;

                    //_____УДАЛЕНИЕ_____//
                    case 2:
                        int removeObject = ReadNumber(-1, 100000, "Введите ключ объекта для удаления: ");
                        if (sortedDict1.ContainsKey(removeObject))//проверка на существования ключа
                        {
                            Person p = sortedDict1[removeObject];
                            sortedDict1.Remove(removeObject);
                            Console.WriteLine($"Элемент {p} успешно удален");
                        }
                        else
                        {
                            Console.WriteLine("Элемента с таким ключем не существует");
                        }

                        break;

                    //_____ПОДСЧЕТ_____//
                    case 3:
                        int stK = 0;
                        int exstK = 0;
                        int schK = 0;


                        foreach (KeyValuePair<int, Person> entry in sortedDict1)
                        {
                            if (entry.Value is Student && !(entry.Value is ExramuralStudent))
                            {
                                stK += 1;
                            }
                            else if (entry.Value is ExramuralStudent)
                            {
                                exstK += 1;
                            }
                            else if (entry.Value is Schooler)
                            {
                                schK += 1;
                            }
                        }

                        Console.WriteLine("\nКоличество студентов-заочников: " + exstK);
                        Console.WriteLine("\nКоличество студентов: " + stK);
                        Console.WriteLine("\nКоличество школьников: " + schK);
                        break;

                    //_____ПЕЧАТЬ РАЗНЫХ ТИПОВ КОЛЛЕКЦИИ_____//
                    case 4:
                        bool person = false;
                        Console.WriteLine("1. Студент-заочник" +
                            "\n2. Студент" +
                            "\n3. Школьник" +
                            "\n4. Печать всей коллекции");

                        int choice = ReadNumber(0, 5, "Выберите тип объекта: ");
                        switch (choice)
                        {
                            case 1:
                                foreach (KeyValuePair<int, Person> entry in sortedDict1)
                                {
                                    if (entry.Value is ExramuralStudent)
                                    {
                                        entry.Value.Show();
                                        person = true;
                                    }
                                }
                                if (!person)
                                {
                                    Console.WriteLine("Студентов-заочников в коллекции нет");
                                }
                                break;
                            case 2:
                                foreach (KeyValuePair<int, Person> entry in sortedDict1)
                                {
                                    if (entry.Value is Student && !(entry.Value is ExramuralStudent))
                                    {
                                        entry.Value.Show();
                                        person = true;
                                    }
                                }
                                if (!person)
                                {
                                    Console.WriteLine("Студентов в коллекции нет");
                                }
                                break;
                            case 3:
                                foreach (KeyValuePair<int, Person> entry in sortedDict1)
                                {
                                    if (entry.Value is Schooler && choice == 3)
                                    {
                                        entry.Value.Show();
                                        person = true;
                                    }
                                }
                                if (!person)
                                {
                                    Console.WriteLine("Школьников в коллекции нет");

                                }
                                break;
                            case 4:
                                foreach (KeyValuePair<int, Person> entry in sortedDict1)
                                {
                                    entry.Value.Show();
                                    person = true;
                                }
                                if (!person)
                                {
                                    Console.WriteLine("Объектов в коллекции нет");
                                }
                                break;
                        }
                        break;


                    //_____ПОДСЧЕТ СРЕДНЕЙ ОЦЕНКИ У СТУДЕНТОВ-ЗАОЧНИКОВ_____//
                    case 5:

                        ArrayList removeKeyList = new ArrayList();
                        foreach (KeyValuePair<int, Person> entry in sortedDict1)
                        {
                            ExramuralStudent student = entry.Value as ExramuralStudent;
                            if (entry.Value is ExramuralStudent && student.ExamMark1 <= 3 && student.ExamMark2 <= 3)
                            {
                                removeKeyList.Add(entry.Key);
                            }
                        }
                        if (removeKeyList.Count == 0)
                        {
                            Console.WriteLine("\nНикто не отчислен");
                        }
                        else
                        {
                            for (int i = 0; i < removeKeyList.Count; i++)
                            {
                                sortedDict1.Remove(i);
                            }
                            Console.WriteLine("\nСтуденты отчислены");
                        }
                        break;

                    //_____ПОИСК_____//
                    case 6:

                        SortedDictionary<int, Person> sortedDict = Clone(sortedDict1);
                        bool itemFinded = false;
                        switch (ObjectMenu())
                        {

                            case 1:

                                ExramuralStudent st1 = GetExStudent();                           
                                if (sortedDict.ContainsValue(st1))
                                {
                                     itemFinded = true;
                                }
                                break;

                            case 2:

                                Student st2 = GetStudent();
                                if (sortedDict.ContainsValue(st2))
                                {
                                    itemFinded = true;
                                }
                                
                                break;

                            case 3:

                                Schooler st3 = GetSchooler();
                                if (sortedDict.ContainsValue(st3))
                                {
                                    itemFinded = true;
                                }
                                break;
                        }

                        if (itemFinded == true)
                        {
                            Console.WriteLine("Объект найден");
                        }
                        else
                        {
                            Console.WriteLine("Объект не найден");
                        }
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        private static SortedDictionary<int, Person> Clone(SortedDictionary<int, Person> sortedDict)
        {

            SortedDictionary<int, Person> sortedDict1 = new SortedDictionary<int, Person>();

            foreach (KeyValuePair<int, Person> entry in sortedDict)
            {
                sortedDict1.Add(entry.Key, entry.Value);
            }

            return sortedDict1;
        }// клонирование коллекции
        private static void PrintAllInformation(SortedDictionary<int, Person> sortedDict)
        {
            foreach (KeyValuePair<int, Person> entry in sortedDict)
            {
                Console.Write("Key: " + entry.Key + "              ");
                entry.Value.Show();
            }
        }//Печать всей коллекции
        #endregion

        #region (Task_3)
        private static void Task3()
        {
           
            int size = 1300;
            

            int menuChoise = 1;
            while (menuChoise != 0)
            {
                TestCollection testCollection = new TestCollection(size);

                Student first = null;
                Student middle = null;
                Student last = null;
                Student notExist = new Student("test", 18, 1);

                //_____переход от ссылки к элементу_____//   
                first = (Student)testCollection.firstMain.Clone();
                middle = (Student)testCollection.middleMain.Clone();
                last = (Student)testCollection.lastMain.Clone();

                menuChoise = Task3_menu();
                Console.Clear();
                switch (menuChoise)
                {
                    case 1:
                        testCollection.Add(GetStudent());
                        break;

                    case 2:
                        testCollection.Remove();
                        break;

                    case 3:

                        

                        //_____Измерение времени на поиск_____//   
                        SearchAndTime(testCollection.collection_1String, first.BasePerson().ToString(), middle.BasePerson().ToString(),
                                                                        last.BasePerson().ToString(), notExist.BasePerson().ToString());
                        SearchAndTime(testCollection.collection_1TKey, first, middle, last, notExist);

                        SearchAndTime(testCollection.collection_2TKeyTValue, first.BasePerson(), middle.BasePerson(), last.BasePerson(), notExist.BasePerson());
                        SearchAndTime(testCollection.collection_2StringTValue, first.BasePerson().ToString(), middle.BasePerson().ToString(),
                                                                              last.BasePerson().ToString(), notExist.BasePerson().ToString());

                        SearchAndTime(testCollection.collection_2TKeyTValue, first, middle, last, notExist);
                        SearchAndTime(testCollection.collection_2StringTValue, first, middle, last, notExist);
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        
        //________Stack (Contains)________//
        private static void SearchAndTime(Stack<string> collect1, string first, string middle, string last, string notExist) 
        {
            Stopwatch stopPLEASE = new Stopwatch();
            Console.WriteLine("Stack<string>  (Contains)");

            bool containes = false;

            
            stopPLEASE.Start();
            containes = collect1.Contains(first);
            stopPLEASE.Stop();
            
            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed, 10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed, 10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(last);
            stopPLEASE.Stop();

           
            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed, 10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(notExist);
            stopPLEASE.Stop();
            if (containes)
            {
                
                Console.WriteLine($"Неопознанный объект: найден за    {stopPLEASE.Elapsed,10}   |   ({notExist})");
                
            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed, 10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");

        }                         
        private static void SearchAndTime(Stack<Person> collect1, Student first, Student middle, Student last, Student notExist)
        {
            Stopwatch stopPLEASE = new Stopwatch();
            Console.WriteLine("Stack<Person>  (Contains)");

            bool containes = false;


            stopPLEASE.Start();
            containes = collect1.Contains(first);
            stopPLEASE.Stop();

            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed,10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed,10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(last);
            stopPLEASE.Stop();


            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed,10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.Contains(notExist);
            stopPLEASE.Stop();
            if (containes)
            {

                Console.WriteLine($"Неопознанный объект: {notExist}, найден за {stopPLEASE.Elapsed}");

            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed,10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");
        }

        //________SortedDictionary (ContainsKey)________//
        private static void SearchAndTime(SortedDictionary<Person,Student> collect1, Person first, Person middle, Person last, Person notExist)
        {
            Console.WriteLine("SortedDictionary < Person, Student >  (ContainsKey) ");

            Stopwatch stopPLEASE = new Stopwatch();
            bool containes = false;


            stopPLEASE.Start();
            containes = collect1.ContainsKey(first);
            stopPLEASE.Stop();

            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed,10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed,10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(last);
            stopPLEASE.Stop();


            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed,10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(notExist);
            stopPLEASE.Stop();
            if (containes)
            {

                Console.WriteLine($"Неопознанный объект: {notExist}, найден за {stopPLEASE.Elapsed}");

            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed,10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");
        }       
        private static void SearchAndTime(SortedDictionary<string, Student> collect1, string first, string middle, string last, string notExist)
        {
            Console.WriteLine("SortedDictionary < string, Student >  (ContainsKey)");
            Stopwatch stopPLEASE = new Stopwatch();
            bool containes = false;


            stopPLEASE.Start();
            containes = collect1.ContainsKey(first);
            stopPLEASE.Stop();

            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed,10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed,10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(last);
            stopPLEASE.Stop();


            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed,10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsKey(notExist);
            stopPLEASE.Stop();
            if (containes)
            {

                Console.WriteLine($"Неопознанный объект: {notExist}, найден за {stopPLEASE.Elapsed}");

            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed,10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");
        }


        //________SortedDictionary (ContainsValue)________//
        private static void SearchAndTime(SortedDictionary<Person, Student> collect1, Student first, Student middle, Student last, Student notExist)
        {
            Console.WriteLine("SortedDictionary < Person, Student >  (ContainsValue)");

            Stopwatch stopPLEASE = new Stopwatch();
            bool containes = false;


            stopPLEASE.Start();
            containes = collect1.ContainsValue(first);
            stopPLEASE.Stop();

            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed,10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed,10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(last);
            stopPLEASE.Stop();


            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed,10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(notExist);
            stopPLEASE.Stop();
            if (containes)
            {

                Console.WriteLine($"Неопознанный объект: {notExist}, найден за {stopPLEASE.Elapsed}");

            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed,10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");
        }  
        private static void SearchAndTime(SortedDictionary<string, Student> collect1, Student first, Student middle, Student last, Student notExist)
        {
            Console.WriteLine("SortedDictionary < string, Student >  (ContainsValue)");


            Stopwatch stopPLEASE = new Stopwatch();
            bool containes = false;


            stopPLEASE.Start();
            containes = collect1.ContainsValue(first);
            stopPLEASE.Stop();

            if (containes)
            {
                Console.WriteLine($"Первый объект:       найден за    {stopPLEASE.Elapsed,10}   |   ({first})");
            }
            else Console.WriteLine($"{first} не найден");


            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(middle);
            stopPLEASE.Stop();
            if (containes)
            {
                Console.WriteLine($"Центальный объект:   найден за    {stopPLEASE.Elapsed,10}   |   ({middle}) ");
            }
            else Console.WriteLine($"{middle} не найден");



            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(last);
            stopPLEASE.Stop();


            if (containes)
            {
                Console.WriteLine($"Последний объект:    найден за    {stopPLEASE.Elapsed,10}   |   ({last})");
            }
            else Console.WriteLine($"{last} не найден");

            stopPLEASE = new Stopwatch();
            stopPLEASE.Start();
            containes = collect1.ContainsValue(notExist);
            stopPLEASE.Stop();
            if (containes)
            {

                Console.WriteLine($"Неопознанный объект: {notExist}, найден за {stopPLEASE.Elapsed}");

            }
            else Console.WriteLine($"Неопознанный объект: НЕ найден за {stopPLEASE.Elapsed,10}   |   ({notExist})");

            Console.WriteLine("------------------------------------------------------");
        } 

        
        
        

        #endregion

        #region(Дополнительные функции)
        private static int NewKey(SortedDictionary<int,Person> collection)
        {
            int key = ReadNumber(-1, 100000, "Введите ключ для добавляемого объекта: ");
            while (collection.ContainsKey(key))//проверка на существования ключа
            {
                Console.WriteLine("Элемент с таким ключем уже существует");
                key = ReadNumber(-1, 100000, "Введите ключ для добавляемого объекта: ");
            }
            return key;
        }  //создание уникально ключа
        private static int NewKey(SortedList collection)
        {
            int key = ReadNumber(-1, 100000, "Введите ключ для добавляемого объекта: ");
            while (collection.ContainsKey(key))//проверка на существования ключа
            {
                Console.WriteLine("Элемент с таким ключем уже существует");
                key = ReadNumber(-1, 100000, "Введите ключ для добавляемого объекта: ");
            }
            return key;
        }                    //создание уникально ключа

        private static int MainMenuChoise() 
            {
                Console.WriteLine(
                    "1. Обычная коллекция (SortedList)" +
                    "\n2. Обощенная коллекция (SortedDictionary)" +
                    "\n3. Задание 3" +
                    "\n0. Выход");

                int menuChoise = ReadNumber(-1, 4, "Введите номер меню: ");
                return menuChoise;
        }           //печать меню
        private static int Task3_menu()
        {
            Console.WriteLine(
                "1. Добавление элемента" +
                "\n2. Удаление" +
                "\n3. Измерение времени" +
                "\n0. Выход");

            int menuChoise = ReadNumber(-1, 4, "Введите номер меню: ");
            return menuChoise;
        }                //печать меню
        private static int Task12_menu() 
            {
                Console.WriteLine(
                    "1. Добавление элемента" +
                    "\n2. Удаление элемента" +
                    "\n3. Вывод количества объектов" +
                    "\n4. Печать определенных типов объектов" +
                    "\n5. Отчисление студентов-заочников с плохими оценками" +
                    "\n6. Поиск" +
                    "\n0. Выход");
                int menuChoise = ReadNumber(-1, 7, "Введите номер меню: ");
                return menuChoise;
        }               //печать меню
        private static int ObjectMenu() 
        {
            Console.WriteLine("1. Студент-заочник" +
                                "\n2. Студент" +
                                "\n3. Школьник");

            int choise = ReadNumber(0, 4, "Выберите тип объекта: ");
            return choise;
        }               //печать выбора типа объекта

        private static int ReadNumber(int left, int right, string label)
        {
            int result = 0;
            bool flag = true;
            Console.Write(label);
            do
            {

                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left + 1 || result > right - 1)

                    Console.WriteLine($"Неверный ввод. Введите целое число от {left + 1} до {right - 1}");

            } while (!flag || result < left + 1 || result > right - 1);

            return result;

        }   //границы ввода


        //______Ручной ввод объекта______//
        private static ExramuralStudent GetExStudent()
        {
            Console.Write("Введите имя: ");
            string nameToFind = Console.ReadLine();
            int course = ReadNumber(0, 5, "Введите курс: ");
            int age = ReadNumber(0, 100, "Введите возраст: ");
            int ex1 = ReadNumber(0, 11, "Введите оценку за первый экзамен: ");
            int ex2 = ReadNumber(0, 11, "Введите оценку за второй экзамен: ");

            ExramuralStudent st = new ExramuralStudent(nameToFind, age, course, ex1, ex2);
            return st;
        }
        private static Student GetStudent()
        {
            int age = ReadNumber(0, 100, "Введите возраст: ");
            Console.WriteLine("Введите имя: ");
            string nameToFind = Console.ReadLine();
            int course = ReadNumber(0, 5, "Введите курс: ");
            

            Student st = new Student(nameToFind, age, course);
            return st;
        }
        private static Schooler GetSchooler()
        {
            Console.Write("Введите имя: ");
            string nameToFind = Console.ReadLine();
            int age = ReadNumber(0, 100, "Введите возраст: ");
            int sclass = ReadNumber(0, 12, "Введите класс: ");
           

            Schooler st = new Schooler(nameToFind, age, sclass);
            return st;
        } 
        #endregion
    }
}

