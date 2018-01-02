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
    /// GoodsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PickGoodsWindow : Window
    {
        public PickGoodsWindow()
        {
            InitializeComponent();
        }

        GoodsController controller = new GoodsController();
        List<Warehouse_Goods> goodsList = null;
        List<Warehouse_Goods> selectedGoodsList = null;

        public List<Warehouse_Goods> SelectedGoodsList { get => selectedGoodsList; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goodsList = controller.GetGoods();
            lstGoods.ItemsSource = goodsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lstGoods.SelectedItem == null)
            {
                return;
            }
            selectedGoodsList = new List<Warehouse_Goods>();
            Warehouse_Goods goods = null;
            foreach (object o in lstGoods.SelectedItems)
            {
                goods = o as Warehouse_Goods;
                selectedGoodsList.Add(goods);
            }
            this.DialogResult = true;
        }
    }
}
