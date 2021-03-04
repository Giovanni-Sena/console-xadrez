using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        private int turno;
        private Cor jogador;
        public bool finalizada { get; private set; }
        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            finalizada = false;
            incluirPecas();
        }
        public void movimento (Posicao origem, Posicao destino)
        {
            Peca p = tabu.removerPeca(origem);
            p.atualizarQtdMovimentos();
            Peca pecaCapturada =  tabu.removerPeca(destino);
            tabu.incluirPeca(p, destino);
        }
        private void incluirPecas()
        {
            tabu.incluirPeca(new Torre(tabu, Cor.Preto), new PosicaoXadrez('c',1).convertePosicao());
        }
    }
}
