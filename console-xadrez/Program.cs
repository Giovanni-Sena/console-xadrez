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
                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.incluirPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
                tab.incluirPeca(new Torre(tab, Cor.Preto), new Posicao(0, 7));
                Tela.impTabuleiro(tab);
            }
            catch (TabuleiroException tEx)
            {
                Console.WriteLine(tEx.Message);
            }
            Console.ReadKey();
        }
    }
}
