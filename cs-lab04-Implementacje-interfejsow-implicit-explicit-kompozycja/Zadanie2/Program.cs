using System;
using System.Reflection.Metadata;
using Zadanie1;

namespace Zadanie2
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
            Console.WriteLine(device.SendFaxCounter);
            Console.WriteLine(device.PrintCounter);
            Console.WriteLine(device.ScanCounter);

        }
    }
}