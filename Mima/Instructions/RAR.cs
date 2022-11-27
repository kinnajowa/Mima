namespace Mima;

public class RAR : Instruction
{
    public override void Run(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() >> 1);
    }
}