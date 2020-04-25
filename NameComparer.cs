using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class NameComparer: IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            int i = 0;
            Person p1 = ob1 as Person;
            Person p2 = ob2 as Person;

            do
            {
                if (p1.Name[i] > p2.Name[i])
                {
                    return 1;
                }
                else if (p1.Name[i] < p2.Name[i])
                {
                    return -1;
                }
                else
                { i++; }
            } while (i < Math.Min(p1.Name.Length, p2.Name.Length));
            return 0;
        }
    }
}
