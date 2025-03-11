public class Cavalo : Peca
{
    public Cavalo(int x, int y, string img, enumCor cor) : base(x, y, img, cor)
    {
    }

    public override bool VerificarMovimento(int DestinoX, int DestinoY)
    {
        int DiferençaX = Math.Abs(DestinoX - x);
        int DiferençaY = Math.Abs(DestinoY - y);

        if ((Math.Abs(DestinoX - x) == 2 && Math.Abs(DestinoY - y) == 1) || (Math.Abs(DestinoX - x) == 1 && Math.Abs(DestinoY - y) == 2))
        {
            return DiferençaX <= 8 && DiferençaY <= 8;
        }
        {
            return DiferençaX <= 0 && DiferençaY <= 0;
        }
    }
}