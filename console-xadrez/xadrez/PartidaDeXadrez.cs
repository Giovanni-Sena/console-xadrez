using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        public int turno { get; private set; }
        public Cor jogador { get; private set; }
        public bool finalizada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            finalizada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            incluirPecas();
        }
        public void movimento (Posicao origem, Posicao destino)
        {
            Peca p = tabu.removerPeca(origem);
            p.atualizarQtdMovimentos();
            Peca pecaCapturada =  tabu.removerPeca(destino);
            tabu.incluirPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
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
        public HashSet<Peca> pecasCapturada(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturada(cor));
            return aux;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabu.incluirPeca(peca, new PosicaoXadrez(coluna, linha).convertePosicao());
            pecas.Add(peca);
        }
        private void incluirPecas()
        {
            colocarNovaPeca('d', 5, new Rei(tabu, Cor.Preto));

            colocarNovaPeca('d', 1, new Rei(tabu, Cor.Branco));
            colocarNovaPeca('c', 1, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('c', 2, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('d', 2, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('e', 2, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('e', 1, new Torre(tabu, Cor.Branco));
        }
    }
}
