using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement {

    /// <summary>
    ///  Класс, реализующий интерфейс IComparer<TasK>
    ///  Служит для сравнения двух элементов Task по свойству IsCompleted
    /// </summary>
    public class CompletedComparer : IComparer<Task> {
        //Реализация метода интерфейса, использует стандартный метод bool.CompareTo(bool value) 
        public int Compare(Task x, Task y) {
            return (x.IsCompleted.CompareTo(y.IsCompleted));
        }
    }
}
