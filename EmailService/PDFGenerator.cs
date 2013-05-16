using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Collections.Generic;

namespace EmailService
{
    public class PDFGenerator
    {
        public List<KeyValuePair<string, string>> ExamDetails = new List<KeyValuePair<string, string>>();

        private PdfDocument _document;
        private MemoryStream _stream;
        private const float _documentWidth = 21.0f;
        private const float _documentHeight = 29.7f;

        private const int _examTypePilot = 1;
        private const int _examTypePacker = 2;

        private XGraphics gfx;
        private PdfPage page;
        private XFont h1, h2, bodyBold, bodyRegular, bodyBoldUnderlined;

        private int coordY;

        private int CoordY_BB
        {
            get { return coordY + 10; }
        }

        public MemoryStream CreatePDF(List<KeyValuePair<string, string>> exam, int examType)
        {
            // Create a new PDF document
            _document = new PdfDocument();

            // Add title
            _document.Info.Title = String.Format((examType == _examTypePacker) ? "Packer" : "Pilot");

            // Create an empty page
            page = _document.AddPage();
            page.Width = new XUnit(_documentWidth, XGraphicsUnit.Centimeter);
            page.Height = new XUnit(_documentHeight, XGraphicsUnit.Centimeter);

            // Get an XGraphics object for drawing
            gfx = XGraphics.FromPdfPage(page);

            //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            // Create a font
            // XFont font = new XFont("Helvetica", 30, XFontStyle.BoldItalic);
            h1 = new XFont("Calibri", 20, XFontStyle.Regular);
            h2 = new XFont("Calibri", 16, XFontStyle.Regular);
            bodyBold = new XFont("Calibri", 12, XFontStyle.Bold);
            bodyRegular = new XFont("Calibri", 12, XFontStyle.Regular);
            bodyBoldUnderlined = new XFont("Calibri", 12, XFontStyle.Underline | XFontStyle.Bold);

            ExamDetails = exam;

            CreateBody();

            //Temporarily removed
            //_document.Save("C:/Users/p404/Desktop/test.pdf");
            //_stream = new MemoryStream();
            //_document.Save(_stream, false);
            return _stream;
        }

        public void CreateBody()
        {
            // Doesn't change
            gfx.DrawString("Australian Parachute Federation", h1, XBrushes.Black,
             new XRect(0, 0, page.Width, 200.0),
              XStringFormats.Center);
            gfx.DrawString(_document.Info.Title + " Exam Summary", h2, XBrushes.Black,
             new XRect(0, 0, page.Width, 250.0),
              XStringFormats.Center);
            gfx.DrawLine(new XPen(new XColor()), new Point(50, 140), new Point(550, 140));
            gfx.DrawString("Candidate Details", bodyBoldUnderlined, XBrushes.Black,
            new XRect(50, 180, page.Width, 220.0),
             XStringFormats.TopLeft);

            coordY = 205;
            int labelIndent = 90;
            int dataIndent = 200;
            int counter = 0;

            for (; counter < 3; ++counter)
            {
                gfx.DrawString(ExamDetails[counter].Key + ":", bodyBold, XBrushes.Black, new XRect(labelIndent, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
                gfx.DrawString(ExamDetails[counter].Value, bodyRegular, XBrushes.Black, new XRect(dataIndent, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
                coordY += 25;
            }
            coordY += 25;

            gfx.DrawString("Theory Exam Result", bodyBoldUnderlined, XBrushes.Black, new XRect(50, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
            coordY += 25;

            gfx.DrawString(ExamDetails[counter].Key + ":", bodyBold, XBrushes.Black, new XRect(labelIndent, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
            gfx.DrawString(ExamDetails[counter].Value, bodyRegular, XBrushes.Black, new XRect(dataIndent, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
            coordY += 25;

            gfx.DrawString("Practical Exam Result", bodyBoldUnderlined, XBrushes.Black, new XRect(50, coordY, page.Width, CoordY_BB), XStringFormats.TopLeft);
            coordY += 25;
            gfx.DrawString(String.Format("{0} has successfully demonstrated the required 10 supervised parachute packs", ExamDetails[0].Value),
                bodyRegular, XBrushes.Black, new XRect(0, coordY, page.Width, CoordY_BB), XStringFormats.Center);
        }
    }
}
