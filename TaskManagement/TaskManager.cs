using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement {
    /// <summary>
    ///  Основной класс для работы со списком задач
    ///  Реализует интерфейс IListEvents и в качестве обобщенного типа использует TaskManagement.Task
    /// </summary>
    public class TaskManager : IListEvents<Task> {

        /// <summary>
        ///  Свойство, инициализируемое пустым списком из Task
        /// </summary>
        public List<Task> Items = new List<Task>();

        /// <summary>
        ///  Реализация метода интерфейса AddItem
        ///  Проверяет наличие такого же элемента в списке, если это так, испускает событие AddingTheSame
        ///  Если такого элемента еще нет, добавляет его в список и испускает событие ListChanged об изменении списка
        /// </summary>
        public void AddItem(Task task) {
            if (Items.Contains(task)) {
                OnAddingTheSame();
                return;
            } else {
                Items.Add(task);
                OnListChanged();
            }
        }

        /// <summary>
        ///  Реализация метода интерфейса RemoveItem
        ///  Проверяет наличие такого же элемента в списке, если это так, удаляет его из списка 
        ///  и испускает событие ListChanged об изменении списка
        /// </summary>
        public void RemoveItem(Task task) {
            if (Items.Contains(task)) {
                Items.Remove(task);
                OnListChanged();
            } else {
                throw new Exception("Такого элемента нет в списке");
            }
        }

        /// <summary>
        ///  Возвращает элементы списка
        /// </summary>
        public List<Task> GetItems() {
            return Items;
        }

        /// <summary>
        ///  Метод, использующийся для сортировки списка по алфавиту, испускает событие об изменении списка
        /// </summary>
        public void AlphabetSort() {
            if (Items.Count > 0) {
                Items.Sort(new AlphabetComparer());
                OnListChanged();
            }
        }

        /// <summary>
        ///  Метод, использующийся для сортировки списка по дате окончания, испускает событие об изменении списка
        /// </summary>
        public void DateSort() {
            if (Items.Count > 0) {
                Items.Sort(new DateComparer());
                OnListChanged();
            }
        }

        /// <summary>
        ///  Метод, использующийся для сортировки списка по статусу выполнения, испускает событие об изменении списка
        /// </summary>
        public void CompletedSort() {
            if (Items.Count > 0) {
                Items.Sort(new CompletedComparer());
                OnListChanged();
            }
        }

        public event EventHandler ListChanged;

        /// <summary>
        ///  Метод для создания события ListChanged
        /// </summary>
        public virtual void OnListChanged() {
            if (ListChanged != null) {
                ListChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler AddingTheSame;

        /// <summary>
        ///  Метод для создания события AddingTheSame
        /// </summary>
        public virtual void OnAddingTheSame() {
            if (AddingTheSame != null) {
                AddingTheSame(this, EventArgs.Empty);
            }
        }
    }
}
