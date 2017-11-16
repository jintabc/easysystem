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
    /// InventoryInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InventoryInfoWindow : Window
    {
        public InventoryInfoWindow()
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
        }

        public InventoryInfoWindow(Warehouse_Inventory inventory)
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            this.inventoryList = new List<Warehouse_Inventory>();
            this.inventoryList.Add(inventory);
            dgInventory.ItemsSource = this.inventoryList;
        }

        List<Warehouse_Inventory> inventoryList = null;
        InventoryController controller = new InventoryController();


        private void textBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PickGoodsWindow window = new PickGoodsWindow();
            window.Owner = this;
            bool? result = window.ShowDialog();
            if(result.HasValue && result == true)
            {
                List<Warehouse_Goods> goodsList = window.SelectedGoodsList;
                if (inventoryList == null)
                {
                    this.inventoryList = new List<Warehouse_Inventory>();
                }
                Warehouse_Inventory inventory = null;
                foreach (Warehouse_Goods goods in goodsList)
                {
                    inventory = new Warehouse_Inventory()
                    {
                        WarehouseID = Convert.ToInt32(cboWarehouse.SelectedValue),
                        Quantity = 0,
                        MinStorage = 0,
                        Goods = goods,
                    };
                    this.inventoryList.Add(inventory);
                }
                dgInventory.ItemsSource = this.inventoryList;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (controller.AddInventoryList(this.inventoryList) > 0)
            {
                MessageBox.Show("成功");
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //if (controller.UpdateGoods(goods) > 0)
            //{
            //    MessageBox.Show("成功");
            //    this.DialogResult = true;
            //}
            //else
            //{
            //    MessageBox.Show("失败");
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WarehouseController wc = new WarehouseController();
            cboWarehouse.ItemsSource = wc.GetWarehouses();            
        }
    }
}
