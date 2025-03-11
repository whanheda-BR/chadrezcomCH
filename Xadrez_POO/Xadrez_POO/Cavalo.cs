public class Cavalo : Peca
{
    public Cavalo(int x, int y, string imagem, enumCor cor) : base(x, y, imagem, cor) {}

    public override bool VerificarMovimento(int destinoX, int destinoY)
    {
        // O movimento do cavalo: forma de "L"
        int dx = Math.Abs(destinoX - x);
        int dy = Math.Abs(destinoY - y);
        return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }
}
