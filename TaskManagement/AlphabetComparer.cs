using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement {

    /// <summary>
    ///  Класс, реализующий интерфейс IComparer<TasK>
    ///  Служит для сравнения двух элементов Task по свойству Title (в алфавитном порядке)
    /// </summary>
    public class AlphabetComparer : IComparer<Task> {
        // Реализация метода интерфейса, использует стандартный метод string.CompareTo(string strB) 
        public int Compare(Task x, Task y) {
            return x.Title.CompareTo(y.Title);
        }
    }
}
