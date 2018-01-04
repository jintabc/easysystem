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

namespace EasySystem.WPFUI
{
    public class PDFTest
    {
        public static string FONT = "Fonts/SIMHEI.TTF";
        public const float PointUnit = 0.035278f;
        public static void Write()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter("D:\\output.pdf"));
            Document doc = new Document(pdfDoc, PageSize.A5);

            PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, false);

            PageXofY e = new PageXofY(pdfDoc);

            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE,e );




            Paragraph title = new Paragraph("设计成果交接单");
            title.SetWidth(CentimeterToPoint(12.7f));
            title.SetFont(font);
            title.SetTextAlignment(TextAlignment.CENTER);
            doc.Add(title);

            Paragraph p = new Paragraph();
            p.SetWidth(CentimeterToPoint(12.7f));
            p.SetFont(font);

            Text t1 = new Text("编号:");
            t1.SetTextAlignment(TextAlignment.LEFT);

            Text t2 = new Text("第1页");
            t2.SetTextAlignment(TextAlignment.RIGHT);

            TabStop tapStop = new TabStop(CentimeterToPoint(10), TabAlignment.RIGHT);
            Tab tab = new Tab();

            p.AddTabStops(new TabStop[] { tapStop });
            p.Add(t1);
            p.Add(tab);
            p.Add(t2);

            doc.Add(p);

            Table table1 = new Table(new float[] { CentimeterToPoint(2), CentimeterToPoint(4.35f), CentimeterToPoint(2), CentimeterToPoint(4.35f) });
            table1.SetWidth(CentimeterToPoint(12.7f));

            Cell cell1 = new Cell();
            cell1.SetFont(font);
            cell1.Add(new Paragraph("项目名称"));
            table1.AddCell(cell1);

            Cell cell2 = new Cell(1, 3);
            cell2.SetFont(font);
            table1.AddCell(cell2);

            Cell cell3 = new Cell();
            cell3.SetFont(font);
            cell3.Add(new Paragraph("建设单位"));
            table1.AddCell(cell3);

            Cell cell4 = new Cell(1, 3);
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
            cel7.Add(new Paragraph("日期"));
            table1.AddCell(cel7);

            Cell cel8 = new Cell();
            cel8.SetFont(font);
            table1.AddCell(cel8);

            Cell cell = new Cell(1, 4);
            cell.Add(new Paragraph("成果类别及数量"));
            cell.SetFont(font);
            cell.SetTextAlignment(TextAlignment.CENTER);
            table1.AddCell(cell);

            doc.Add(table1);

            Table table = new Table(new float[] { CentimeterToPoint(1.2f), CentimeterToPoint(3.75f), CentimeterToPoint(2.55f), CentimeterToPoint(3.25f), CentimeterToPoint(2f) });
            table.SetWidth(CentimeterToPoint(12.7f));


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

            Cell quantity = new Cell();
            quantity.SetFont(font);
            quantity.SetTextAlignment(TextAlignment.CENTER);
            quantity.Add(new Paragraph("数量"));
            table.AddHeaderCell(quantity);

            Cell comments = new Cell();
            comments.SetFont(font);
            comments.SetTextAlignment(TextAlignment.CENTER);
            comments.Add(new Paragraph("备注"));
            table.AddHeaderCell(comments);


            for (int i = 0; i < 100; i++)
            {
                table.AddCell(i.ToString());
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
                table.AddCell(string.Empty);
            }
            doc.Add(table);

            e.WriteTotal(pdfDoc);
            

            doc.Close();
        }

        public static float CentimeterToPoint(float centimeter)
        {
            return centimeter / PointUnit;
        }

        protected internal class RepeatTableRenderer : TableRenderer
        {
            public RepeatTableRenderer(Table modelElement, Table.RowRange rowRange) : base(modelElement, rowRange)
            {
            }

            protected RepeatTableRenderer(Table modelElement) : base(modelElement)
            {
            }


            public override IRenderer GetNextRenderer()
            {
                return new RepeatTableRenderer((Table)modelElement);
            }


            protected override TableRenderer[] Split(int row)
            {
                RepeatTableRenderer splitRenderer = (RepeatTableRenderer)CreateSplitRenderer(
                        new Table.RowRange(rowRange.GetStartRow(), rowRange.GetStartRow() + row));
                splitRenderer.rows = SubList(rows, 0, row);
                RepeatTableRenderer overflowRenderer;
                if (row > 5)
                {
                    overflowRenderer = (RepeatTableRenderer)CreateOverflowRenderer(
                            new Table.RowRange(rowRange.GetStartRow() - 5 + row, rowRange.GetFinishRow()));
                    overflowRenderer.rows = SubList(rows, row - 5, rows.Count());
                }
                else
                {
                    overflowRenderer = (RepeatTableRenderer)CreateOverflowRenderer(
                            new Table.RowRange(rowRange.GetStartRow() + row, rowRange.GetFinishRow()));
                    overflowRenderer.rows = SubList(rows, row, rows.Count());
                }
                splitRenderer.occupiedArea = occupiedArea;
                return new TableRenderer[] { splitRenderer, overflowRenderer };
            }

            private IList<CellRenderer[]> SubList(IList<CellRenderer[]> list, int start, int end)
            {
                List<CellRenderer[]> result = new List<CellRenderer[]>();
                for (int i = start; i <= end; i++)
                {
                    result.Add(list[i]);
                }
                return result;
            }
        }

        //protected class TextFooterEventHandler : IEventHandler
        //{
        //    protected Document doc;

        //    public TextFooterEventHandler(Document doc)
        //    {
        //        this.doc = doc;
        //    }


        //    public void HandleEvent(Event e)
        //    {
        //        PdfDocumentEvent docEvent = (PdfDocumentEvent)e;
        //        PdfCanvas canvas = new PdfCanvas(docEvent.GetPage());
        //        Rectangle pageSize = docEvent.GetPage().GetPageSize();
        //        canvas.BeginText();
        //        try
        //        {
        //            canvas.SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA_OBLIQUE), 5);
        //        }
        //        catch (IOException ex)
        //        {

        //        }
        //        canvas.MoveText((pageSize.GetRight() - doc.GetRightMargin() - (pageSize.GetLeft() + doc.GetLeftMargin())) / 2 + doc.GetLeftMargin(), pageSize.GetTop() - doc.GetTopMargin() + 10)
        //                            .ShowText(docEvent.GetPage().GetDocument().GetPageNumber(docEvent.GetPage()).ToString())
        //                            .MoveText(0, (pageSize.GetBottom() + doc.GetBottomMargin()) - (pageSize.GetTop() + doc.GetTopMargin()) - 20)
        //                            .ShowText("this is a footer")
        //                            .EndText()
        //                            .Release();
        //    }
        //}

    }

    public class PageXofY : IEventHandler
    {
        protected PdfFormXObject placeholder;
        protected float side = 20;
        protected float x = 300;
        protected float y = 25;
        protected float space = 300f;
        protected float descent = 3;
        public static string FONT = "Fonts/SIMHEI.TTF";
        PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, false);
        public PageXofY(PdfDocument pdf)
        {
            placeholder =
                new PdfFormXObject(new Rectangle(0, 0, side+20, side));
        }

        public void HandleEvent(Event e)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)e;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdf.GetPageNumber(page);
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(
                page.GetLastContentStream(), page.GetResources(), pdf);
            Canvas canvas = new Canvas(pdfCanvas, pdf, pageSize);
            canvas.SetFont(font);
            Paragraph p = new Paragraph()
                .Add("第").Add(pageNumber.ToString()).Add("页 ");
            canvas.ShowTextAligned(p, x, y, TextAlignment.LEFT);
            pdfCanvas.AddXObject(placeholder, x + space, y - descent);
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

