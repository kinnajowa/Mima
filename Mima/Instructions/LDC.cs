namespace Mima;

public class LDC : Instruction
{
    private uint c;

    public LDC(uint c)
    {
        this.c = c;
    }
    
    public override void Run(Mima mima)
    {
        mima.Akku.SetData(c);
    }
}