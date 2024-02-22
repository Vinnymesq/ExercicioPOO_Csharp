/*Classe com funcionalidades para cadastrar produtos, gerar carrinho de 
compras, aplicar descontos e calcular o valor total da compra.*/


using System;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

class ItemCompra
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public ItemCompra(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }
}

class CarrinhoCompra
{
    private List<ItemCompra> itens;

    public CarrinhoCompra()
    {
        itens = new List<ItemCompra>();
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        itens.Add(new ItemCompra(produto, quantidade));
    }

    public double CalcularValorTotal()
    {
        double valorTotal = 0;
        foreach (var item in itens)
        {
            valorTotal += item.Produto.Preco * item.Quantidade;
        }
        return valorTotal;
    }
}

class LojaVirtual
{
    private List<Produto> produtos;

    public LojaVirtual()
    {
        produtos = new List<Produto>();
    }

    public void CadastrarProduto(string nome, double preco)
    {
        produtos.Add(new Produto(nome, preco));
        Console.WriteLine($"Produto \"{nome}\" cadastrado com sucesso.");
    }

    public List<Produto> ObterProdutos()
    {
        return produtos;
    }

    public void AplicarDesconto(CarrinhoCompra carrinho, double percentualDesconto)
    {
        if (percentualDesconto >= 0 && percentualDesconto <= 100)
        {
            double valorDesconto = carrinho.CalcularValorTotal() * (percentualDesconto / 100);
            Console.WriteLine($"Desconto de {percentualDesconto}% aplicado. Valor do desconto: {valorDesconto:C}");
        }
        else
        {
            Console.WriteLine("Percentual de desconto inválido. O desconto deve ser entre 0% e 100%.");
        }
    }
}

class Program
{
    static void Main()
    {
        LojaVirtual minhaLoja = new LojaVirtual();

        Console.WriteLine("Bem-vindo à Loja Virtual!");

        // Cadastrar produtos
        minhaLoja.CadastrarProduto("Celular", 1000.00);
        minhaLoja.CadastrarProduto("Notebook", 2000.00);

        // Exibir produtos disponíveis
        Console.WriteLine("\nProdutos disponíveis:");

        foreach (var produto in minhaLoja.ObterProdutos())
        {
            Console.WriteLine($"{produto.Nome} - {produto.Preco:C}");
        }

        // Criar carrinho de compras
        CarrinhoCompra meuCarrinho = new CarrinhoCompra();

        // Adicionar itens ao carrinho com base nos produtos disponíveis
        Console.WriteLine("\nAdicione produtos ao carrinho:");
        foreach (var produto in minhaLoja.ObterProdutos())
        {
            int quantidade = LerInteiro($"Quantidade de {produto.Nome}: ");
            meuCarrinho.AdicionarItem(produto, quantidade);
        }

        // Exibir valor total do carrinho
        Console.WriteLine($"\nValor total do carrinho: {meuCarrinho.CalcularValorTotal():C}");

        // Aplicar desconto
        double percentualDesconto = LerDouble("\nDigite o percentual de desconto a ser aplicado: ");
        minhaLoja.AplicarDesconto(meuCarrinho, percentualDesconto);

        // Exibir valor total do carrinho após desconto
        Console.WriteLine($"Valor total do carrinho após desconto: {meuCarrinho.CalcularValorTotal():C}");

        Console.ReadLine();
    }

    static int LerInteiro(string mensagem)
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

    static double LerDouble(string mensagem)
    {
        double valor;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }
            Console.WriteLine("Por favor, digite um valor numérico válido.");
        }
    }
}

