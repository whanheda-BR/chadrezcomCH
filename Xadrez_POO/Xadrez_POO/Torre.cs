public class Torre : Peca
{
    public Torre(int x, int y, string img, enumCor cor) : base(x, y, img, cor){

    }

    public override bool VerificarMovimento(int DestinoX, int DestinoY)
    {
        int DiferençaX = Math.Abs(DestinoX - x);
        int DiferençaY = Math.Abs(DestinoY - y);

        if (DestinoX == x || DestinoY == y)
        {
            return DiferençaX <= 8 && DiferençaY <= 8;
        }
        else
        {
            return DiferençaX <= 0 && DiferençaY <= 0;
        }
    }
}