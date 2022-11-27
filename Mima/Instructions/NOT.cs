namespace Mima;

public class NOT : Instruction
{
    public override void Run(Mima mima)
    {
        mima.Z.SetData(~mima.X.GetData());
    }
}