namespace Mima;

public class Address : Data
{
    public Address(uint c) : base(c)
    {
    }
    
    public Address() :base() {}

    private uint _Value;

    public override uint GetValue()
    {
        return _Value & 0x000fffff;
    }

    public override void SetValue(uint data)
    {
        _Value = data & 0x000fffff;
    }

    public override uint GetRawValue()
    {
        return _Value;
    }

    public override void SetRawValue(uint data)
    {
        _Value = data;
    }


    public static Address operator +(Address x, uint y)
    {
        return new Address(x.GetValue() + y);
    }
}