namespace Mima;

public class MultiPurposeRegister : Register
{
    private Word a = new Word(0);
    public MultiPurposeRegister(): base() {}
    public MultiPurposeRegister(uint a): base(a) {}
    
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