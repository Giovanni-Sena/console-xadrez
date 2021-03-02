using System;
using tabuleiro;

namespace console_xadrez
{
    class Tela
    {
        public static void impTabuleiro( Tabuleiro tabu)
        {
            for (int l = 0; l < tabu.Linhas; l++)
            {
                for (int c = 0; c < tabu.Colunas; c++)
                {
                    if (tabu.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{tabu.peca(l, c)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
