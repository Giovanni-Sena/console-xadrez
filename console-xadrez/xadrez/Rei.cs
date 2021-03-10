using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei( Tabuleiro tabu, Cor cor, PartidaDeXadrez partida) : base (tabu,cor)
        {
            this.partida = partida;
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
        private bool testeRoque(Posicao pos)
        {
            Peca p = tabu.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabu.linhas, tabu.colunas];
            Posicao pos = new Posicao(0, 0);
            // Posição diagonal direita
            pos.possibilidadeDeMovimentos(posicao.linha -1, posicao.coluna);
            if(tabu.posicaoValida(pos) && validarMovimento(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Posição diagonal esquerda 
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
            // Jogadas possiveis do roque
            if(qtdMovimentos == 0 && !partida.xeque)
            {
                Posicao posicaoTorre = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeRoque(posicaoTorre))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tabu.peca(p1) == null && tabu.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                Posicao posicaoTorre2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeRoque(posicaoTorre))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabu.peca(p1) == null && tabu.peca(p2) == null && tabu.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }
            // Jogadas possiveis do roque
            return mat;
        }
    }
}
