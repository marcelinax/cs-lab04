using System;
namespace Zadanie3
{
    public class Fax: BaseDevice,IFax
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
    }
}