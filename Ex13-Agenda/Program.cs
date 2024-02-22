/*classe que permite adicionar, editar e remover contatos, além de buscar por 
contatos a partir de um nome ou número de telefone*/


using System;
using System.Collections.Generic;
using System.Linq;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public Contato(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"{Nome}: {Telefone}";
    }
}

class Agenda
{
    private List<Contato> contatos;

    public Agenda()
    {
        contatos = new List<Contato>();
    }

    public void AdicionarContato()
    {
        Console.Write("Digite o nome do contato: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone do contato: ");
        string telefone = Console.ReadLine();

        contatos.Add(new Contato(nome, telefone));
        Console.WriteLine($"Contato {nome} adicionado com sucesso.");
    }

    public void EditarContato()
    {
        Console.Write("Digite o nome do contato que deseja editar: ");
        string nome = Console.ReadLine();

        Contato contato = BuscarContatoPorNome(nome);

        if (contato != null)
        {
            Console.Write("Digite o novo telefone: ");
            string novoTelefone = Console.ReadLine();

            contato.Telefone = novoTelefone;
            Console.WriteLine($"Contato {nome} editado com sucesso. Novo telefone: {novoTelefone}");
        }
        else
        {
            Console.WriteLine($"Contato {nome} não encontrado.");
        }
    }

    public void RemoverContato()
    {
        Console.Write("Digite o nome do contato que deseja remover: ");
        string nome = Console.ReadLine();

        Contato contato = BuscarContatoPorNome(nome);

        if (contato != null)
        {
            contatos.Remove(contato);
            Console.WriteLine($"Contato {nome} removido com sucesso.");
        }
        else
        {
            Console.WriteLine($"Contato {nome} não encontrado.");
        }
    }

    public void BuscarContato()
    {
        Console.Write("Digite o nome do contato que deseja buscar: ");
        string nome = Console.ReadLine();

        Contato contato = BuscarContatoPorNome(nome);

        if (contato != null)
        {
            Console.WriteLine($"Contato encontrado: {contato}");
        }
        else
        {
            Console.WriteLine($"Contato {nome} não encontrado.");
        }
    }

    private Contato BuscarContatoPorNome(string nome)
    {
        return contatos.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public void ExibirContatos()
    {
        if (contatos.Count > 0)
        {
            Console.WriteLine("\nLista de Contatos:");
            foreach (var contato in contatos)
            {
                Console.WriteLine(contato);
            }
        }
        else
        {
            Console.WriteLine("\nNenhum contato na agenda.");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda minhaAgenda = new Agenda();

        int opcao;
        do
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Adicionar Contato");
            Console.WriteLine("2. Editar Contato");
            Console.WriteLine("3. Remover Contato");
            Console.WriteLine("4. Buscar Contato");
            Console.WriteLine("5. Exibir Contatos");
            Console.WriteLine("0. Sair");

            opcao = LerInteiro("Digite o número da opção desejada: ");

            switch (opcao)
            {
                case 1:
                    minhaAgenda.AdicionarContato();
                    break;
                case 2:
                    minhaAgenda.EditarContato();
                    break;
                case 3:
                    minhaAgenda.RemoverContato();
                    break;
                case 4:
                    minhaAgenda.BuscarContato();
                    break;
                case 5:
                    minhaAgenda.ExibirContatos();
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

    private static int LerInteiro(string mensagem)
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
