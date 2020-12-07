using Zadanie1;
using System;

namespace Zadanie2
{
    public interface IFax: IDevice
    {
        public void SendFax(in IDocument document, string faxNumber);
    }
}