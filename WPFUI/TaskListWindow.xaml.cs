using EasySystem.Core.Controller;
using EasySystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasySystem.WPFUI
{
    /// <summary>
    /// TaskListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TaskListWindow : Window
    {
        TaskController controller = new TaskController();

        public TaskListWindow()
        {
            InitializeComponent();
            lstTasks.ItemsSource = controller.GetTaskListModel();
        }

        private void lstTasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lstTasks.SelectedItem != null)
            {
                Business_TaskListModel model = (Business_TaskListModel)lstTasks.SelectedItem;
                TaskDetailsWindow window = new TaskDetailsWindow(model.TaskID);
                window.Show();
            }
        }

        private void miAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskDetailsWindow window = new TaskDetailsWindow();
            window.Show();
        }
    }
}
