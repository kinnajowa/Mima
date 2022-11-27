namespace Mima;

public class Mima
{
    public readonly Register Akku = new MultiPurposeRegister();
    public readonly Register X = new MultiPurposeRegister();
    public readonly Register Y = new MultiPurposeRegister();
    public readonly Register Z = new MultiPurposeRegister();
    public readonly Register EINS = new MultiPurposeRegister(1);
    public readonly Register IAR = new AddressRegister(0);
    public readonly Register IR = new MultiPurposeRegister();
    public readonly Register SAR = new AddressRegister();
    public readonly Register SDR = new MultiPurposeRegister();
    
    public Memory Mem { get; set; }

    public Mima(Memory memcontent)
    {
        Mem = memcontent;
        IAR.SetData(Mem.GetDefaultStartAddress().GetValue());
    }

    public void Read()
    {
        Mem.Read(this);
    }

    public void Write()
    {
        Mem.Write(this);
    }

    public void Step()
    {
        Fetch();
        var ins = Decode();
        ins.Run(this);
    }

    private void Fetch()
    {
        SAR.SetData(IAR.GetData());
        Mem.Read(this);
        IR.SetRawData(SDR.GetRawData());
        IAR.SetData(IAR.GetData() + 1);
    }
    private Instruction Decode()
    {
        Instruction ins = Instruction.Parse(IR.GetRawData(), new Address(IAR.GetData()));
        return ins;
    }

    public bool CanStep { get; set; } = true;
}