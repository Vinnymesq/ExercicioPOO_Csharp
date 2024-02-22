using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        JogoDeCartas jogo = new JogoDeCartas();
        jogo.EmbaralharEDistribuirCartas(); // Adicionado para embaralhar e distribuir as cartas
        jogo.IniciarJogo();

        while (!jogo.FimDeJogo())
        {
            Console.WriteLine("\n--- Nova Rodada ---");
            jogo.JogarRodada();
        }

        Console.WriteLine("\n--- Fim de Jogo ---");
        jogo.DeclararVencedor();
    }
}

class JogoDeCartas
{
    private List<Carta> baralho;
    private List<Carta> maoJogador1;
    private List<Carta> maoJogador2;

    public void EmbaralharEDistribuirCartas()
    {
        baralho = CriarBaralhoEmbaralhado();
        maoJogador1 = new List<Carta>();
        maoJogador2 = new List<Carta>();

        for (int i = 0; i < baralho.Count; i++)
        {
            if (i % 2 == 0)
                maoJogador1.Add(baralho[i]);
            else
                maoJogador2.Add(baralho[i]);
        }
    }

    public void IniciarJogo()
    {
        // Não é mais necessário distribuir as cartas aqui, pois isso é feito em EmbaralharEDistribuirCartas()
    }

    public void JogarRodada()
    {
        MostrarMao();

        Carta cartaJogador1 = EscolherCarta(1);
        Carta cartaJogador2 = EscolherCarta(2);

        Console.WriteLine($"Jogador 1 jogou: {cartaJogador1}");
        Console.WriteLine($"Jogador 2 jogou: {cartaJogador2}");

        if (cartaJogador1.Valor > cartaJogador2.Valor)
        {
            Console.WriteLine("Jogador 1 venceu a rodada!");
            maoJogador1.Add(cartaJogador1);
            maoJogador1.Add(cartaJogador2);
        }
        else if (cartaJogador1.Valor < cartaJogador2.Valor)
        {
            Console.WriteLine("Jogador 2 venceu a rodada!");
            maoJogador2.Add(cartaJogador1);
            maoJogador2.Add(cartaJogador2);
        }
        else
        {
            Console.WriteLine("Empate! As cartas retornam ao baralho.");
        }
    }

    public bool FimDeJogo()
    {
        return maoJogador1.Count == 0 || maoJogador2.Count == 0;
    }

    public void DeclararVencedor()
    {
        if (maoJogador1.Count > maoJogador2.Count)
            Console.WriteLine("Jogador 1 venceu o jogo!");
        else if (maoJogador1.Count < maoJogador2.Count)
            Console.WriteLine("Jogador 2 venceu o jogo!");
        else
            Console.WriteLine("O jogo terminou em empate!");
    }

    private List<Carta> CriarBaralhoEmbaralhado()
    {
        List<Carta> baralho = new List<Carta>();
        for (int i = 2; i <= 14; i++)
        {
            foreach (Naipe naipe in Enum.GetValues(typeof(Naipe)))
            {
                baralho.Add(new Carta(i, naipe));
            }
        }
        return baralho.OrderBy(carta => Guid.NewGuid()).ToList(); // Embaralhar o baralho
    }

    private void MostrarMao()
    {
        Console.WriteLine("Cartas do Jogador 1: " + string.Join(", ", maoJogador1));
        Console.WriteLine("Cartas do Jogador 2: " + string.Join(", ", maoJogador2));
    }

    private Carta EscolherCarta(int jogador)
    {
        List<Carta> maoAtual = jogador == 1 ? maoJogador1 : maoJogador2;

        Console.Write($"Jogador {jogador}, escolha uma carta (1-{maoAtual.Count}): ");
        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maoAtual.Count)
        {
            Console.Write("Escolha inválida. Tente novamente: ");
        }

        Carta cartaEscolhida = maoAtual[escolha - 1];
        maoAtual.RemoveAt(escolha - 1);

        return cartaEscolhida;
    }
}

enum Naipe
{
    Copas,
    Ouros,
    Espadas,
    Paus
}

class Carta
{
    public int Valor { get; }
    public Naipe Naipe { get; }

    public Carta(int valor, Naipe naipe)
    {
        Valor = valor;
        Naipe = naipe;
    }

    public override string ToString()
    {
        string valorCarta;
        switch (Valor)
        {
            case 11:
                valorCarta = "J";
                break;
            case 12:
                valorCarta = "Q";
                break;
            case 13:
                valorCarta = "K";
                break;
            case 14:
                valorCarta = "A";
                break;
            default:
                valorCarta = Valor.ToString();
                break;
        }

        return $"{valorCarta} de {Naipe}";
    }
}
