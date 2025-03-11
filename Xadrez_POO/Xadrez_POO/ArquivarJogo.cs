using System.Reflection.PortableExecutable;
using System.CodeDom;

public class Arquivarjogo
{   
    public static void SalvarTabuleiro(Peca peca)
    {
        string caminhoArquivo = "ArquivoJogo.txt";
        string entrada = $"Peça:{peca}, linha:{peca.x}, coluna:{peca.y}, cor:{peca.cor}";
        File.AppendAllText(caminhoArquivo, entrada + Environment.NewLine);
    }

    public static void ApagarSave()
    {
        string caminhoArquivo = "ArquivoJogo.txt";
        string entrada = "";
        File.WriteAllText(caminhoArquivo, entrada + Environment.NewLine);
    }
}