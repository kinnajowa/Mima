namespace Mima;

public enum OpCodes
{
    LDC = 0,
    LDV = 1,
    STV = 2,
    ADD = 3,
    AND = 4,
    OR = 5,
    XOR = 6,
    EQL = 7,
    JMP = 8,
    JMN = 9,
    LDIV = 0xA,
    STIV = 0xB,
    Special = 0xf
}