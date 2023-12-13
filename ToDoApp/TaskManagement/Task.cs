using System;
using System.Windows;

namespace TaskManagement {
    /// <summary>
    ///  Класс, описывающий основную сущность логики приложения - Задачу
    /// </summary>
    public class Task {

        protected string title;
        protected string description;
        protected bool isCompleted;
        protected DateTime completeDate;

        /// <summary>
        ///  Название задачи
        /// </summary>
        public string Title { 
            get { 
                return title;
            } 
            set {
                title = value;
            } 
        }

        /// <summary>
        ///  Описание задачи
        /// </summary>
        public string Description { 
            get {
                return description; 
            }
            set {
                description = value;
            }
        }

        /// <summary>
        ///  Статус выполнения задачи
        /// </summary>
        public bool IsCompleted { 
            get {
                return isCompleted; 
            }
            set {
                isCompleted = value;
            }
        }

        /// <summary>
        ///  Дата окончания задачи
        /// </summary>
        public DateTime CompleteDate {
            get {
                return completeDate;
            }
            set {
                if (value != null) {
                    completeDate = value;
                }
            }
        }

        /// <summary>
        ///  Отформатированная дата окончания задачи в виде строки дд.мм.гггг
        /// </summary>
        public string FormatedDate {
            get {
                return completeDate.ToString("dd.MM.yyyy");
            }
        }

        /// <summary>
        ///  Переопределение стандартного метода Equals для изменения логики сравнения элементов
        ///  Задачи будут являться равными, только если их описание и название равны соотвествующим свойствам другого объекта
        /// </summary>
        public override bool Equals(Object obj) {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            } else {
                Task task = (Task) obj;
                return (title == task.title) && (description == task.description);
            }
        }

        public override int GetHashCode() {
            return (title.GetHashCode() << 2) ^ description.GetHashCode();
        }
    }
}
