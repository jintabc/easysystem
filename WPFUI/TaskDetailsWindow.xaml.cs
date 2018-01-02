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
    /// TaskDetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TaskDetailsWindow : Window
    {
        TaskController controller = new TaskController();
        Business_Task task = null;
        public TaskDetailsWindow(int taskId)
        {
            InitializeComponent();
            task = controller.GetTask(taskId);
            this.DataContext = task;
        }

        private void miGenerateStampSheet_Click(object sender, RoutedEventArgs e)
        {
            StampSheetWindow window = new StampSheetWindow(task);
            window.ShowDialog();
        }
    }
}
