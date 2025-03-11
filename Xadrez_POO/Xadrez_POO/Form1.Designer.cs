namespace Xadrez_POO;

partial class Form1
{
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    /// 

    PictureBox botaoClicado;
    int _x = -1, _y = -1;
    private System.ComponentModel.IContainer components = null;
    private const int GridSize = 8;
    private PictureBox[,] grid = new PictureBox[GridSize, GridSize];
    public Peca[,] tabuleiro = new Peca[GridSize, GridSize];
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        for (int linha = 0; linha < 8; linha++)
        {
            for (int coluna = 0; coluna < 8; coluna++)
            {
                int x = coluna, y = linha;
                if (linha % 2 == 0 ^ coluna % 2 == 0)
                {
                    tabuleiro[x, y] = new CasaVazia(x * 50, y * 50, "casaVaziaPreta.png", enumCor.CasaVazia);
                    this.Controls.Add(tabuleiro[x, y].pictureBox);
                    tabuleiro[x, y].pictureBox.BringToFront();
                    tabuleiro[x, y].pictureBox.Click += (sender, args) => { cliqueNoTabuleiro(tabuleiro[x, y]); };
                }
                else
                {
                    tabuleiro[x, y] = new CasaVazia(x * 50, y * 50, "casaVaziaBege.png", enumCor.CasaVazia);
                    this.Controls.Add(tabuleiro[x, y].pictureBox);
                    tabuleiro[x, y].pictureBox.BringToFront();
                    tabuleiro[x, y].pictureBox.Click += (sender, args) => { cliqueNoTabuleiro(tabuleiro[x, y]); };
                }
            }
        }
        

        InicializarTabuleiro();
    }
    #endregion
}
