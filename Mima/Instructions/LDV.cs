namespace Mima;

public class LDV : AddressInstruction
{
    public LDV(RegisterTypes register): base(register) {}
    public LDV(Address a) : base(a) {}

    public override void RunOperation(Mima mima)
    {
        if (isRegister)
        {
            mima.Akku.SetData(getRegister(_register, mima).GetData());
            return;
        }
        
        mima.SAR.SetData(a.GetValue());
        mima.Read();
        mima.Akku.SetData(mima.SDR.GetData());
    }
}