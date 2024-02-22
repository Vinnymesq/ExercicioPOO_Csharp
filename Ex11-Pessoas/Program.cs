/*Classe com métodos para calcular a idade em anos bissextos e exibir 
informações da pessoa.*/

using System;

class Pessoa
{
    private string nome;
    private int idade;
    private string profissao;

    public Pessoa(string nome, int idade, string profissao)
    {
        this.nome = nome;
        this.idade = idade;
        this.profissao = profissao;
    }

    public int CalcularIdadeEmAnosBissextos(int anoAtual)
    {
        int anoNascimento = anoAtual - idade;
        int anosBissextos = 0;
        for (int ano = anoNascimento; ano <= anoAtual; ano++)
        {
            if (DateTime.IsLeapYear(ano))
            {
                anosBissextos++;
            }
        }
        return idade + anosBissextos;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Idade: {idade} anos");
        Console.WriteLine($"Profissão: {profissao}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Informe os dados da pessoa:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Idade: ");
        int idade = LerInteiro("Digite um valor válido para a idade: ");

        Console.Write("Profissão: ");
        string profissao = Console.ReadLine();

        Pessoa pessoa = new Pessoa(nome, idade, profissao);

        Console.WriteLine("\nInformações da pessoa:");
        pessoa.ExibirInformacoes();

        Console.Write("\nDigite o ano atual para calcular a idade em anos bissextos: ");
        int anoAtual = LerInteiro("Digite um valor válido para o ano atual: ");

        int idadeEmAnosBissextos = pessoa.CalcularIdadeEmAnosBissextos(anoAtual);
        Console.WriteLine($"\nA idade em anos bissextos é: {idadeEmAnosBissextos} anos");

        Console.ReadLine();
    }

    static int LerInteiro(string mensagem)
    {
        int valor;
        while (!int.TryParse(SolicitarEntrada(mensagem), out valor))
        {
            Console.WriteLine("Por favor, digite um valor inteiro válido.");
        }
        return valor;
    }

    static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }
}
