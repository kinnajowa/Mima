namespace Mima;

public class OR : AluInstruction
{
    public OR(RegisterTypes register) : base(register) {}
    public OR(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() | mima.Y.GetData());
    }
}