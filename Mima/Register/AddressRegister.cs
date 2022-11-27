namespace Mima;

public class AddressRegister : Register
{
    private Address a = new Address(0);
    public AddressRegister(): base() {}
    public AddressRegister(uint a): base(a) {}
    
    public override uint GetData()
    {
        return a.GetValue();
    }

    public override uint GetRawData()
    {
        return a.GetRawValue();
    }

    public override void SetData(uint c)
    {
        a.SetValue(c);
    }

    public override void SetRawData(uint c)
    {
        a.SetRawValue(c);
    }
}