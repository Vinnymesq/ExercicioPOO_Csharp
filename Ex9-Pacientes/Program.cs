/*Classe com métodos para adicionar uma nova 
consulta ao histórico e exibir as consultas realizadas.*/
using System;
using System.Collections.Generic;

class Consulta
{
    public DateTime Data { get; }
    public string Descricao { get; }

    public Consulta(string descricao)
    {
        Data = DateTime.Now;
        Descricao = descricao;
    }

    public override string ToString()
    {
        return $"{Data} - {Descricao}";
    }
}

class Paciente
{
    private string nome;
    private int idade;
    private List<Consulta> historicoConsultas;

    public Paciente(string nome, int idade)
    {
        this.nome = nome;
        this.idade = idade;
        this.historicoConsultas = new List<Consulta>();
    }

    public void MarcarConsulta()
    {
        string descricaoConsulta = SolicitarEntrada("Digite a descrição da consulta: ");
        Consulta novaConsulta = new Consulta(descricaoConsulta);
        historicoConsultas.Add(novaConsulta);
        Console.WriteLine($"Consulta marcada para {nome}.");
    }

    public void ExibirConsultas()
    {
        Console.WriteLine($"Histórico de consultas de {nome}:");
        if (historicoConsultas.Count > 0)
        {
            foreach (var consulta in historicoConsultas)
            {
                Console.WriteLine(consulta);
            }
        }
        else
        {
            Console.WriteLine("Nenhuma consulta registrada.");
        }
    }

    private static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }

    private static int SolicitarEntradaInteira(string mensagem)
    {
        int valor;
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }
            Console.WriteLine("Por favor, digite um valor inteiro válido.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao programa de controle de pacientes!");

        string nome = SolicitarEntrada("Digite o nome do paciente: ");
        int idade = SolicitarEntradaInteira("Digite a idade do paciente: ");

        Paciente meuPaciente = new Paciente(nome, idade);

        int opcao;
        do
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Marcar Consulta");
            Console.WriteLine("2. Exibir Consultas");
            Console.WriteLine("0. Sair");
            opcao = SolicitarEntradaInteira("Digite o número da opção desejada: ");

            switch (opcao)
            {
                case 1:
                    meuPaciente.MarcarConsulta();
                    break;
                case 2:
                    meuPaciente.ExibirConsultas();
                    break;
                case 0:
                    Console.WriteLine("Programa encerrado.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 0);
    }

    private static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }

    private static int SolicitarEntradaInteira(string mensagem)
    {
        int valor;
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }
            Console.WriteLine("Por favor, digite um valor inteiro válido.");
        }
    }
}
