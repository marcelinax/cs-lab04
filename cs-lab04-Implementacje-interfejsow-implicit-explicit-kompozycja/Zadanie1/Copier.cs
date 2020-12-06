using System;

namespace Zadanie1
{
    public class Copier: BaseDevice, IPrinter , IScanner
    {
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public int Counter { get; }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                PrintCounter++;
                Console.WriteLine($"{DateTime.Today}, Print: {document.GetFileName()}");
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            string type = "";
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    type = "PDF";
                    break;
                case IDocument.FormatType.TXT:
                    type = "Text";
                    break;
                case IDocument.FormatType.JPG:
                    type = "Image";
                    break;
            }

            string nameOfFile = string.Format($"{type}Scan{ScanCounter++}.{formatType.ToString().ToLower()}");

            if(formatType == IDocument.FormatType.TXT) document = new TextDocument(nameOfFile);
            if(formatType == IDocument.FormatType.JPG) document = new ImageDocument(nameOfFile);
            else document = new PDFDocument(nameOfFile);
            if (state == IDevice.State.on)
            {

                ScanCounter++;
                Console.WriteLine($"{DateTime.Today}, Scan: {document.GetFileName()}");
            }
        }


        public void ScanAndPrint()
        {
                Scan(out IDocument doc);
                Print(doc);
        }
    }
}