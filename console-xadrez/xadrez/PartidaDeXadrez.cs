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
        public bool xeque { get; private set; }
        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            finalizada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            incluirPecas();
        }
        public Peca movimento(Posicao origem, Posicao destino)
        {
            Peca p = tabu.removerPeca(origem);
            p.atualizarQtdMovimentos();
            Peca pecaCapturada = tabu.removerPeca(destino);
            tabu.incluirPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            //jogada roque
            if(p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tabu.removerPeca(origemTorre);
                torre.atualizarQtdMovimentos();
                tabu.incluirPeca(torre, destinoTorre);
            }
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tabu.removerPeca(origemTorre);
                torre.atualizarQtdMovimentos();
                tabu.incluirPeca(torre, destinoTorre);
            }
            //jogada roque
            return pecaCapturada;
        }
        public void desfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca dFM = tabu.removerPeca(destino);
            dFM.atualizarQtdMovimentosRetroativo();
            if (pecaCapturada != null)
            {
                tabu.incluirPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabu.incluirPeca(dFM, origem);
            // jogada roque
            if (dFM is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tabu.removerPeca(destinoTorre);
                torre.atualizarQtdMovimentosRetroativo();
                tabu.incluirPeca(torre, origemTorre);
            }
            if (dFM is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tabu.removerPeca(destinoTorre);
                torre.atualizarQtdMovimentosRetroativo();
                tabu.incluirPeca(torre, origemTorre);
            }
            // jogada roque

        }
        public void movimentoJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = movimento(origem, destino);
            if (emXeque(jogador))
            {
                desfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Não é possível movimentar, seu rei vai ficar em xeque");
            }
            if (emXeque(adversaria(jogador)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (xequeMate(adversaria(jogador)))
            {
                finalizada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }
        }
        public void validarOrigem(Posicao pos)
        {
            if (tabu.peca(pos) == null)
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
        public void validarDestino(Posicao origem, Posicao destino)
        {
            if (!tabu.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        private void mudaJogador()
        {
            if (jogador == Cor.Branco)
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
            foreach (Peca x in capturadas)
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
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branco;
            }
        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool emXeque(Cor cor)
        {
            Peca reiAux = rei(cor);
            if (reiAux == null)
            {
                throw new TabuleiroException($"Não existe Rei da cor {cor} no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[reiAux.posicao.linha, reiAux.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool xequeMate(Cor cor)
        {
            if (!emXeque(cor))
            {
                return false;
            }
            foreach (Peca p in pecasEmJogo(cor))
            {
                bool[,] mat = p.movimentosPossiveis();
                for (int l = 0; l < tabu.linhas; l++)
                {
                    for(int c = 0; c < tabu.colunas; c++)
                    {
                        if (mat[l, c])
                        {
                            Posicao origem = p.posicao;
                            Posicao destino = new Posicao(l, c);
                            Peca pecaCapturada = movimento(origem, destino);
                            bool testeXeque = emXeque(cor);
                            desfazerMovimento(origem, destino,pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabu.incluirPeca(peca, new PosicaoXadrez(coluna, linha).convertePosicao());
            pecas.Add(peca);
        }
        private void incluirPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('b', 1, new Cavalo(tabu, Cor.Branco));
            colocarNovaPeca('c', 1, new Bispo(tabu, Cor.Branco));
            colocarNovaPeca('d', 1, new Dama(tabu, Cor.Branco));
            colocarNovaPeca('e', 1, new Rei(tabu, Cor.Branco, this));
            colocarNovaPeca('f', 1, new Bispo(tabu, Cor.Branco));
            colocarNovaPeca('g', 1, new Cavalo(tabu, Cor.Branco));
            colocarNovaPeca('h', 1, new Torre(tabu, Cor.Branco));
            colocarNovaPeca('a', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('b', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('c', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('d', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('e', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('f', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('g', 2, new Peao(tabu, Cor.Branco, this));
            colocarNovaPeca('h', 2, new Peao(tabu, Cor.Branco, this));

            colocarNovaPeca('a', 8, new Torre(tabu, Cor.Preto));
            colocarNovaPeca('b', 8, new Cavalo(tabu, Cor.Preto));
            colocarNovaPeca('c', 8, new Bispo(tabu, Cor.Preto));
            colocarNovaPeca('d', 8, new Dama(tabu, Cor.Preto));
            colocarNovaPeca('e', 8, new Rei(tabu, Cor.Preto, this));
            colocarNovaPeca('f', 8, new Bispo(tabu, Cor.Preto));
            colocarNovaPeca('g', 8, new Cavalo(tabu, Cor.Preto));
            colocarNovaPeca('h', 8, new Torre(tabu, Cor.Preto));
            colocarNovaPeca('a', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('b', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('c', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('d', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('e', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('f', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('g', 7, new Peao(tabu, Cor.Preto, this));
            colocarNovaPeca('h', 7, new Peao(tabu, Cor.Preto, this));
        }
    }
}
