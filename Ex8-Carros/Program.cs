/*Classe com métodos para acelerar, frear e exibir a velocidade 
atual.*/

using System;

class Carro
{
    private string marca;
    private string modelo;
    private double velocidadeAtual;

    public Carro(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.velocidadeAtual = 0.0;
    }

    public void Acelerar(double aceleracao)
    {
        if (aceleracao < 0)
        {
            Console.WriteLine("A aceleração deve ser um valor positivo.");
            return;
        }

        velocidadeAtual += aceleracao;
        Console.WriteLine($"{marca} {modelo} acelerou para {velocidadeAtual} km/h.");
    }

    public void Frear(double frenagem)
    {
        if (frenagem < 0 || frenagem > velocidadeAtual)
        {
            Console.WriteLine("A frenagem deve ser um valor positivo e não pode ser maior que a velocidade atual.");
            return;
        }

        velocidadeAtual -= frenagem;
        Console.WriteLine($"{marca} {modelo} freou para {velocidadeAtual} km/h.");
    }

    public void ExibirVelocidadeAtual()
    {
        Console.WriteLine($"{marca} {modelo} está a {velocidadeAtual} km/h.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao programa de controle de carros!");

        string marca = SolicitarEntrada("Digite a marca do carro: ");
        string modelo = SolicitarEntrada("Digite o modelo do carro: ");

        Carro meuCarro = new Carro(marca, modelo);

        meuCarro.ExibirVelocidadeAtual(); // Exibe a velocidade inicial (0 km/h)

        double aceleracao = LerDouble("Digite a aceleração desejada: ");
        meuCarro.Acelerar(aceleracao);

        double frenagem = LerDouble("Digite a frenagem desejada: ");
        meuCarro.Frear(frenagem);

        meuCarro.ExibirVelocidadeAtual(); // Exibe a velocidade atual após as operações

        Console.ReadLine();
    }

    static double LerDouble(string mensagem)
    {
        double valor;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
            {
                return valor;
            }
            Console.WriteLine("Por favor, digite um valor válido maior ou igual a zero.");
        }
    }

    static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }
}
