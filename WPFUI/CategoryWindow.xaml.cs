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
    /// CategoryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
            (tbEditZone.Items[0] as TabItem).DataContext = category;
        }

        Warehouse_Category category = new Warehouse_Category() { CategoryName = "1123", ParentID=-1 };
        Warehouse_Category updateCategory = null;
        CategoryController controller = new CategoryController();
        List<Warehouse_Category> categories = null;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (controller.AddCategory(category) > 0)
            {
                lbCategories.ItemsSource = null;
                lbCategories.ItemsSource = controller.GetCategories();
                lbCategories.ScrollIntoView(lbCategories.Items[lbCategories.Items.Count - 1]);
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(lbCategories, 0) as Decorator;
            ScrollViewer scrollViewer = null;
            double theOffset = 0;
            int currentIndex = lbCategories.SelectedIndex;
            if (border != null)
            {
                scrollViewer = border.Child as ScrollViewer;
                if (scrollViewer != null)
                {
                    theOffset = scrollViewer.VerticalOffset;
                }
            }
            if (controller.UpdateCategory(updateCategory) > 0)
            {
                lbCategories.ItemsSource = null;
                lbCategories.ItemsSource = controller.GetCategories();
                lbCategories.SelectedIndex = currentIndex;
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
            categories = controller.GetCategories();
            lbCategories.ItemsSource = categories;
            ccEdit.Content = categories;
            Grid i = VisualTreeHelper.GetChild(ccAdd, 0) as Grid;
            ComboBox cb = i.Children[i.Children.Count - 1] as ComboBox;
            cb.ItemsSource = categories;
            //i = VisualTreeHelper.GetChild(ccEdit, 0) as Grid;
            //cb = i.Children[i.Children.Count - 1] as ComboBox;
            //cb.ItemsSource = categories;
        }

        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                tbEditZone.SelectedIndex = 1;
                updateCategory = (e.AddedItems[0] as Warehouse_Category).Clone();
                (tbEditZone.Items[tbEditZone.Items.Count - 1] as TabItem).DataContext = updateCategory;
            }
        }
    }
}
