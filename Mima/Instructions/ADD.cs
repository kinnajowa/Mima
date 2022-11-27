namespace Mima;

public class ADD : AluInstruction
{
    public ADD(RegisterTypes reg) : base(reg) {}
    public ADD(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() + mima.Y.GetData());
    }
}