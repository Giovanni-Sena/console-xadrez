using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei( Tabuleiro tabu, Cor cor) : base (tabu,cor)
        {
        }
        public override string ToString()
        {
            return "R";
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
            pos.possibilidadeDeMovimentos(posicao.linha -1, posicao.coluna);
            if(tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição diagonal direita superior
            pos.possibilidadeDeMovimentos(posicao.linha - 1, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição a direita
            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição diagonal direita inferior
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição inferior
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição diagonal esquerda inferior
            pos.possibilidadeDeMovimentos(posicao.linha + 1, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição esquerda
            pos.possibilidadeDeMovimentos(posicao.linha, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição diagonal esquerda superior
            pos.possibilidadeDeMovimentos(posicao.linha -1, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
    }
}
