using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement {
    /// <summary>
    ///  Интерфейс, реализующий интерфейс IListItemManager<TasK>
    ///  Служит для описания событий, связанных со списком
    /// </summary>
    public interface IListEvents<T> : IListItemManager<T> {

        //Событие, испускаемое при изменении списка
        event EventHandler ListChanged;

        //Событие, испускаемое при добавлении в список уже существующего элемента
        event EventHandler AddingTheSame;
    }
}
