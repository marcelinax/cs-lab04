namespace Zadanie3
{
    public class Copier: BaseDevice
    {
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;
        public int Counter { get; private set; } = 0;
        public Printer Printer { get; private set; }
        public Scanner Scanner { get; private set; }

        public Copier()
        {
            Printer = new Printer();
            Scanner = new Scanner();
        }
        public void PowerOn()
        {
            base.PowerOn();
            Counter++;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (state == IDevice.State.on)
            {
                Scanner.PowerOn();
                Scanner.Scan(out document, formatType);
                Scanner.PowerOff();
            }
            else document = null;
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Printer.PowerOn();
                Printer.Print(document);
                Printer.PowerOff();
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