namespace Mima;

public class EQL : AluInstruction
{
    public EQL(RegisterTypes register) : base(register) {}
    public EQL(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() == mima.Y.GetData() ? 0xffffffff : 0);
    }
}