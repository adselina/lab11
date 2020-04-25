using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class MarkComparer : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            ExramuralStudent ex1 = (ExramuralStudent)ob1;
            ExramuralStudent ex2 = (ExramuralStudent)ob2;

            if ((ex1.ExamMark2 + ex1.ExamMark1) / 2 > (ex2.ExamMark2 + ex2.ExamMark1) / 2)
            {
                return -1;
            }
            else if ((ex1.ExamMark2 + ex1.ExamMark1) / 2 < (ex2.ExamMark2 + ex2.ExamMark1) / 2)
            {
                return 1;
            }
            else
                return 0;
        }
    }  //реализация интерфейса для сортировки
}
