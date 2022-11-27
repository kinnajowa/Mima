namespace Mima;

public abstract class Instruction
{
    public abstract void Run(Mima mima);

    public static Instruction Parse(uint ins, Address address)
    {
        OpCodes opcode = (OpCodes) ((ins >> 20) & 0xf);
        uint param = ins & 0x000fffff;

        uint mask = 0xf0000000;
        bool isRegister = (ins & mask) == mask;
        RegisterTypes register = parseRegister(ins);

        switch (opcode)
        {
            case OpCodes.LDC:
                return new LDC(param);
            case OpCodes.LDV:
                if (isRegister) return new LDV(register);
                return new LDV(new Address(param));
            case OpCodes.STV:
                return new STV(new Address(param));
            case OpCodes.ADD:
                if (isRegister) return new ADD(register);
                return new ADD(new Address(param));
            case OpCodes.AND:
                if (isRegister) return new AND(register);
                return new AND(new Address(param));
            case OpCodes.OR:
                if (isRegister) return new OR(register);
                return new OR(new Address(param));
            case OpCodes.XOR:
                if (isRegister) return new XOR(register);
                return new XOR(new Address(param));
            case OpCodes.EQL:
                if (isRegister) return new EQL(register);
                return new EQL(new Address(param));
            case OpCodes.JMP:
                if (isRegister) return new JMP(register);
                return new JMP(new Address(param));
            case OpCodes.JMN:
                if (isRegister) return new JMN(register);
                return new JMN(new Address(param));
            case OpCodes.LDIV:
                if (isRegister) return new LDIV(register);
                return new LDIV(new Address(param));
            case OpCodes.STIV:
                if (isRegister) return new STIV(register);
                return new STIV(new Address(param));
            case OpCodes.Special:
                SpecialOpCodes specialOpCode = (SpecialOpCodes) (ins >> 16);
                switch (specialOpCode)
                {
                    case SpecialOpCodes.HALT:
                        return new HALT();
                    case SpecialOpCodes.NOT:
                        return new NOT();
                    case SpecialOpCodes.RAR:
                        return new RAR();
                    case SpecialOpCodes.PRINTAKKU:
                        return new PRINTAKKU();
                    case SpecialOpCodes.PRINT:
                        return new PRINT();
                    case SpecialOpCodes.NOP:
                        return new NOP();
                }
                break;
        }
        
        
        Console.WriteLine($"Invalid Operation at address {Convert.ToString(ins, 16).PadLeft(6, '0')}: {Convert.ToString(ins, 2).PadLeft(32, '0')}");
        return new HALT();
    }

    private static RegisterTypes parseRegister(uint ins)
    {
        return (RegisterTypes) ((ins & 0x0f000000) >> 24);
    }
}