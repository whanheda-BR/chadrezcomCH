namespace Xadrez_POO;

public partial class Form1 : Form
{     
    public Form1()
    {
        InitializeComponent();
    }

    public void cliqueNoTabuleiro(Peca peca)
    {
        if (_x == -1 && _y == -1) // Primeiro clique: seleciona a peça
        {
            if (peca is not CasaVazia)
            {
                botaoClicado = peca.pictureBox;
                _x = peca.x;
                _y = peca.y;
                MessageBox.Show($"Peça selecionada em ({peca.x}, {peca.y})");
            }
        }
        else // Segundo clique: tenta mover a peça
        {
            Peca pecaOrigem = tabuleiro[_x, _y];
            Peca pecaDestino = tabuleiro[peca.x, peca.y];

            if (!pecaOrigem.VerificarMovimento(peca.x, peca.y) || 
                _x == peca.x && _y == peca.y || 
                (pecaDestino.cor == pecaOrigem.cor))
            {
                MessageBox.Show("Movimento Inválido!");
                ResetarSelecao();
                return;
            }

            // Move a peça ou troca
            if (pecaDestino is CasaVazia)
            {
                MoverPeca(pecaOrigem, peca);
            }
            else
            {
                TrocarPecas(pecaOrigem, pecaDestino, peca);
            }

            AtualizarJogo();
            ResetarSelecao();
        }
    }

    private void MoverPeca(Peca pecaOrigem, Peca peca)
    {
        tabuleiro[_x, _y] = new CasaVazia(_x * 50, _y * 50, "casaVazia.png", enumCor.CasaVazia);
        tabuleiro[peca.x, peca.y] = pecaOrigem;
        pecaOrigem.x = peca.x;
        pecaOrigem.y = peca.y;
        pecaOrigem.pictureBox.Location = new Point(peca.x * 50, peca.y * 50);
    }

    private void TrocarPecas(Peca pecaOrigem, Peca pecaDestino, Peca peca)
    {
        this.Controls.Remove(pecaDestino.pictureBox);
        tabuleiro[peca.x, peca.y] = pecaOrigem;
        tabuleiro[_x, _y] = new CasaVazia(_x * 50, _y * 50, "casaVazia.png", enumCor.CasaVazia);
        pecaOrigem.x = peca.x;
        pecaOrigem.y = peca.y;
        pecaOrigem.pictureBox.Location = new Point(peca.x * 50, peca.y * 50);
    }

  private void AtualizarJogo()
{
    this.Refresh();
    Arquivarjogo.ApagarSave();
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            Peca p_s = tabuleiro[i, j]; // Inicialize p_s aqui
            if (p_s is not CasaVazia)
            {
                Arquivarjogo.SalvarTabuleiro(p_s);
            }
        }
    }
}


    private void ResetarSelecao()
    {
        botaoClicado = null;
        _x = -1;
        _y = -1;
    }

    public void CriarPeca(Peca peca)
    {
        tabuleiro[peca.x, peca.y] = peca;
        this.Controls.Add(peca.pictureBox);
        peca.pictureBox.BringToFront();
        peca.pictureBox.Click += (sender, args) => { cliqueNoTabuleiro(peca); };
    }

    public void InicializarTabuleiro()
{
    // Adicionando Peões
    for (int i = 0; i < 8; i++)
    {
        CriarPeca(new Peao(50 * i, 50 * 1, "peao_branco.png", enumCor.branco));
        CriarPeca(new Peao(50 * i, 50 * 6, "peao_preto.png", enumCor.Preto));
    }

    // Adicionando as peças principais
    CriarPeca(new Rei(50 * 4, 50 * 0, "rei_branco.png", enumCor.branco));
    CriarPeca(new Rainha(50 * 3, 50 * 0, "rainha_branca.png", enumCor.branco));
    CriarPeca(new Torre(50 * 0, 50 * 0, "torre_branca.png", enumCor.branco));
    CriarPeca(new Torre(50 * 7, 50 * 0, "torre_branca.png", enumCor.branco));
    CriarPeca(new Bispo(50 * 2, 50 * 0, "bispo_branco.png", enumCor.branco));
    CriarPeca(new Bispo(50 * 5, 50 * 0, "bispo_branco.png", enumCor.branco));
    
    // Adicionando os Cavalos
    CriarPeca(new Cavalo(50 * 1, 50 * 0, "cavalo_branco.png", enumCor.branco));
    CriarPeca(new Cavalo(50 * 6, 50 * 0, "cavalo_branco.png", enumCor.branco));

    // Adicionando as peças pretas
    CriarPeca(new Rei(50 * 4, 50 * 7, "rei_preto.png", enumCor.Preto));
    CriarPeca(new Rainha(50 * 3, 50 * 7, "rainha_preta.png", enumCor.Preto));
    CriarPeca(new Torre(50 * 0, 50 * 7, "torre_preta.png", enumCor.Preto));
    CriarPeca(new Torre(50 * 7, 50 * 7, "torre_preta.png", enumCor.Preto));
    CriarPeca(new Bispo(50 * 2, 50 * 7, "bispo_preto.png", enumCor.Preto));
    CriarPeca(new Bispo(50 * 5, 50 * 7, "bispo_preto.png", enumCor.Preto));

    // Adicionando os Cavalos pretos
    CriarPeca(new Cavalo(50 * 1, 50 * 7, "cavalo_preto.png", enumCor.Preto));
    CriarPeca(new Cavalo(50 * 6, 50 * 7, "cavalo_preto.png", enumCor.Preto));
}


}
