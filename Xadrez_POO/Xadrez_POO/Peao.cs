public class Peao : Peca
{
    public bool jaJogou = false; // Inicialmente, o peão não jogou

    public Peao(int x, int y, string img, enumCor cor) : base(x, y, img, cor) {}

    public override bool VerificarMovimento(int DestinoX, int DestinoY)
    {
        int DiferencaX = Math.Abs(DestinoX - x);
        int DiferencaY = DestinoY - y;
        bool ehBranco = cor == enumCor.branco;

        // Verifica se o movimento é vertical
        if (DiferencaX == 0)
        {
            if (ehBranco)
            {
                if (!jaJogou && DiferencaY <= 2 && DiferencaY > 0) { jaJogou = true; return true; }
                if (DiferencaY == 1) return true;
            }
            else
            {
                if (!jaJogou && DiferencaY >= -2 && DiferencaY < 0) { jaJogou = true; return true; }
                if (DiferencaY == -1) return true;
            }
        }

        // Captura na diagonal
        if (DiferencaY == (ehBranco ? 1 : -1) && DiferencaX == 1)
        {
            // Verifique se há uma peça adversária na posição de captura
            return true; // Retorne verdadeiro se a captura for válida
        }

        return false; // Movimento inválido
    }
}
