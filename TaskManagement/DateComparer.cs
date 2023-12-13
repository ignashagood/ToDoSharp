using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement {
    /// <summary>
    ///  Класс, реализующий интерфейс IComparer<TasK>
    ///  Служит для сравнения двух элементов Task по свойству CompleteDate
    /// </summary>
    public class DateComparer : IComparer<Task> {
        public int Compare(Task x, Task y) {
            // Реализация метода интерфейса, использует стандартный метод DateTime.CompareTo(DateTime value) 
            return x.CompleteDate.CompareTo(y.CompleteDate);
        }
    }
}
