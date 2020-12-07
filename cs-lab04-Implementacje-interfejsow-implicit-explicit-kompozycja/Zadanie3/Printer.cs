using System;

namespace Zadanie3
{
    public class Printer: IPrinter
    {
        public int Counter { get; private set; } = 0;
        public IDevice.State state = IDevice.State.off;
        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
            Counter++;
        }

        public void PowerOff()
        {
            state = IDevice.State.off;
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now}, Print: {document.GetFileName()}");
                Counter++;
            }   
        }
    }
}