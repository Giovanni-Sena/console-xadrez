namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabu { get; protected set; }
        public Peca(Tabuleiro tabu, Cor cor)
        {
            this.posicao = null;
            this.tabu = tabu;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }
        public void atualizarQtdMovimentos()
        {
            qtdMovimentos ++;
        }
        public void atualizarQtdMovimentosRetroativo()
        {
            qtdMovimentos--;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int l = 0; l < tabu.linhas; l++)
            {
                for(int c = 0; c < tabu.colunas; c++)
                {
                    if (mat[l, c])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] movimentosPossiveis();
    }
}
