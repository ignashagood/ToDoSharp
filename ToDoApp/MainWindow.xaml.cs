using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using TaskManagement;
using Task = TaskManagement.Task;

namespace ToDoApp {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        //Создание экземпляра класса для работы со списком
        TaskManager taskManager = new TaskManager();

        public MainWindow() {
            //Создание обработчика события ListChanged
            EventHandler listChanged = new EventHandler(taskManager_ListChanged);
            //Создание обработчика события AddingTheSame
            EventHandler addingTheSame = new EventHandler(taskManager_AddingTheSame);
            //Добавление обработчика события ListChanged
            taskManager.ListChanged += listChanged;
            //Добавление обработчика события AddingTheSame
            taskManager.AddingTheSame += addingTheSame;
            InitializeComponent();  
        }

        /// <summary>
        /// Обработчик клика на кнопку добавления задачи
        /// Считывает значения из полей ввода интерфейса
        /// Если поле для ввода названия пусто, бросает исключение
        /// Если поле для ввода даты пусто, устанавливает сегодняшнюю дату
        /// Затем использует метод TaskManager.AddItem для добавления задачи в список
        /// По умолчанию задача не является выполненной
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            try {
                if (titleInput.Text == "") {
                    throw new Exception("Название задачи не может быть пустым");
                } else {
                    DateTime date;
                    if (dateInput.SelectedDate != null) {
                        date = dateInput.SelectedDate.Value;
                    } else {
                        date = DateTime.Today;
                    }
                    taskManager.AddItem(new Task() { Title = titleInput.Text, Description = descInput.Text, IsCompleted = false, CompleteDate = date } );
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик клика на кнопку добавления задачи из файла
        /// Создает экземпляр стандартного класс для открытия файлов
        /// Считывает все строки файла
        /// Если файл не содержит строк, бросает исключение неверного формата файла
        /// Во второй строке может содержаться описание, по умолчанию - пусто
        /// В третьей - дата, если третьей строки нет, по умолчанию - сегодняшний день
        /// </summary>
        private void AddFromFileButton_Click(object sender, RoutedEventArgs e) {
            try {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true) {
                    string[] file = File.ReadAllLines(openFileDialog.FileName);
                    string title;
                    string description = "";
                    DateTime date = DateTime.Today;

                    if (file.Length > 0 && file[0] != null) {
                        title = file[0];
                    } else {
                        throw new FileFormatException();
                    }
                    if (file.Length > 1 && file[1] != null) {
                        description = file[1];
                    }
                    if (file.Length > 2 && file[2] != null && file[2] != "") {
                        date = DateTime.Parse(file[2]);
                    }
                    taskManager.AddItem(new Task() { Title = title, Description = description, IsCompleted = false, CompleteDate = date });

                }
            } catch (Exception ex) {
                if (ex is FormatException) {
                    MessageBox.Show("Неправильный формат даты");
                } else {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Обработчик клика на кнопку удаления задачи
        /// Использует метод TaskManager.RemoveItem с параметром - выбранной в списке ListBox.SelectedItem задачей
        /// </summary>
        private void RemoveButton_Click(object sender, RoutedEventArgs e) {
            try {
                taskManager.RemoveItem(ListBox.SelectedItem as Task);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик клика на кнопку просмотра задачи
        /// Создает и открывает новое окно TaskViewer, присваивая его элементам значения свойств выбранной задачи
        /// </summary>
        private void ViewButton_Click(object sender, RoutedEventArgs e) {
            try {
                TaskViewer viewer = new TaskViewer();
                viewer.title.Content = (ListBox.SelectedItem as Task).Title;
                viewer.desc.Text = (ListBox.SelectedItem as Task).Description;
                viewer.date.Content = (ListBox.SelectedItem as Task).FormatedDate;
                if ((ListBox.SelectedItem as Task).IsCompleted) {
                    viewer.isCompleted.Content = "Выполнена";
                } else {
                    viewer.isCompleted.Content = "Не выполнена";
                }
                viewer.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик изменения статуса выбора элемента в списке
        /// Если элемент выбран, делает видимыми кнопки для удаления и просмотра задачи
        /// </summary>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ListBox.SelectedItem != null) {
                RemoveButton.Visibility = Visibility.Visible;
                ViewButton.Visibility = Visibility.Visible;
            } else {
                RemoveButton.Visibility = Visibility.Hidden;
                ViewButton.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Обработчик события ListChanged
        /// Обновляет элементы списка элементами TaskManager.Items
        /// </summary>
        private void taskManager_ListChanged(object sender, EventArgs e) {
            ListBox.ItemsSource = null;
            ListBox.ItemsSource = taskManager.GetItems();
        }

        /// <summary>
        /// Обработчик события AddingTheSame
        /// Показывает соответствующее сообщение
        /// </summary>
        private void taskManager_AddingTheSame(object sender, EventArgs e) {
            MessageBox.Show("Такой элемент уже есть в списке");
        }

        /// <summary>
        /// Обработчик изменения выбора Combobox для сортировки
        /// Применяет сортировку по алвафиту, дате и статусу выполнения соотвественно индексу выбора
        /// </summary>
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            switch (ComboBox.SelectedIndex) {
                case 0:
                    taskManager.AlphabetSort();
                    break;

                case 1:
                    taskManager.DateSort();
                    break;

                case 2:
                    taskManager.CompletedSort();
                    break;
            }
        }
    }
}
