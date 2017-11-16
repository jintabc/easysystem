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
using EasySystem.Core.Controller;
using EasySystem.Core.Entity;
namespace EasySystem.WPFUI
{
    /// <summary>
    /// ProjectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();
            (tbEditZone.Items[0] as TabItem).DataContext = project;
        }

        Business_Project project = new Business_Project() { DesignNo = "1123", ProjectName = "asldkf", Company = "asdfasdf", ProjectLeader = "asdf" };
        Business_Project updateProject = null;
        ProjectController controller = new ProjectController();
        List<Business_Project> projects = null;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(controller.AddProject(project) > 0)
            {
                lbProjects.ItemsSource = null;
                lbProjects.ItemsSource = controller.GetProjects();
                lbProjects.ScrollIntoView(lbProjects.Items[lbProjects.Items.Count - 1]);
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(lbProjects, 0) as Decorator;
            ScrollViewer scrollViewer = null;
            double theOffset = 0;
            int currentIndex = lbProjects.SelectedIndex;
            if (border != null)
            {
                scrollViewer = border.Child as ScrollViewer;
                if (scrollViewer != null)
                {
                    theOffset = scrollViewer.VerticalOffset;
                }
            }
            if (controller.UpdateProject(updateProject)>0)
            {
                lbProjects.ItemsSource = null;
                lbProjects.ItemsSource = controller.GetProjects();
                lbProjects.SelectedIndex = currentIndex;
                scrollViewer.ScrollToVerticalOffset(theOffset);
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            projects = controller.GetProjects(); 
            lbProjects.ItemsSource = projects;
            ccEdit.Content = projects;
        }

        private void lbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                tbEditZone.SelectedIndex = 1;
                updateProject = (e.AddedItems[0] as Business_Project).Clone();
                (tbEditZone.Items[tbEditZone.Items.Count - 1] as TabItem).DataContext = updateProject;
            }
        }
    }
}
