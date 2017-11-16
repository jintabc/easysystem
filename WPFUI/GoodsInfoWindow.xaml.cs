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
    /// GoodsInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsInfoWindow : Window
    {
        public GoodsInfoWindow()
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
        }

        public GoodsInfoWindow(Warehouse_Goods goods)
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            this.goods = goods;
        }

        Warehouse_Goods goods = new Warehouse_Goods() { GoodsName = "1123", Specification = "asdf", Unit = "asdf", CategoryID = 1 };
        GoodsController controller = new GoodsController();
        

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (controller.AddGoods(goods) > 0)
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
            if (controller.UpdateGoods(goods) > 0)
            {
                MessageBox.Show("成功");
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryController cc = new CategoryController();
            cboCategory.ItemsSource = cc.GetCategories();
            SupplierController sc = new SupplierController();
            cboSupplier.ItemsSource = sc.GetSuppliers();
            this.DataContext = goods;
        }
    }
}
