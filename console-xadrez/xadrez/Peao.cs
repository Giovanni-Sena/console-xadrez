using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tabu, Cor cor, PartidaDeXadrez partida) : base(tabu, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool livre(Posicao pos)
        {
            return tabu.peca(pos) == null;
        }
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tabu.peca(pos);
            return p != null && p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabu.linhas, tabu.colunas];
            Posicao pos = new Posicao(0, 0);
            if (cor == Cor.Branco)
            {
                pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos) && tabu.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna - 1);
                if (tabu.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna + 1);
                if (tabu.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                // jogada en passant
                if(posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if(tabu.posicaoValida(esquerda) && existeInimigo(esquerda) && tabu.peca(esquerda) == partida.enPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabu.posicaoValida(direita) && existeInimigo(direita) && tabu.peca(direita) == partida.enPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
                // jogada en passant
            }
            else
            {
                pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna);
                if(tabu.posicaoValida(pos) && livre(pos)){
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tabu.posicaoValida(p2) && livre(p2) && tabu.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna - 1);
                if (tabu.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna + 1);
                if (tabu.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                // jogada en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabu.posicaoValida(esquerda) && existeInimigo(esquerda) && tabu.peca(esquerda) == partida.enPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabu.posicaoValida(direita) && existeInimigo(direita) && tabu.peca(direita) == partida.enPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }
                // jogada en passant
            }
            return mat;
        }
    }
}
