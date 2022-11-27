namespace Mima;

public abstract class Register
{
    public Register() {}

    public Register(uint c)
    {
        SetData(c);
    }
    public abstract uint GetData();
    public abstract uint GetRawData();
    public abstract void SetData(uint c);
    public abstract void SetRawData(uint c);
}