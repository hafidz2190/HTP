using System.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using System;

namespace POAdministrationTools
{
    public class ExportPdfHelper
    {
        public static string PdfContentType
        {
            get
            { return "application/pdf"; }
        }

        public static byte[] ExportPdf(DataTable dataTable, string path, string heading = "")
        {
            byte[] result = null;
            iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(20, 20, PageSize.A4.Width, PageSize.A4.Height);
            Document document = new Document(pagesize, 10, 10, 50, 10);
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable HeaderTable = new PdfPTable(new float[] { 120f, 500f });
            HeaderTable.WidthPercentage = 100;
            //Header Left
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(path);
            logo.ScaleToFit(90f, 90f);
            logo.Alignment = Element.ALIGN_CENTER;

            PdfPCell HeaderLeftCell = new PdfPCell(logo);
            HeaderLeftCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //HeaderLeftCell.PaddingBottom = 8;
            HeaderLeftCell.BorderWidth = 0;
            HeaderTable.AddCell(HeaderLeftCell);

            //Header Right
            PdfPCell HeaderRightCell = new PdfPCell();
            HeaderRightCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //HeaderRightCell.PaddingBottom = 8;
            HeaderRightCell.BorderWidth = 0;
            Paragraph para = new Paragraph("PEMERINTAH KOTA SURABAYA", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para2 = new Paragraph("BADAN PENGELOLAAN KEUANGAN DAN PAJAK DAERAH", FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            para2.Alignment = Element.ALIGN_CENTER;
            Paragraph para3 = new Paragraph("Jalan Jimerto Nomor 25-27 Telp. (031) 5312144, ext 329,240,388 Fax 5351486", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            para3.Alignment = Element.ALIGN_CENTER;
            Paragraph para4 = new Paragraph("SURABAYA (60272)", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            para4.Alignment = Element.ALIGN_CENTER;
            HeaderRightCell.AddElement(para);
            HeaderRightCell.AddElement(para2);
            HeaderRightCell.AddElement(para3);
            HeaderRightCell.AddElement(para4);

            HeaderTable.AddCell(HeaderRightCell);

            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            table.SpacingBefore = 5f;
            //PdfPRow row = null;
            table.WidthPercentage = 100;

            //int iCol = 0;
            //string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Data Pajak Terutang"));
            Paragraph paraTitle = new Paragraph(heading, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            paraTitle.Alignment = Element.ALIGN_CENTER;
            cell.Colspan = dataTable.Columns.Count;

            foreach (DataColumn c in dataTable.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName.Replace('_',' '), FontFactory.GetFont(FontFactory.HELVETICA, 5, Font.BOLD, BaseColor.BLACK)));
            }

            foreach (DataRow r in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(r[i].ToString(), font5));
                }
            }

            Chunk chunk = new Chunk("___________________________________________________________________________________");
            chunk.SetUnderline(1, -3);
            chunk.SetUnderline(1, -3);
            document.Add(HeaderTable);
            document.Add(new Phrase(chunk));
            document.Add(paraTitle);
            document.Add(table);
            document.Close();
            result = ms.ToArray();
            return result;
        }

        public static byte[] ExportPdf<T>(List<T> data, string path, string Heading = "")
        {
            return ExportPdf(data.ToDataTable(), path, Heading);
        }
    }
}
