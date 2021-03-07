using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        public int turno { get; private set; }
        public Cor jogador { get; private set; }
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
        public void movimentoJogada (Posicao origem, Posicao destino)
        {
            movimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarOrigem( Posicao pos)
        {
            if(tabu.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem!");
            }
            if (jogador != tabu.peca(pos).cor)
            {
                throw new TabuleiroException("Peça seleciona não pertence ao jogador atual!");
            }
            if (!tabu.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça informada!");
            }
        }
        public void vaidarDestino(Posicao origem, Posicao destino)
        {
            if (!tabu.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        private void mudaJogador()
        {
            if(jogador == Cor.Branco)
            {
                jogador = Cor.Preto;
            }
            else
            {
                jogador = Cor.Branco;
            }
        }
        private void incluirPecas()
        {
            tabu.incluirPeca(new Rei(tabu, Cor.Branco), new PosicaoXadrez('d', 1).convertePosicao());
            tabu.incluirPeca(new Torre(tabu, Cor.Branco), new PosicaoXadrez('c', 1).convertePosicao());
            tabu.incluirPeca(new Torre(tabu, Cor.Branco), new PosicaoXadrez('c', 2).convertePosicao());
            tabu.incluirPeca(new Torre(tabu, Cor.Branco), new PosicaoXadrez('d', 2).convertePosicao());
            tabu.incluirPeca(new Torre(tabu, Cor.Branco), new PosicaoXadrez('e', 2).convertePosicao());
            tabu.incluirPeca(new Torre(tabu, Cor.Branco), new PosicaoXadrez('e', 1).convertePosicao());
        }
    }
}
