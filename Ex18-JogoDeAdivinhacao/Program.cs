using System;

class Program
{
    static void Main()
    {
        JogoAdivinhacao jogo = new JogoAdivinhacao();
        jogo.IniciarJogo();

        while (!jogo.JogoEncerrado)
        {
            Console.Write("Digite seu palpite: ");
            string palpiteStr = Console.ReadLine();

            if (int.TryParse(palpiteStr, out int palpite))
            {
                jogo.VerificarPalpite(palpite);
            }
            else
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }
        }

        Console.ReadLine();
    }
}

class JogoAdivinhacao
{
    private int numeroSecreto;
    private bool jogoEncerrado;

    public bool JogoEncerrado
    {
        get { return jogoEncerrado; }
    }

    public void IniciarJogo()
    {
        Random random = new Random();
        numeroSecreto = random.Next(1, 101);
        jogoEncerrado = false;

        Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
        Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100.");
    }

    public void VerificarPalpite(int palpite)
    {
        if (!jogoEncerrado)
        {
            if (palpite == numeroSecreto)
            {
                Console.WriteLine("Parabéns! Você acertou o número secreto.");
                jogoEncerrado = true;
            }
            else if (palpite < numeroSecreto)
            {
                Console.WriteLine("O número secreto é maior. Tente novamente.");
            }
            else
            {
                Console.WriteLine("O número secreto é menor. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("O jogo já foi encerrado. Reinicie o jogo para jogar novamente.");
        }
    }
}
