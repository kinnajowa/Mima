namespace Mima;

public class HALT : Instruction
{
    public override void Run(Mima mima)
    {
        mima.CanStep = false;
        Console.WriteLine("MIMA haltet.");
    }
}