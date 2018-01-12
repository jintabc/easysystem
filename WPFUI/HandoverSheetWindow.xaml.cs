using EasySystem.Core.Controllers;
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
    /// HandoverSheetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HandoverSheetWindow : Window
    {
        private Business_HandoverSheet sheet = null;
        private HandoverSheetController sheetController = null;
        public HandoverSheetWindow()
        {
            InitializeComponent();
            sheetController = new HandoverSheetController();
        }

        public HandoverSheetWindow(int sheetID)
        {
            InitializeComponent();
            sheetController = new HandoverSheetController();
            sheet = sheetController.Get(sheetID);
            this.DataContext = sheet;
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
