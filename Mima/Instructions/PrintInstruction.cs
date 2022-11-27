namespace Mima;

public abstract class PrintInstruction : Instruction
{
    protected void printRegister(string name, Register register)
    {
        uint regval = register.GetData();
        int reg;
        string sign = " ";
        if ((regval & 0x800000) == 0x800000)
        {
            reg = ConvertToInT(regval);
            sign = "";
        }
        else
        {
            reg = (int) regval;
        }
        Console.WriteLine("Current {4} content | int: {0}{1:D8} hex: {2:X6} binary: {3}", sign, reg, regval, Convert.ToString(regval, 2).PadLeft(24, '0'), name.PadLeft(4, ' '));
    }

    private int ConvertToInT(uint val)
    {
        int res =(int) (val << 8);
        res /= 256; //divide by 256 = 2^^8, this equals the operateion "shift to right arithemtically 8 times"  
        return res;
    }
}