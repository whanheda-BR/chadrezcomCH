public class Rei : Peca{
    public Rei(int x, int y, string img, enumCor cor) : base( x, y, img, cor){
    }
    public override bool VerificarMovimento(int DestinoX, int DestinoY)
    {
        int DiferençaX = Math.Abs(DestinoX - x);
        int DiferençaY = Math.Abs(DestinoY - y);

        return DiferençaX <= 1 && DiferençaY <= 1;
    }

}
