namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;
        public Tabuleiro (int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca( Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool pecaExistente(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        public void incluirPeca(Peca pe, Posicao po)
        {
            if (pecaExistente(po))
            {
                throw new TabuleiroException("Já existe uma peça na posição informada!");
            }
            pecas[po.Linha, po.Coluna] = pe;
            pe.posicao = po;
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void validarPosicao( Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
