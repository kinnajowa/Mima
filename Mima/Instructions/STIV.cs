namespace Mima;

public class STIV : AddressInstruction
{
    public STIV(Address a) : base(a)
    {
    }

    public STIV(RegisterTypes register) : base(register)
    {
    }

    public override void RunOperation(Mima mima)
    {
        if (isRegister)
        {
            mima.SAR.SetData(getRegister(_register, mima).GetData());
        }
        else
        {
            mima.SAR.SetData(a.GetValue());
            mima.Read();
            mima.SAR.SetData(mima.SDR.GetData());
        }
        
        mima.SDR.SetData(mima.Akku.GetData());
        mima.Write();
    }
}