
namespace TicTacToe
{
    internal class JogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[]{'1', '2', '3', '4', '5', '6', '7', '8',  '9'};
            vez = 'X';
            quantidadePreenchida= 0;
        }

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();

            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if ( VitoriaDiagonal() || VitoriaVertical() || VitoriaHorizontal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo! Vitoria de: {vez}");
                return;
            }

            if(quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo! Empate");
            }
        }

        private bool VitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[2];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;


        }

        private bool VitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool VitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool vitoriaLinha2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return vitoriaLinha1 || vitoriaLinha2;

        }

        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha um numero de 1 a 9");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);
            
            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido, por favor digite um numero entre 1 e 9 que esteja disponivel na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            quantidadePreenchida++;

        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;

            return (posicoes[indice] != 'O' || posicaoEscolhida != 'X');
                
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";


        }

    }
}
