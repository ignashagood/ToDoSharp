using System;
using System.Windows;

namespace TaskManagement {
    /// <summary>
    ///  �����, ����������� �������� �������� ������ ���������� - ������
    /// </summary>
    public class Task {

        protected string title;
        protected string description;
        protected bool isCompleted;
        protected DateTime completeDate;

        /// <summary>
        ///  �������� ������
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
        ///  �������� ������
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
        ///  ������ ���������� ������
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
        ///  ���� ��������� ������
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
        ///  ����������������� ���� ��������� ������ � ���� ������ ��.��.����
        /// </summary>
        public string FormatedDate {
            get {
                return completeDate.ToString("dd.MM.yyyy");
            }
        }

        /// <summary>
        ///  ��������������� ������������ ������ Equals ��� ��������� ������ ��������� ���������
        ///  ������ ����� �������� �������, ������ ���� �� �������� � �������� ����� �������������� ��������� ������� �������
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
