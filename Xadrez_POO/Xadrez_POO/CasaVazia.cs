public class CasaVazia : Peca
{
    public CasaVazia(int x, int y, string img, enumCor cor) : base(x, y, img, cor)
    {
    }
    public override bool VerificarMovimento(int trocaLinha, int trocaColuna)
    {
        return true;
    }

}