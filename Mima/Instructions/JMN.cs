namespace Mima;

public class JMN : AddressInstruction
{
    public JMN(RegisterTypes register) : base(register) {}
    public JMN(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        var mask = 1 << 19;
        if ((mima.Akku.GetData() & mask) == mask) 
            mima.IAR.SetData(a.GetValue());
    }
}