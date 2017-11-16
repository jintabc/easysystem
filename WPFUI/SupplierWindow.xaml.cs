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
    /// SupplierWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SupplierWindow : Window
    {
        public SupplierWindow()
        {
            InitializeComponent();
            (tbEditZone.Items[0] as TabItem).DataContext = Supplier;
        }

        Warehouse_Supplier Supplier = new Warehouse_Supplier() { SupplierName = "1123", Contact = "asldkf", Phone = "asdfasdf" };
        Warehouse_Supplier updateSupplier = null;
        SupplierController controller = new SupplierController();
        List<Warehouse_Supplier> Suppliers = null;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (controller.AddSupplier(Supplier) > 0)
            {
                lbSuppliers.ItemsSource = null;
                lbSuppliers.ItemsSource = controller.GetSuppliers();
                lbSuppliers.ScrollIntoView(lbSuppliers.Items[lbSuppliers.Items.Count - 1]);
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(lbSuppliers, 0) as Decorator;
            ScrollViewer scrollViewer = null;
            double theOffset = 0;
            int currentIndex = lbSuppliers.SelectedIndex;
            if (border != null)
            {
                scrollViewer = border.Child as ScrollViewer;
                if (scrollViewer != null)
                {
                    theOffset = scrollViewer.VerticalOffset;
                }
            }
            if (controller.UpdateSupplier(updateSupplier) > 0)
            {
                lbSuppliers.ItemsSource = null;
                lbSuppliers.ItemsSource = controller.GetSuppliers();
                lbSuppliers.SelectedIndex = currentIndex;
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
            Suppliers = controller.GetSuppliers();
            lbSuppliers.ItemsSource = Suppliers;
            ccEdit.Content = Suppliers;
        }

        private void lbSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                tbEditZone.SelectedIndex = 1;
                updateSupplier = (e.AddedItems[0] as Warehouse_Supplier).Clone();
                (tbEditZone.Items[tbEditZone.Items.Count - 1] as TabItem).DataContext = updateSupplier;
            }
        }
    }
}
