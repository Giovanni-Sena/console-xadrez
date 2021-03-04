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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.finalizada)
                {
                    Console.Clear();
                    Tela.impTabuleiro(partida.tabu);
                    Console.WriteLine();
                    Console.Write("Informe a posição conforme exemplo (a1).");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Posição de origem: ");
                    Posicao origem = Tela.recebePosicaoXadrez().convertePosicao();
                    Console.Write("Posição de destino: ");
                    Posicao destino = Tela.recebePosicaoXadrez().convertePosicao();
                    partida.movimento(origem, destino);
                }
            }
            catch (TabuleiroException tEx)
            {
                Console.WriteLine(tEx.Message);
            }
            Console.ReadKey();
        }
    }
}
