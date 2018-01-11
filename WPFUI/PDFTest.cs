using iText.IO;
using iText.IO.Font;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Renderer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Printing;
using System.IO;

namespace EasySystem.WPFUI
{
    public class PDFTest
    {
        public static string FONT = "Fonts/SIMHEI.TTF";
        public const float PointUnit = 0.035278f;
        public static void Write()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter("D:\\output.pdf"));
            Document doc = new Document(pdfDoc, PageSize.A4);
            doc.SetMargins(CentimeterToPoint(10f), CentimeterToPoint(0.8f), CentimeterToPoint(1f), CentimeterToPoint(1.2f));
            PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, false);

            PageXofY e = new PageXofY(pdfDoc);

            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, e);
            


            Paragraph title = new Paragraph("设计成果交接单");
            title.SetWidth(CentimeterToPoint(19f));
            title.SetFont(font);
            title.SetTextAlignment(TextAlignment.CENTER);
            doc.Add(title);

            Paragraph p = new Paragraph();
            p.SetWidth(CentimeterToPoint(19f));
            p.SetFont(font);
            p.SetTextAlignment(TextAlignment.JUSTIFIED);

            Text t1 = new Text("编号：");
            t1.SetTextAlignment(TextAlignment.LEFT);

            TabStop tab = new TabStop(12f, TabAlignment.RIGHT);

            Text t2 = new Text("日期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            t2.SetTextAlignment(TextAlignment.RIGHT);

            p.Add(t1);
            p.AddTabStops(tab);
            p.Add(t2);
            doc.Add(p);

            Table table1 = new Table(new float[] {
                CentimeterToPoint(2.35f),
                CentimeterToPoint(4f),
                CentimeterToPoint(2.35f),
                CentimeterToPoint(4f),
                CentimeterToPoint(2.3f),
                CentimeterToPoint(4f)
            });
            table1.SetWidth(CentimeterToPoint(19f));

            Cell cell1 = new Cell();
            cell1.SetFont(font);
            cell1.Add(new Paragraph("项目名称"));
            table1.AddCell(cell1);

            Cell cell2 = new Cell(1, 5);
            cell2.SetFont(font);
            table1.AddCell(cell2);

            Cell cell3 = new Cell();
            cell3.SetFont(font);
            cell3.Add(new Paragraph("建设单位"));
            table1.AddCell(cell3);

            Cell cell4 = new Cell(1, 5);
            cell4.SetFont(font);
            table1.AddCell(cell4);

            Cell cell5 = new Cell();
            cell5.SetFont(font);
            cell5.Add(new Paragraph("设计部门"));
            table1.AddCell(cell5);

            Cell cel6 = new Cell();
            cel6.SetFont(font);
            table1.AddCell(cel6);

            Cell cel7 = new Cell();
            cel7.SetFont(font);
            cel7.Add(new Paragraph("设计号"));
            table1.AddCell(cel7);

            Cell cel8 = new Cell();
            cel8.SetFont(font);
            table1.AddCell(cel8);


            Cell cel9 = new Cell();
            cel9.SetFont(font);
            cel9.Add(new Paragraph("项目负责人"));
            table1.AddCell(cel9);

            Cell cel10 = new Cell();
            cel10.SetFont(font);
            table1.AddCell(cel10);

            Cell cell = new Cell(1, 6);
            cell.Add(new Paragraph("成果类别及数量"));
            cell.SetFont(font);
            cell.SetTextAlignment(TextAlignment.CENTER);
            table1.AddCell(cell);

            doc.Add(table1);

            Table table = new Table(new float[] {
                CentimeterToPoint(1.5f),
                CentimeterToPoint(4f),
                CentimeterToPoint(3f),
                CentimeterToPoint(1f),
                CentimeterToPoint(1f),
                CentimeterToPoint(1f),
                CentimeterToPoint(1f),
                CentimeterToPoint(1f),
                CentimeterToPoint(1.5f),
                CentimeterToPoint(4f)
            });
            table.SetWidth(CentimeterToPoint(19f));


            Cell seq = new Cell();
            seq.SetFont(font);
            seq.SetTextAlignment(TextAlignment.CENTER);
            seq.Add(new Paragraph("序号"));
            table.AddHeaderCell(seq);

            Cell name = new Cell();
            name.SetFont(font);
            name.SetTextAlignment(TextAlignment.CENTER);
            name.Add(new Paragraph("名称"));
            table.AddHeaderCell(name);

            Cell subject = new Cell();
            subject.SetFont(font);
            subject.SetTextAlignment(TextAlignment.CENTER);
            subject.Add(new Paragraph("专业"));
            table.AddHeaderCell(subject);

            Cell A0 = new Cell();
            A0.SetFont(font);
            A0.SetTextAlignment(TextAlignment.CENTER);
            A0.Add(new Paragraph("A0"));
            table.AddHeaderCell(A0);

            Cell A1 = new Cell();
            A1.SetFont(font);
            A1.SetTextAlignment(TextAlignment.CENTER);
            A1.Add(new Paragraph("A1"));
            table.AddHeaderCell(A1);

            Cell A2 = new Cell();
            A2.SetFont(font);
            A2.SetTextAlignment(TextAlignment.CENTER);
            A2.Add(new Paragraph("A2"));
            table.AddHeaderCell(A2);

            Cell A3 = new Cell();
            A3.SetFont(font);
            A3.SetTextAlignment(TextAlignment.CENTER);
            A3.Add(new Paragraph("A3"));
            table.AddHeaderCell(A3);

            Cell A4 = new Cell();
            A4.SetFont(font);
            A4.SetTextAlignment(TextAlignment.CENTER);
            A4.Add(new Paragraph("A4"));
            table.AddHeaderCell(A4);

            Cell Copies = new Cell();
            Copies.SetFont(font);
            Copies.SetTextAlignment(TextAlignment.CENTER);
            Copies.Add(new Paragraph("份数"));
            table.AddHeaderCell(Copies);

            Cell comments = new Cell();
            comments.SetFont(font);
            comments.SetTextAlignment(TextAlignment.CENTER);
            comments.Add(new Paragraph("备注"));
            table.AddHeaderCell(comments);


            for (int i = 1; i < 101; i++)
            {
                table.AddCell(i.ToString());
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
            }
            doc.Add(table);

            e.WriteTotal(pdfDoc);


            doc.Close();

            //pdfDoc.GetWriter().GetOutputStream().
            //PrintQueue queue = LocalPrintServer.GetDefaultPrintQueue();
            //using (PrintSystemJobInfo job = queue.AddJob())
            //{
            //    using (Stream stream = job.JobStream)
            //    {
            //        stream.Write()
            //    }
            //}
        }

        public static float CentimeterToPoint(float centimeter)
        {
            return centimeter / PointUnit;
        }
    }

    public class PageXofY : IEventHandler
    {
        protected PdfFormXObject placeholder;
        protected float side = 20;
        protected float x = 25;
        protected float y = 25;
        protected float space = 300f;
        protected float descent = 3;
        public static string FONT = "Fonts/SIMHEI.TTF";
        PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, false);
        public PageXofY(PdfDocument pdf)
        {
            placeholder =
                new PdfFormXObject(new Rectangle(0, 0, side + 20, side));
            x = pdf.GetDefaultPageSize().GetWidth() / 2;
        }

        public void HandleEvent(Event e)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)e;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdf.GetPageNumber(page);
            int pageCount = pdf.GetNumberOfPages();
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(
                page.GetLastContentStream(), page.GetResources(), pdf);
            Canvas canvas = new Canvas(pdfCanvas, pdf, pageSize);
            canvas.SetFont(font);
            Paragraph p = new Paragraph()
                .Add("第").Add(pageNumber.ToString()).Add("页 ");
            canvas.ShowTextAligned(p, x, y, TextAlignment.RIGHT);
            pdfCanvas.AddXObject(placeholder, x, y - descent);
            pdfCanvas.Release();
        }

        public void WriteTotal(PdfDocument pdf)
        {
            Canvas canvas = new Canvas(placeholder, pdf);
            canvas.SetFont(font);
            canvas.ShowTextAligned(("共" + pdf.GetNumberOfPages().ToString() + "页"),
                0, descent, TextAlignment.LEFT);
        }
    }

}

