namespace Mima;

public class JMP : AddressInstruction
{
    public JMP(RegisterTypes register) : base(register) {}
    public JMP(Address a) : base(a)
    {
    }
    
    public override void RunOperation(Mima mima)
    {
        mima.IAR.SetData(a.GetValue());
    }
}