using System;
using tabuleiro;
using xadrez;

namespace console_xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            }
            catch (TabuleiroException tEx)
            {
                Console.WriteLine(tEx.Message);
            }
            Console.ReadKey();
        }
    }
}
