namespace MainArgs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Переменные среды из параметров Main");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            Console.ReadKey();

            Console.WriteLine("Переменные среды из Environment");
            foreach (var envArg in Environment.GetCommandLineArgs())
            {
                Console.WriteLine(envArg);
            }
            Console.ReadKey();
        }
    }
}