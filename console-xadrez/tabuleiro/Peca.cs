namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabu { get; protected set; }
        public Peca(Posicao posicao, Tabuleiro tabu, Cor cor)
        {
            this.posicao = posicao;
            this.tabu = tabu;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

    }
}
