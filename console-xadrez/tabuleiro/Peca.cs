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
        public abstract bool[,] movimentosPossiveis();
    }
}
