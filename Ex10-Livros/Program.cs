/*Classe com métodos para emprestar o livro, devolvê-lo e 
verificar se está disponível.*/
using System;
using System.Collections.Generic;

class Livro
{
    private string titulo;
    private string autor;
    private int numeroPaginas;
    private bool disponivel;

    public Livro(string titulo, string autor, int numeroPaginas)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.numeroPaginas = numeroPaginas;
        this.disponivel = true; // Quando criado, o livro está disponível para empréstimo
    }

    public void Emprestar()
    {
        if (disponivel)
        {
            Console.WriteLine($"Livro \"{titulo}\" emprestado.");
            disponivel = false;
        }
        else
        {
            Console.WriteLine($"Desculpe, o livro \"{titulo}\" não está disponível no momento.");
        }
    }

    public void Devolver()
    {
        if (!disponivel)
        {
            Console.WriteLine($"Livro \"{titulo}\" devolvido com sucesso.");
            disponivel = true;
        }
        else
        {
            Console.WriteLine($"O livro \"{titulo}\" já está disponível. Não pode ser devolvido.");
        }
    }

    public bool EstaDisponivel()
    {
        return disponivel;
    }

    public override string ToString()
    {
        return $"Livro: {titulo}\nAutor: {autor}\nPáginas: {numeroPaginas}\nDisponível: {(disponivel ? "Sim" : "Não")}";
    }
}

class Biblioteca
{
    private List<Livro> livros;

    public Biblioteca()
    {
        this.livros = new List<Livro>();
    }

    public void AdicionarLivro(string titulo, string autor, int numeroPaginas)
    {
        Livro novoLivro = new Livro(titulo, autor, numeroPaginas);
        livros.Add(novoLivro);
        Console.WriteLine($"Livro \"{titulo}\" adicionado à biblioteca.");
    }

    public void MostrarLivros()
    {
        Console.WriteLine("\nLivros na Biblioteca:");
        if (livros.Count > 0)
        {
            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {livros[i]}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro na biblioteca.");
        }
    }

    public int ObterNumeroLivros()
    {
        return livros.Count;
    }

    public void EmprestarLivro(int indiceLivro)
    {
        if (indiceLivro >= 0 && indiceLivro < livros.Count)
        {
            Livro livroSelecionado = livros[indiceLivro];
            if (livroSelecionado.EstaDisponivel())
            {
                livroSelecionado.Emprestar();
            }
            else
            {
                Console.WriteLine($"Desculpe, o livro \"{livroSelecionado}\" não está disponível no momento.");
            }
        }
        else
        {
            Console.WriteLine("Índice do livro inválido.");
        }
    }

    public void DevolverLivro(int indiceLivro)
    {
        if (indiceLivro >= 0 && indiceLivro < livros.Count)
        {
            Livro livroSelecionado = livros[indiceLivro];
            if (!livroSelecionado.EstaDisponivel())
            {
                livroSelecionado.Devolver();
            }
            else
            {
                Console.WriteLine($"O livro \"{livroSelecionado}\" já está disponível. Não pode ser devolvido.");
            }
        }
        else
        {
            Console.WriteLine("Índice do livro inválido.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo à Biblioteca Virtual!");

        Biblioteca minhaBiblioteca = new Biblioteca();

        int escolha;
        do
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Adicionar novo livro");
            Console.WriteLine("2. Ver detalhes dos livros na biblioteca");
            Console.WriteLine("3. Emprestar um livro");
            Console.WriteLine("4. Devolver um livro");
            Console.WriteLine("0. Sair");

            escolha = LerInteiro("Digite o número da opção desejada: ");

            switch (escolha)
            {
                case 1:
                    AdicionarLivro(minhaBiblioteca);
                    break;
                case 2:
                    minhaBiblioteca.MostrarLivros();
                    break;
                case 3:
                    EmprestarLivro(minhaBiblioteca);
                    break;
                case 4:
                    DevolverLivro(minhaBiblioteca);
                    break;
                case 0:
                    Console.WriteLine("Programa encerrado.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (escolha != 0);
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

    private static void AdicionarLivro(Biblioteca biblioteca)
    {
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();

        int numeroPaginas = LerInteiro("Digite o número de páginas do livro: ");

        biblioteca.AdicionarLivro(titulo, autor, numeroPaginas);
    }

    private static void EmprestarLivro(Biblioteca biblioteca)
    {
        biblioteca.MostrarLivros();

        int indiceLivro = LerInteiro("Digite o número do livro que deseja emprestar: ");
        if (indiceLivro >= 1 && indiceLivro <= biblioteca.ObterNumeroLivros())
        {
            biblioteca.EmprestarLivro(indiceLivro - 1);
        }
        else
        {
            Console.WriteLine("Índice do livro inválido.");
        }
    }

    private static void DevolverLivro(Biblioteca biblioteca)
    {
        biblioteca.MostrarLivros();

        int indiceLivro = LerInteiro("Digite o número do livro que deseja devolver: ");
        if (indiceLivro >= 1 && indiceLivro <= biblioteca.ObterNumeroLivros())
        {
            biblioteca.DevolverLivro(indiceLivro - 1);
        }
        else
        {
            Console.WriteLine("Índice do livro inválido.");
        }
    }
}
