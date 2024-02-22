using System;
using System.Collections.Generic;
using System.Linq;

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public Produto(int id, string nome, decimal preco, int estoque)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public override string ToString()
    {
        return $"{Id}. {Nome} - R${Preco} - Estoque: {Estoque} unidades";
    }
}

class MáquinaDeVendas
{
    private List<Produto> produtos;
    private decimal saldoUsuario;

    public MáquinaDeVendas()
    {
        produtos = new List<Produto>();
        saldoUsuario = 0;
    }

    public void CadastrarProduto(string nome, decimal preco, int estoque)
    {
        int novoId = produtos.Count + 1;
        produtos.Add(new Produto(novoId, nome, preco, estoque));
        Console.WriteLine($"Produto \"{nome}\" cadastrado com sucesso. ID: {novoId}");
    }

    public void ExibirEstoque()
    {
        if (produtos.Count > 0)
        {
            Console.WriteLine("\nEstoque disponível:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
        else
        {
            Console.WriteLine("\nNenhum produto cadastrado.");
        }
    }

    public void SelecionarProdutoPorId(int idProduto)
    {
        Produto produtoSelecionado = produtos.FirstOrDefault(p => p.Id == idProduto);

        if (produtoSelecionado != null)
        {
            Console.WriteLine($"Produto selecionado: {produtoSelecionado.Nome} - R${produtoSelecionado.Preco}");

            if (produtoSelecionado.Estoque > 0)
            {
                Console.Write("Insira o valor em dinheiro: R$");
                decimal valorInserido = LerDecimal();

                if (valorInserido >= produtoSelecionado.Preco)
                {
                    RealizarCompra(produtoSelecionado, valorInserido);
                }
                else
                {
                    Console.WriteLine("Valor inserido insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Produto fora de estoque.");
            }
        }
        else
        {
            Console.WriteLine($"Produto com ID {idProduto} não encontrado.");
        }
    }

    private void RealizarCompra(Produto produto, decimal valorInserido)
    {
        saldoUsuario += valorInserido;
        produto.Estoque--;

        decimal troco = saldoUsuario - produto.Preco;

        if (troco >= 0)
        {
            Console.WriteLine($"Compra realizada com sucesso!\nTroco: R${troco:F2}");
            saldoUsuario = 0;
        }
        else
        {
            Console.WriteLine("Valor inserido insuficiente.");
        }
    }

    public decimal LerDecimal()
    {
        decimal valor;
        while (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.WriteLine("Por favor, digite um valor válido maior ou igual a zero.");
        }
        return valor;
    }

    public int LerInteiro(string mensagem = "Digite um valor inteiro: ")
    {
        int valor;
        Console.Write(mensagem);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Por favor, digite um valor inteiro válido.");
            Console.Write(mensagem);
        }
        return valor;
    }
}

class Program
{
    static void Main()
    {
        MáquinaDeVendas máquina = new MáquinaDeVendas();

        int opcao;
        do
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Exibir Estoque");
            Console.WriteLine("2. Cadastrar Produto");
            Console.WriteLine("3. Selecionar Produto para Compra por ID");
            Console.WriteLine("0. Sair");

            opcao = máquina.LerInteiro("Digite o número da opção desejada: ");

            switch (opcao)
            {
                case 1:
                    máquina.ExibirEstoque();
                    break;
                case 2:
                    CadastrarProduto(máquina);
                    break;
                case 3:
                    máquina.ExibirEstoque();
                    int idProduto = máquina.LerInteiro("Digite o ID do produto desejado: ");
                    máquina.SelecionarProdutoPorId(idProduto);
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

    private static void CadastrarProduto(MáquinaDeVendas máquina)
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço do produto: ");
        decimal preco = máquina.LerDecimal();

        Console.Write("Digite a quantidade em estoque: ");
        int estoque = máquina.LerInteiro();

        máquina.CadastrarProduto(nome, preco, estoque);
    }
}
