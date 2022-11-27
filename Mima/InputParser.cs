using System.Globalization;
using System.IO;

namespace Mima;

public class InputParser
{
    private string file = String.Empty;
    
    private Dictionary<string, Address> labels = new(); 
    private List<uint> instructions = new();
    private Dictionary<uint, KeyValuePair<string, int>> labelReplacements = new();

    public InputParser(string filePath)
    {
        file = filePath;
    }

    public Memory Parse()
    {
        labels.Clear();
        instructions.Clear();
        labelReplacements.Clear();
        
        IList<string> lines = File.ReadLines(file).ToList();
        
        for (int line = 0; line < lines.Count; line++)
        {
            if (instructions.Count > 0xfffff)
                throw new Exception(
                    $"Could not parse input at line {line}: Memory full! attemptet to write address {instructions.Count} which is out of memory");
                    
            //extract label
            var ln = lines[line].Trim().ToUpper();
            if (string.IsNullOrEmpty(ln)) continue;
            
            if (ln.StartsWith(":")) continue;
            var labelSplit = ln.Split(":");

            uint? ins;

            if (labelSplit.Length == 2)
            {
                labels.Add(labelSplit[0], new Address((uint) instructions.Count));
                if (string.IsNullOrEmpty(labelSplit[1])) continue;

                try
                {
                    ins = parseLine(labelSplit[1], line);
                }
                catch
                {
                    throw new Exception($"Could not parse input at line {line}: {ln}");
                }
            } 
            else if (labelSplit.Length != 1)
            {
                throw new Exception($"Could not parse input at line {line}: {ln}");
            }
            else
            {
                try
                {
                    ins = parseLine(labelSplit[0], line);
                }
                catch (Exception e)
                {
                    throw new Exception($"Could not parse input at line {line}: {ln}\nError: {e.Message}");
                }
            }
            
            if (ins == null) continue; 
            instructions.Add((uint) ins);
        }

        foreach (var labelReplacement in labelReplacements)
        {
            var addr = labelReplacement.Key;
            var label = labelReplacement.Value.Key;
            var line = labelReplacement.Value.Value;

            if (!labels.ContainsKey(label))
                throw new Exception($"Could not parse input at line {line}:\nLabel {label} not found");

            instructions[(int) addr] |= labels[label].GetValue();
        }

        if (!labels.ContainsKey("START"))
            throw new Exception(
                "Could not parse input. Expected label 'start' to indicate program start.");
        return new Memory(instructions, labels["START"]);
    }

    private uint? parseLine(string line, int lineNumber)
    {
        var paramList = line.Trim().Split(" ");
        if (paramList.Length < 1) throw new Exception("");
        if (paramList.Length == 1)
        {
            SpecialOpCodes specialOpCode;
            if (!SpecialOpCodes.TryParse(paramList[0], out specialOpCode))
                throw new Exception($"Could not parse instruction '{paramList[0]}'.");
            
            return ((uint) specialOpCode) << 16;
        }
        if (paramList.Length == 2)
        {
            if (paramList[0] == "*")
            {
                uint newAddress;
                if (paramList[1].StartsWith("0X"))
                {
                    if (!uint.TryParse(paramList[1].Remove(0,2), NumberStyles.HexNumber, NumberFormatInfo.CurrentInfo ,out newAddress))
                        throw new Exception($"Invalid operator '{paramList[1]}', expected type 'uint'");
                } else {
                    if (!uint.TryParse(paramList[1], out newAddress))
                        throw new Exception($"Invalid operator '{paramList[1]}', expected type 'uint'");
                }

                if (newAddress <= instructions.Count)
                    throw new Exception(
                        $"Could not set new memory location, got: {newAddress}, expected value to be greater than current location ({instructions.Count})");

                if (newAddress >= 0x00ffffff)
                    throw new Exception(
                        $"Could not set new memory location, got: {newAddress}, but the greatest memory address is {0xffffff}");

                for (int i = instructions.Count; i < newAddress; i++)
                {
                    instructions.Add((uint) SpecialOpCodes.NOP << 16);
                }
                return null;
            }

            if (paramList[0] == "DS")
            {
                if (labels.ContainsKey("START"))
                    throw new Exception(
                        "All 'DS'  statements must occur before start label to avoid unexpected behaviour.");
                
                uint address;
                if (paramList[1].StartsWith("0X"))
                {
                    if (!uint.TryParse(paramList[1].Remove(0,2), NumberStyles.HexNumber, NumberFormatInfo.CurrentInfo ,out address))
                        throw new Exception($"Invalid operator '{paramList[1]}', expected type 'uint'");
                } else
                {
                    if (!uint.TryParse(paramList[1], out address))
                        throw new Exception($"Invalid operator '{paramList[1]}', expected type 'uint'");
                }

                if (address > 0x00ffffff)
                    throw new Exception(
                        $"Value is to large, got: {paramList[1]}, expected to be in range from 0 to 0x00ffffff (word size of the mima)");
                
                return address;
            }
            
            OpCodes OpCode;
            if (!OpCodes.TryParse(paramList[0], out OpCode))
                throw new Exception($"Could not parse instruction '{paramList[0]}'.");

            uint par;
            if (!uint.TryParse(paramList[1], out par))
            {
                RegisterTypes reg;
                if (!RegisterTypes.TryParse(paramList[1], out reg))
                {
                    labelReplacements.Add((uint)instructions.Count, new KeyValuePair<string, int>(paramList[1], lineNumber));
                    par = 0;
                }
                else
                {
                    var regnum = (uint) reg;
                    par = (regnum << 24) | 0xf0000000;
                    return (((uint) OpCode) << 20) | par;
                }
            }

            if (par > 0xfffff)
                throw new Exception(
                    $"Parameter was to large, got {paramList[1]}, expected value to be less or equal than {0xfffff}");
            
            return (((uint) OpCode) << 20) | par;
        }
        
        throw new Exception($"Invalid amount of arguments (expected 0 or 1), got: {paramList.Length}");
    }
}