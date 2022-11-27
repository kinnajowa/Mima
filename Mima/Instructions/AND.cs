
namespace Mima;

public class AND : AluInstruction
{
    public AND(RegisterTypes register) : base(register) {}
    public AND(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        mima.Z.SetData(mima.X.GetData() & mima.Y.GetData());
    }
}