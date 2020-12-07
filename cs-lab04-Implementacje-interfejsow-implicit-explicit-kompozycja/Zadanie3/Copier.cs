namespace Zadanie3
{
    public class Copier: BaseDevice
    {
        public int PrintCounter => Printer.
        public int ScanCounter { get => Scanner.Counter; }
        public Printer Printer { get; private set; }
        public Scanner Scanner { get; private set; }

        public Copier()
        {
            Printer = new Printer();
            Scanner = new Scanner();
        }

        public void Scan()
        {
            
        }

        public void Print()
        {
            
        }
    }
}