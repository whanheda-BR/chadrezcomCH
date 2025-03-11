using System.Drawing;
using System.IO;
using System.Windows.Forms;

public enum enumCor 
{
    CasaVazia, 
    branco, 
    Preto
}

public abstract class Peca
{
    public int x;
    public int y; 
    public string img = "";
    public enumCor cor;
    public PictureBox pictureBox = new PictureBox();

    public Peca(int x, int y, string img, enumCor cor)
    {
        this.x = x / 50;
        this.y = y / 50;
        this.cor = cor;
        pictureBox.Location = new Point(x, y);
        pictureBox.Size = new Size(50, 50);
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        try
        {
            this.img = Path.Combine(Application.StartupPath, "imagens", img);
            pictureBox.Image = Image.FromFile(this.img);
        }
        catch
        {
            // Tratar exceção, talvez logar um erro
        }
    }

    // Método para verificar se o movimento é válido
    public virtual bool VerificarMovimento(int destinoX, int destinoY)
    {
        // Exemplo: Verificar se a nova posição está dentro dos limites do tabuleiro
        return (destinoX >= 0 && destinoX < 8 && destinoY >= 0 && destinoY < 8);
    }

    // Método para mover a peça
    public void Mover(int destinoX, int destinoY)
    {
        if (VerificarMovimento(destinoX, destinoY))
        {
            // Atualizar coordenadas
            this.x = destinoX;
            this.y = destinoY;
            // Atualizar a posição do PictureBox
            pictureBox.Location = new Point(destinoX * 50, destinoY * 50);
        }
        else
        {
            // Tratar movimento inválido (opcional)
        }
    }

    // Método para capturar uma peça
    public void Capturar(Peca pecaCapturada)
    {
        // Aqui você pode adicionar a lógica para remover a peça capturada do tabuleiro
        // Por exemplo, se você tiver uma lista de peças no seu tabuleiro, remova a peça capturada
        // Exemplo: tabuleiro.RemoverPeca(pecaCapturada);

        // Mover a peça que capturou para a posição da peça capturada
        Mover(pecaCapturada.x, pecaCapturada.y);
    }
}
