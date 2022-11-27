namespace Mima;

public class STV : AddressInstruction
{
    public STV(RegisterTypes register): base(register) {}
    public STV(Address a) : base(a)
    {
    }

    public override void RunOperation(Mima mima)
    {
        if (isRegister)
        {
            getRegister(_register, mima).SetData(mima.Akku.GetData());
            return;
        }
        
        mima.SDR.SetData(mima.Akku.GetData());
        mima.SAR.SetData(a.GetValue());
        mima.Write();    
    }
}