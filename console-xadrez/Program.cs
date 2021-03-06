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
                    try
                    {
                        Console.Clear();
                        Tela.impPartida(partida);
                        Console.Write("Posição de origem: ");
                        Posicao origem = Tela.recebePosicaoXadrez().convertePosicao();
                        partida.validarOrigem(origem);
                        bool[,] possicoesPossiveis = partida.tabu.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.impTabuleiro(partida.tabu, possicoesPossiveis);
                        Console.Write("Posição de destino: ");
                        Posicao destino = Tela.recebePosicaoXadrez().convertePosicao();
                        partida.validarDestino(origem, destino);
                        partida.movimentoJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.impPartida(partida);
            }
            catch (TabuleiroException tEx)
            {
                Console.WriteLine(tEx.Message);
            }
            Console.ReadKey();
        }
    }
}
