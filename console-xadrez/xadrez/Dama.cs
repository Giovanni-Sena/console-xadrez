using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }
        public override string ToString()
        {
            return "D";
        }
        private bool validarMovimento(Posicao pos)
        {
            Peca p = tabu.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabu.linhas, tabu.colunas];
            Posicao pos = new Posicao(0, 0);

            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna - 1);
            while(tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha, pos.coluna - 1);
            }
            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna + 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha, pos.coluna + 1);
            }
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna);
            }
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna);
            }
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna -1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna - 1);
            }
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna + 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna + 1);
            }
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna + 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna + 1);
            }
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna - 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna - 1);
            }
            return mat;
        }
    }
}