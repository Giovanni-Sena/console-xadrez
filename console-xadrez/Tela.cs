using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace console_xadrez
{
    class Tela
    {
        public static void impTabuleiro( Tabuleiro tabu)
        {
            for (int l = 0; l < tabu.linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tabu.colunas; c++)
                {
                    if (tabu.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        mudarCor(tabu.peca(l, c));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void mudarCor(Peca peca)
        {
            if (peca.cor == Cor.Branco)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
