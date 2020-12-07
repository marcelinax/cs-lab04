using System;

namespace Zadanie1
{
    public class Copier: BaseDevice, IPrinter , IScanner
    {
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public int Counter { get; private set; } = 0;

        public void PowerOn()
        {
            base.PowerOn();
            Counter++;
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now}, Print: {document.GetFileName()}");
                PrintCounter++;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
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
                default:
                    throw new Exception("Incorrect format!");
            }

            string nameOfFile = string.Format($"{type}Scan{ScanCounter + 1}.{formatType.ToString().ToLower()}");

            if(formatType == IDocument.FormatType.TXT) document = new TextDocument(nameOfFile);
            if(formatType == IDocument.FormatType.JPG) document = new ImageDocument(nameOfFile);
            else document = new PDFDocument(nameOfFile);
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now}, Scan: {document.GetFileName()}");
                ScanCounter++;
                
            }
        }

        public void ScanAndPrint()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}