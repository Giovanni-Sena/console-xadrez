using tabuleiro;


namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo (Tabuleiro tabu, Cor cor) : base (tabu, cor)
        {
        }
        public override string ToString()
        {
            return "B";
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
            // Posição diagonal esquerda superior
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna -1);
            while (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.possibilidadeDeMovimentos(pos.linha - 1, pos.coluna - 1);
            }
            // Posição diagonal direita superior
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
            // Posição diagonal direita inferior
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
            // Posição diagonal esquerda inferior
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
