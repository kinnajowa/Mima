namespace Mima;

public abstract class AddressInstruction : Instruction
{
    protected Address a;
    protected bool isRegister = false;
    protected RegisterTypes _register;

    public override void Run(Mima mima)
    {
        if (isRegister)
        {
            a = new Address(getRegister(_register, mima).GetData());
        }
        RunOperation(mima);
    }
    
    public abstract void RunOperation(Mima mima);

    public AddressInstruction(Address a)
    {
        this.a = a;
    }

    public AddressInstruction(RegisterTypes register)
    {
        _register = register;
        isRegister = true;
    }
    
    protected Register getRegister(RegisterTypes r, Mima mima)
    {
        switch (r)
        {
            case RegisterTypes.Akku: return mima.Akku;
            case RegisterTypes.X: return mima.X;
            case RegisterTypes.Y: return mima.Y;
            case RegisterTypes.Z: return mima.Z;
            case RegisterTypes.EINS: return mima.EINS;
            case RegisterTypes.IAR: return mima.IAR;
            case RegisterTypes.IR: return mima.IR;
            case RegisterTypes.SAR: return mima.SAR;
            case RegisterTypes.SDR: return mima.SDR;
        }

        throw new Exception("Register not found.");
    }
}