namespace Mima;

public abstract class Data
{
    public Data() {}
    public Data(uint data) => SetValue(data);
    
    public abstract uint GetValue();
    public abstract void SetValue(uint data);
    public abstract uint GetRawValue();
    public abstract void SetRawValue(uint data);
}