namespace Mima;

public class Memory
{
    private uint[] mem = new uint[1 << 20];
    private Address start;

    public Memory(IList<uint> mem, Address start)
    {
        if (mem.Count > this.mem.Length) throw new Exception("Memory not big enough.");

        for (int i = 0; i < mem.Count; i++)
        {
            this.mem[i] = mem[i];
        }

        for (int i = mem.Count; i < this.mem.Length; i++)
        {
            //set halt
            this.mem[i] = 0x00f00000;
        }

        this.start = start;
    }
    public void Read(Mima mima)
    {
        mima.SDR.SetRawData(mem[mima.SAR.GetData()]);
    }

    public void Write(Mima mima)
    {
        mem[mima.SAR.GetData()] = mima.SDR.GetData();
    }

    public Address GetDefaultStartAddress()
    {
        return start;
    }
}