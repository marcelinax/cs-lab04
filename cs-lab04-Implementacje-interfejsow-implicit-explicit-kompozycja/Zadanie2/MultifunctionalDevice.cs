using Zadanie1;
using System;
namespace Zadanie2
{
    public class MultifunctionalDevice: Copier, IFax
    {
        public int SendFaxCounter { get; private set; } = 0;
        public void SendFax(in IDocument document, string faxNumber)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now}, Fax: {document.GetFileName()} to: {faxNumber}");
                SendFaxCounter++;
            }
        }

        public void ScanAndSendFax(string faxNumber)
        {
            Scan(out IDocument document);
            SendFax(document, faxNumber);
        }
    }
}