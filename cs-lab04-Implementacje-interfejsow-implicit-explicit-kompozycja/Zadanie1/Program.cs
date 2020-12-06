using System;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            var copier = new Copier();
            copier.PowerOn();
            IDocument doc1 = new PDFDocument("xd.pdf");
            copier.Print(in doc1);
            IDocument doc2; 
            copier.Scan(out doc2);
            
            copier.ScanAndPrint();
            Console.WriteLine(copier.PrintCounter);
            Console.WriteLine(copier.ScanCounter);
            copier.PowerOff();
            Console.WriteLine(copier.Counter);
        }
    }
}