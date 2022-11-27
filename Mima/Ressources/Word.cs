namespace Mima;

public class Word : Data
{
    public Word(uint c) : base(c) {}
    public Word() : base() {}

    private uint _val;

    public override uint GetValue()
    {
        return _val & 0x00ffffff;
    }

    public override void SetValue(uint data)
    {
        _val = data & 0x00ffffff;
    }

    public override uint GetRawValue()
    {
        return _val;
    }

    public override void SetRawValue(uint data)
    {
        _val = data;
    }
}