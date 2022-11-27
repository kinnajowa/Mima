namespace Mima;

public class XOR : AluInstruction
{
    public XOR(RegisterTypes register) : base(register) {}
    public XOR(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() ^ mima.Y.GetData());
    }
}