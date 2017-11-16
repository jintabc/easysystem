using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using iText.Kernel;
using iText.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.Layout.Element;

namespace WPFUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Project> Projects = new List<Project>();
        List<ServiceType> ServiceTypes = new List<ServiceType>();
        List<ChengBenDan> ChengBenDans = new List<WPFUI.ChengBenDan>();
        ChengBenDan chengbendan = new ChengBenDan();
        public MainWindow()
        {
            InitializeComponent();
            GenerateData();
            acbServiceType.ItemsSource = ServiceTypes;
            acbProjectName.ItemsSource = Projects;
            chengbendan = new ChengBenDan() { FinishDate = DateTime.Now, Project = Projects[0], Customer="张三", Department="市政分院" };
            chengbendan.Details = new ObservableCollection<ServiceItem>();
            ServiceItem serviceItem = new ServiceItem()
            {
                ServiceType = ServiceTypes[0],
                Quantity = 10,
                Copy = 5,
                Remarks = "图集",
            };
            chengbendan.Details.Add(serviceItem);
            chengbendan.SerialNumber = DateTime.Now.Ticks.ToString();
            ChengBenDans.Add(chengbendan);

            this.DataContext = chengbendan;
            
            
        }

        public void GenerateData()
        {
            Project project1 = new Project()
            {
                ProjectName = "美的蓝溪谷三期",
                Constructor = "株洲美的房地产发展有限公司"
            };
            Project project2 = new Project()
            {
                ProjectName = "机场大道",
            };
            Projects.Add(project1);
            Projects.Add(project2);

            ServiceType type1 = new ServiceType()
            {
                Code = "BC",
                Name = "白纸彩色",
                Size = "A3",
                UnitPrice = 5.1
            };
            ServiceType type2 = new ServiceType()
            {
                Code = "BD",
                Name = "白纸单色",
                Size = "A3",
                UnitPrice = 1.1
            };
            ServiceType type3 = new ServiceType()
            {
                Code = "JZ",
                Name = "胶装",
                Size = "A3",
                UnitPrice = 40
            };
            ServiceTypes.Add(type1);
            ServiceTypes.Add(type2);
            ServiceTypes.Add(type3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = from q in ServiceTypes where (q.Code == acbServiceType.Text || q.Name == acbServiceType.Text) && q.Size == cboSize.Text select q;
            if(a.Count() == 0)
            {
                System.Windows.MessageBox.Show("业务或尺寸输入错误");
                return;
            }
            ServiceItem item = new ServiceItem()
            {
                ServiceType = a.First(),
                Quantity = (int)sudQuantity.Value,
                Copy = (int)sudCopy.Value,
                Remarks = txtRemarks.Text
            };
            chengbendan.Details.Add(item);
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render,
new Action(() => acbServiceType.Focus()));
        }

        private void acbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (acbServiceType.Text.Contains('|'))
            {
                acbServiceType.Text = acbServiceType.Text.Substring(acbServiceType.Text.LastIndexOf('|') + 1);
            }
        }

        public void Output()
        {
            PdfWriter writer = new PdfWriter("Test.pdf");
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);
            PdfFont font = PdfFontFactory.CreateFont("STSongStd-Light", "UniGB-UCS2-H", false);
            
            doc.Add(new iText.Layout.Element.Paragraph(chengbendan.Department+"生产成本管理卡").SetFont(font).SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

            doc.Add(new iText.Layout.Element.Paragraph("编号："+chengbendan.SerialNumber + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t日期：" + chengbendan.FinishDate.ToString("yyyy年MM月dd日")).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

            iText.Layout.Element.Table table = new iText.Layout.Element.Table(new float[] { 35, 55, 90, 55, 55, 55, 55,55, 55 });
            table.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            table.AddCell(new Cell(3, 1).Add(new iText.Layout.Element.Paragraph("项\n目\n情\n况").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("项目名称").SetFont(font)).SetHeight(40));
            table.AddCell(new Cell(1, 7).Add(new iText.Layout.Element.Paragraph(chengbendan.Project.ProjectName).SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("专业名称").SetFont(font)));
            table.AddCell(new Cell(1, 7).Add(new iText.Layout.Element.Paragraph(string.IsNullOrEmpty(chengbendan.SubjectName)?"":chengbendan.SubjectName).SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("经办人").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(chengbendan.Customer).SetFont(font)));
            table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph("业务性质").SetFont(font)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("院内").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("加晒").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("").SetFont(font)));
            table.AddCell(new Cell(1, 9).Add(new iText.Layout.Element.Paragraph("业务详单").SetFont(font)));


            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("序号").SetFont(font)));
            table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph("业务项目").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("尺寸").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("数量").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("份数").SetFont(font)));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("单价").SetFont(font)));
            table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph("备注").SetFont(font)));
            for (int i = 1; i < 16; i++)
            {
                table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(i.ToString())));
                if (chengbendan.Details.Count > i - 1)
                {
                    table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].ServiceType.Name).SetFont(font)));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].ServiceType.Size)));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].Quantity.ToString())));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].Copy.ToString())));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].ServiceType.UnitPrice.ToString())));
                    table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph(chengbendan.Details[i - 1].Remarks)));
                }
                else
                {
                    table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph()));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
                    table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
                    table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph()));
                }
            }
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph("合计").SetFont(font)));
            table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph()));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
            table.AddCell(new Cell(1, 1).Add(new iText.Layout.Element.Paragraph()));
            table.AddCell(new Cell(1, 2).Add(new iText.Layout.Element.Paragraph()));

            doc.Add(table);

            doc.Add(new iText.Layout.Element.Paragraph("操作人员签字：\t\t\t\t\t\t\t\t图文中心主任签字：\t\t\t\t\t\t\t\t成果验收签字：").SetFont(font));
            doc.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Projects.Exists(q=>q.ProjectName == acbProjectName.Text))
            {
                chengbendan.Project = Projects.First(q => q.ProjectName == acbProjectName.Text);
            }
            else
            {
                Project p = new Project() { ProjectName = acbProjectName.Text };
                Projects.Add(p);
                acbProjectName.ItemsSource = null;
                 acbProjectName.ItemsSource = Projects;
                chengbendan.Project = p;
            }
            Output();
        }
    }

    public class Project
    {
        public string ProjectName { get; set; }
        public string Constructor { get; set; }

        public override string ToString()
        {
            return ProjectName;
        }
    }

    public class ServiceType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Size { get; set; }

        public override string ToString()
        {
            return Code + "||" + Name;
        }
    }

    public class ChengBenDan
    {
        public string SerialNumber { get; set; }
        public string SubjectName { get; set; }
        public Project Project { get; set; }
        public string Customer { get; set; }
        public string Department { get; set; }
        public DateTime FinishDate { get; set; }
        public int BusinessType { get; set; }
        public ObservableCollection<ServiceItem> Details { get; set; }
    }

    public class ServiceItem
    {
        public ServiceType ServiceType { get; set; }
        public int Quantity { get; set; }
        public int Copy { get; set; }
        public string Remarks { get; set; }
    }
}
