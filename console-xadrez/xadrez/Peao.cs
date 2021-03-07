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
            }
            return mat;
        }
    }
}
