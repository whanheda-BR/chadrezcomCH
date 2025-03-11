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

            // Verifica se o movimento é válido
            if (!pecaOrigem.VerificarMovimento(peca.x, peca.y))
            {
                MessageBox.Show("Movimento Inválido!");
                botaoClicado = null;
                _x = -1;
                _y = -1;
                return;
            }

            if (_x == peca.x && _y == peca.y)
            {
                MessageBox.Show("Clicou no mesmo lugar!");
                botaoClicado = null;
                _x = -1;
                _y = -1;
                return;
            }

            if (pecaDestino.cor == pecaOrigem.cor)
            {
                MessageBox.Show("A peça é do mesmo time!");
                botaoClicado = null;
                _x = -1;
                _y = -1;
                return;
            }

            if (pecaDestino is CasaVazia) // Se o destino estiver vazio, apenas move a peça
            {
                // Atualiza a matriz
                // Atualiza a matriz
                tabuleiro[_x, _y] = new CasaVazia(_x * 50, _y * 50, "casaVazia.png", enumCor.CasaVazia);
                tabuleiro[peca.x, peca.y] = pecaOrigem;

                // Atualiza as coordenadas da peça movida
                pecaOrigem.x = peca.x;
                pecaOrigem.y = peca.y;

                // Atualiza a posição visualmente
                pecaOrigem.pictureBox.Location = new Point(peca.x * 50, peca.y * 50);
            }
            else // Se houver outra peça, troca as posições
            {
                // Remover peça do tabuleiro
                this.Controls.Remove(pecaDestino.pictureBox);

                // Substitui a peça no tabuleiro
                tabuleiro[peca.x, peca.y] = pecaOrigem;
                tabuleiro[_x, _y] = new CasaVazia(_x * 50, _y * 50, "casaVazia.png", enumCor.CasaVazia);

                // Atualiza a posição visualmente
                pecaOrigem.x = peca.y;
                pecaOrigem.y = peca.y;
                pecaOrigem.pictureBox.Location = new Point(peca.x * 50, peca.y * 50);

            }
            // Atualiza a interface
            this.Refresh();
            
            Arquivarjogo.ApagarSave();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Peca p_s = tabuleiro[i, j];

                    if (p_s is not CasaVazia)
                    {
                        Arquivarjogo.SalvarTabuleiro(p_s);
                    }
                }
            }
            // Reseta os valores para a próxima jogada
            botaoClicado = null;
            _x = -1;
            _y = -1;
    }
    }
    public void CriarPeca(Peca peca)
    {
        tabuleiro[peca.x, peca.y] = peca;
        this.Controls.Add(peca.pictureBox);
        peca.pictureBox.BringToFront();
        peca.pictureBox.Click += (sender, args) => { cliqueNoTabuleiro(peca); };
    }

    Peao[] PeoesBrancos = new Peao[8];
    Peao[] PeoesPretos = new Peao[8];

    public void InicializarTabuleiro()
    {
        //time branco
        for (int i = 0; i < 8; i++)
        {
            PeoesBrancos[i] = new Peao(50 * i, 50 * 1, "peao_branco.png", enumCor.branco);
            CriarPeca(PeoesBrancos[i]);
        }

        Rei reiBranco = new Rei(50 * 4, 50 * 0, "rei_branco.png", enumCor.branco);
        CriarPeca(reiBranco);

        Rainha rainhaBranca = new Rainha(50 * 3, 50 * 0, "rainha_branca.png", enumCor.branco);
        CriarPeca(rainhaBranca);

        Cavalo cavalo_branco1 = new Cavalo(50 * 1, 50 * 0, "cavalo_branco.png", enumCor.branco);
        CriarPeca(cavalo_branco1);

        Cavalo cavalo_branco2 = new Cavalo(50 * 6, 50 * 0, "cavalo_branco.png", enumCor.branco);
        CriarPeca(cavalo_branco2);

        Torre torre_branca1 = new Torre(50 * 0, 50 * 0, "torre_branca.png", enumCor.branco);
        CriarPeca(torre_branca1);

        Torre torre_branca2 = new Torre(50 * 7, 50 * 0, "torre_branca.png", enumCor.branco);
        CriarPeca(torre_branca2);

        Bispo bispo_branco1 = new Bispo(50 * 2, 50 * 0, "bispo_branco.png", enumCor.branco);
        CriarPeca(bispo_branco1);

        Bispo bispo_branco2 = new Bispo(50 * 5, 50 * 0, "bispo_branco.png", enumCor.branco);
        CriarPeca(bispo_branco2);

        //Time preto
        for (int i = 0; i < 8; i++)
        {
            PeoesPretos[i] = new Peao(50 * i, 50 * 6, "peao_preto.png", enumCor.Preto);
            CriarPeca(PeoesPretos[i]);
        }

        Rei reiPreto = new Rei(50 * 4, 50 * 7, "rei_preto.png", enumCor.Preto);
        CriarPeca(reiPreto);

        Rainha rainhaPreta = new Rainha(50 * 3, 50 * 7, "rainha_preta.png", enumCor.Preto);
        CriarPeca(rainhaPreta);

        Torre torre_preta1 = new Torre(50 * 0, 50 * 7, "torre_preta.png", enumCor.Preto);
        CriarPeca(torre_preta1);

        Torre torre_preta2 = new Torre(50 * 7, 50 * 7, "torre_preta.png", enumCor.Preto);
        CriarPeca(torre_preta2);

        Bispo bispo_preto1 = new Bispo(50 * 2, 50 * 7, "bispo_preto.png", enumCor.Preto);
        CriarPeca(bispo_preto1);

        Bispo bispo_preto2 = new Bispo(50 * 5, 50 * 7, "bispo_preto.png", enumCor.Preto);
        CriarPeca(bispo_preto2);

        Cavalo cavalo_preto1 = new Cavalo(50 * 1, 50 * 7, "cavalo_preto.png", enumCor.Preto);
        CriarPeca(cavalo_preto1);

        Cavalo cavalo_preto2 = new Cavalo(50 * 6, 50 * 7, "cavalo_preto.png", enumCor.Preto);
        CriarPeca(cavalo_preto2);

    }
}

