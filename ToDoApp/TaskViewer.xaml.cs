using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task = TaskManagement.Task;

namespace ToDoApp {
    /// <summary>
    /// Логика взаимодействия для TaskViewer.xaml
    /// Окно для просмотра задачи
    /// </summary>
    public partial class TaskViewer : Window {

        public TaskViewer() {
            InitializeComponent();
        }
    }
}
