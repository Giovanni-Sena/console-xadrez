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
                    mudarCor(tabu.peca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void impTabuleiro(Tabuleiro tabu, bool[,] posicoePossiveis)
        {
            ConsoleColor fundoTabu = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.Green;
            for (int l = 0; l < tabu.linhas; l++)
            {
                Console.BackgroundColor = fundoTabu;
                Console.Write(8 - l + " ");
                for (int c = 0; c < tabu.colunas; c++)
                {
                    if (posicoePossiveis[l, c])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoTabu;
                    }
                    mudarCor(tabu.peca(l, c));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoTabu;
            Console.WriteLine("  A B C D E F G H");
        }
        public static PosicaoXadrez recebePosicaoXadrez()
        {
            string recebe = Console.ReadLine();
            char coluna = recebe[0];
            int linha = int.Parse(recebe[1] + "");
            return new PosicaoXadrez(coluna,linha);
        }
        public static void mudarCor(Peca peca)
        {
            if (peca == null)
            { 
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
