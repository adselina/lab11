using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class PersonArray : IEnumerable
    {
        Person[] arr;
        int size;
        int count;
        public PersonArray(int size = 0)
        {
            this.size = size;
            arr = new Person[size];
            count = 0;
        }
        public void AddFraction(Person f)
        {
            if (count < size)
            {
                arr[count] = f;
                count++;
            }
            else return;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++) yield return arr[i];
        }
    }

}
