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
    /// InventoryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public InventoryWindow()
        {
            InitializeComponent();
        }

        InventoryController controller = new InventoryController();
        List<Warehouse_Inventory> inventoryList = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            inventoryList = controller.GetInventoryList();
            lstInventory.ItemsSource = inventoryList;
        }

        private void ListviewItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstInventory.SelectedItem == null)
            {
                return;
            }
            int currentIndex = lstInventory.SelectedIndex;
            Warehouse_Inventory inventory = lstInventory.SelectedItem as Warehouse_Inventory;
            InventoryInfoWindow window = new InventoryInfoWindow(inventory);
            window.Owner = this;
            bool? result = window.ShowDialog().Value;
            if (result.HasValue && result == true)
            {
                Decorator border = VisualTreeHelper.GetChild(lstInventory, 0) as Decorator;
                ScrollViewer scrollViewer = null;
                double theOffset = 0;
                if (border != null)
                {
                    scrollViewer = border.Child as ScrollViewer;
                    if (scrollViewer != null)
                    {
                        theOffset = scrollViewer.VerticalOffset;
                    }
                }

                Window_Loaded(null, null);

                scrollViewer.ScrollToVerticalOffset(theOffset);
            }
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            InventoryInfoWindow window = new InventoryInfoWindow();
            window.Owner = this;
            bool? result = window.ShowDialog();
            if (result.HasValue && result == true)
            {
                Window_Loaded(null, null);
                lstInventory.ScrollIntoView(lstInventory.Items[lstInventory.Items.Count - 1]);
            }
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            ListviewItemDoubleClick(null, null);
        }
    }
}
