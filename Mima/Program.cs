// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

namespace Mima;

public class Program
{
   
    public static int Main(string[] args)
    {
        string input = null;
        string filePath = "example/Example.mima";

        while (input != "q")
        {
            Console.WriteLine("Input your Program File ('q' to exit, 'r' to relaunch): ");
            input = Console.ReadLine();

            if (input == "q") break;
            if (input != "r") filePath = input;

            Memory memory;
            
            try
            {
                InputParser parser = new InputParser(filePath);
                memory = parser.Parse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            Mima mima = new Mima(memory);


            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (mima.CanStep)
            {
                mima.Step();
            }
            watch.Stop();
            Console.WriteLine($"Elapsed time: {Convert.ToInt32(watch.Elapsed.TotalMilliseconds)}ms");
        }
        
        Console.WriteLine("Have a nice day!");
        return 0;
    }
}