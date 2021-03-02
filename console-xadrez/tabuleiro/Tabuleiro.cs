﻿namespace tabuleiro
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
        public void incluirPeca(Peca pe, Posicao po)
        {
            pecas[po.Linha, po.Coluna] = pe;
            pe.posicao = po;
        }
    }
}