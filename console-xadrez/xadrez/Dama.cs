using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabu, Cor cor) : base (tabu, cor)
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
            // Posição a esquerda
            pos.possibilidadeDeMovimentos(pos.linha, pos.coluna - 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha, pos.coluna -1);
            }
            // Posição a direita
            pos.possibilidadeDeMovimentos(pos.linha, pos.coluna + 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha, pos.coluna + 1);
            }
            // Posição superior
            pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna);
            }
            // Posição inferior
            pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna);
            }
            // Posição diagonal esquerda superior
            pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna - 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha -1, pos.coluna -1);
            }
            // Posição diagonal direita superior
            pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna + 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna + 1);
            }
            // Posição diagonal direita inferior
            pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna + 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna + 1);
            }
            // Posição diagonal esquerda inferior
            pos.possibilidadeDeMovimentos(pos.linha + 1, pos.coluna - 1);
            while (tabu.posicaoValida(pos) && podeMoverPara(pos))
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
