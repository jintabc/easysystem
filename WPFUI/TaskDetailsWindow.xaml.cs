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
using System.Globalization;

namespace EasySystem.WPFUI
{
    /// <summary>
    /// TaskDetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TaskDetailsWindow : Window
    {
        TaskController controller = new TaskController();
        DepartmentController dController = new DepartmentController();
        Business_Task task = null;
        public TaskDetailsWindow(int taskId)
        {
            InitializeComponent();
            task = controller.GetTask(taskId);
            cboDepartment.ItemsSource = dController.GetDepartments();
            gbItemInfo.DataContext = new Business_TaskItem() { Task = task };
            this.DataContext = task;
        }

        private void miGenerateStampSheet_Click(object sender, RoutedEventArgs e)
        {
            StampSheetWindow window = new StampSheetWindow(task);
            window.ShowDialog();
        }

        void dgTool_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        void dgTool_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            dgTool_LoadingRow(sender, e);
            if (dgTaskItems.Items != null)
            {
                for (int i = 0; i < dgTaskItems.Items.Count; i++)
                {
                    try
                    {
                        DataGridRow row = dgTaskItems.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                        if (row != null)
                        {
                            row.Header = (i + 1).ToString();
                        }
                    }
                    catch { }
                }
            }
        }

        private void dgTaskItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count != 0)
            {
                gbItemInfo.DataContext = ((Business_TaskItem)e.AddedItems[0]).Clone();
                gbItemInfo.Header = "编辑记录";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Business_TaskItem item = (Business_TaskItem)gbItemInfo.DataContext;
            if (item.TaskItemID == -1)
            {

            }
            else
            {

            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Business_TaskItem item = (Business_TaskItem)gbItemInfo.DataContext;
            if (item.TaskItemID != -1)
            {
                item.TaskItemID = -1;
            }
            item.Task = task;
            item.ItemName = string.Empty;
            item.Subject = string.Empty;
            item.A0 = null;
            item.A1 = null;
            item.A2 = null;
            item.A3 = null;
            item.Copies = 1;
            item.Description = string.Empty;
        }
    }

    public class BusinessTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Common_BusinessType businessType = (Common_BusinessType)value;
            if (businessType == Common_BusinessType.Outside)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool businessType = (bool)value;
            if (businessType == true)
            {
                return Common_BusinessType.Outside;
            }
            return Common_BusinessType.Inside;
        }
    }
}
