namespace Mima;

public class PRINT : PrintInstruction
{
    public override void Run(Mima mima)
    {
        printRegister(nameof(mima.Akku), mima.Akku);
        printRegister(nameof(mima.X), mima.X);
        printRegister(nameof(mima.Y), mima.Y);
        printRegister(nameof(mima.Z), mima.Z);
        printRegister(nameof(mima.EINS), mima.EINS);
        printRegister(nameof(mima.IAR), mima.IAR);
        printRegister(nameof(mima.IR), mima.IR);
        printRegister(nameof(mima.SAR), mima.SAR);
        printRegister(nameof(mima.SDR), mima.SDR);
    }
}