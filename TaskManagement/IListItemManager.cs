using System.Collections.Generic;

namespace TaskManagement {

    /// <summary>
    ///  Обобщенный интерфейс, описывающий методы и свойство для работы со списком
    /// </summary>
    public interface IListItemManager<T> {

        //Метод добавления в список элемента обобщенного типа
        void AddItem(T task);
        //Метод удаления из списка элемента обобщенного типа
        void RemoveItem(T task);
        //Метод, возвращающий все элементы списка обобщенного типа
        List<T> GetItems();
    }
}
