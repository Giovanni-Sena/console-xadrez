using System;
using tabuleiro;

namespace console_xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.impTabuleiro(tab);
            Console.ReadKey();
        }
    }
}
