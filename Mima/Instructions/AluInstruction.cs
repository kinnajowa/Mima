namespace Mima;

public abstract class AluInstruction : AddressInstruction
{
    public AluInstruction(Address a) : base(a)
    {
    }

    public AluInstruction(RegisterTypes r) : base(r)
    {
    }
    
    public override void Run(Mima mima)
    {
        //load operands
        mima.X.SetData(mima.Akku.GetData());
        if (isRegister)
        {
            mima.Y.SetData(getRegister(_register, mima).GetData());
        }
        else
        {
            mima.SAR.SetData(a.GetValue());
            mima.Read();
            mima.Y.SetData(mima.SDR.GetData());
        }

        //perform operation
        RunOperation(mima);
        
        //writeback result
        mima.Akku.SetData(mima.Z.GetData());
    }
}