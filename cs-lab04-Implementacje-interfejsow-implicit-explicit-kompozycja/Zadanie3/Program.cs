using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();
            IDocument doc = new PDFDocument("aaaa.pdf");
            device.Print(in doc);

            IDocument doc2;
            device.Scan(out doc2);
            device.ScanAndPrint();
            
            device.SendFax(doc, "123456789");
            device.ScanAndSendFax("123456789");
            
            Console.WriteLine(device.Counter);
            Console.WriteLine(device.FaxCounter);
            Console.WriteLine(device.PrintCounter);
            Console.WriteLine(device.ScanCounter);
            
            var copier = new Copier();
            copier.PowerOn();
            IDocument doc1 = new PDFDocument("xd.pdf");
            copier.Print(in doc1);
            IDocument doc3; 
            copier.Scan(out doc3);
            
            copier.ScanAndPrint();
            Console.WriteLine(copier.PrintCounter);
            Console.WriteLine(copier.ScanCounter);
            Console.WriteLine(copier.Counter);
        }
    }
}