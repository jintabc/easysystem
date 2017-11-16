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
    public partial class GoodsWindow : Window
    {
        public GoodsWindow()
        {
            InitializeComponent();
        }

        GoodsController controller = new GoodsController();
        List<Warehouse_Goods> goodsList = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goodsList = controller.GetGoods();
            lstGoods.ItemsSource = goodsList;
        }

        protected void ListviewItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstGoods.SelectedItem == null)
            {
                return;
            }
            int currentIndex = lstGoods.SelectedIndex;
            Warehouse_Goods goods = lstGoods.SelectedItem as Warehouse_Goods;
            GoodsInfoWindow window = new GoodsInfoWindow(goods);
            window.Owner = this;
            bool? result = window.ShowDialog().Value;
            if (result.HasValue && result == true)
            {
                Decorator border = VisualTreeHelper.GetChild(lstGoods, 0) as Decorator;
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
    }
}
