namespace Mima;

public class LDIV : AddressInstruction
{
    public LDIV(Address a) : base(a)
    {
    }

    public LDIV(RegisterTypes register) : base(register)
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
        
        mima.Read();
        mima.Akku.SetData(mima.SDR.GetData());
    }
}