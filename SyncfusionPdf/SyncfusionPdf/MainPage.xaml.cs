using System;
using Xamarin.Forms;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using SyncfusionPdf.Services;

namespace SyncfusionPdf
{
    public partial class MainPage : ContentPage
    {
        private readonly ISave _save;

        public MainPage()
        {
            InitializeComponent();
            _save = DependencyService.Get<ISave>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            PdfFont fontAutor = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            //Draw the text
            graphics.DrawString("Test", font, PdfBrushes.Black, new PointF(0, 0));

            //Save the document to the stream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            _save.SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
