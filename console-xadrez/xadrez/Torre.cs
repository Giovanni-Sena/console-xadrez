using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }
        public override string ToString()
        {
            return "T";
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
            // Posição superior
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }
            // Posição inferior
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }
            // Posição a direita
            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna + 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            // Posição a esquerda
            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna - 1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }
    }
}