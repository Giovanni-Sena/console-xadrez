namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;
        public Tabuleiro (int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca( Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
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
            pecas[po.linha, po.coluna] = pe;
            pe.posicao = po;
        }
        public Peca removerPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca auxRP = peca(pos);
            auxRP.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return auxRP;
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
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
