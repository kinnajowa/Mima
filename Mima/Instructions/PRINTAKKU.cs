namespace Mima;

public class PRINTAKKU : PrintInstruction
{
    public override void Run(Mima mima)
    {
        printRegister(nameof(mima.Akku), mima.Akku);
    }
}