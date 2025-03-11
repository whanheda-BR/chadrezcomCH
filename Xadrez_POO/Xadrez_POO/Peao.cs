public class Peao : Peca
{
    public bool jaJogou = false; // Inicialmente, o peão não jogou

    public Peao(int x, int y, string img, enumCor cor) : base(x, y, img, cor)
    {
    }

    public override bool VerificarMovimento(int DestinoX, int DestinoY)
    {
        int DiferencaX = Math.Abs(DestinoX - x);
        int DiferencaY = DestinoY - y;

        // Movimento para peões brancos
        if (cor == enumCor.branco)
        {
            if (!jaJogou) // Se o peão ainda não jogou
            {
                // Permite mover 1 ou 2 casas
                if (DiferencaY <= 2 && DiferencaX == 0 && DiferencaY > 0)
                {
                    jaJogou = true; // Marca que o peão já jogou
                    return true;
                }
            }
            else // Se já jogou
            {
                // Permite mover apenas 1 casa
                if (DiferencaY == 1 && DiferencaX == 0)
                {
                    return true;
                }
            }

            // Captura na diagonal
            if (DiferencaY == 1 && DiferencaX == 1)
            {
                // Aqui você deve verificar se há uma peça adversária na posição de captura
                return true; // Retorne verdadeiro se a captura for válida
            }
        }
        // Movimento para peões pretos
        else
        {
            if (!jaJogou) // Se o peão ainda não jogou
            {
                // Permite mover 1 ou 2 casas
                if (DiferencaY >= -2 && DiferencaX == 0 && DiferencaY < 0)
                {
                    jaJogou = true; // Marca que o peão já jogou
                    return true;
                }
            }
            else // Se já jogou
            {
                // Permite mover apenas 1 casa
                if (DiferencaY == -1 && DiferencaX == 0)
                {
                    return true;
                }
            }

            // Captura na diagonal
            if (DiferencaY == -1 && DiferencaX == 1)
            {
                // Aqui você deve verificar se há uma peça adversária na posição de captura
                return true; // Retorne verdadeiro se a captura for válida
            }
            
        }

        return false; // Se nenhuma condição for atendida, o movimento não é válido
    }
}