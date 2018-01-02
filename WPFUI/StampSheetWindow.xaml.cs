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
    /// StampSheetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StampSheetWindow : Window
    {
        Business_StampSheet stampSheet = null;
        DepartmentController dptController = new DepartmentController();

        public StampSheetWindow(Business_Task task)
        {
            InitializeComponent();
            cboDepartments.ItemsSource = dptController.GetDepartments();
            this.stampSheet = new Business_StampSheet()
            {
                Project = task.Project,
                Department = task.Department,
                StampDate = DateTime.Now
            };
            this.stampSheet.Items = new List<Business_StampSheetItem>();

            foreach(Business_TaskItem item in task.Items)
            {
                this.stampSheet.Items.Add(new Business_StampSheetItem(item));
            }
            this.DataContext = stampSheet;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            
        }
    }
}
