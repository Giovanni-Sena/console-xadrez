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
    }
}
