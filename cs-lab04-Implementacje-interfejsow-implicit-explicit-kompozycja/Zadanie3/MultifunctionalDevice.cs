using System;
namespace Zadanie3
{
    public class MultifunctionalDevice: Copier
    {
        public Fax Fax { get; private set; }
        public int FaxCounter => Fax.SendFaxCounter;

        public MultifunctionalDevice()
        {
            Fax = new Fax();
        }

        public void SendFax(in IDocument document, string faxNumber)
        {
            if (state == IDevice.State.on)
            {
                Fax.PowerOn();
                Fax.SendFax(in document, faxNumber);
                Fax.PowerOff();
            }
        }
        public void ScanAndSendFax(string faxNumber)
        {
            Scan(out IDocument document);
            SendFax(document, faxNumber);
        }
    }
}