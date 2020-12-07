using System;
namespace Zadanie3
{
    public class Scanner: IScanner
    {
        public int Counter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public IDevice.State state = IDevice.State.off;

        public IDevice.State GetState()
        {
            return state;
        }
        public void PowerOff() {
            state = IDevice.State.off;
        }

        public void PowerOn() {
            state = IDevice.State.on;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
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

            string nameOfFile = string.Format($"{type}Scan{ScanCounter}.{formatType.ToString().ToLower()}");

            if(formatType == IDocument.FormatType.TXT) document = new TextDocument(nameOfFile);
            if(formatType == IDocument.FormatType.JPG) document = new ImageDocument(nameOfFile);
            else document = new PDFDocument(nameOfFile);
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now}, Scan: {document.GetFileName()}");
                ScanCounter++;
            }
        }
    }
}