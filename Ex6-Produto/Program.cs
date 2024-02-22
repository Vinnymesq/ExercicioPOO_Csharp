/*Classe com métodos para calcular o valor total em 
estoque e verificar se o produto está disponível.*/

using System;

class Produto
{
    private string nome;
    private double preco;
    private int quantidadeEmEstoque;

    public Produto(string nome, double preco, int quantidadeEmEstoque)
    {
        this.nome = nome;
        this.preco = preco;
        this.quantidadeEmEstoque = quantidadeEmEstoque;
    }

    public double CalcularValorTotalEmEstoque() => preco * quantidadeEmEstoque;

    public bool EstaDisponivel() => quantidadeEmEstoque > 0;

    public void Vender(int quantidade)
    {
        if (quantidade > 0 && quantidade <= quantidadeEmEstoque)
        {
            quantidadeEmEstoque -= quantidade;
            Console.WriteLine($"Venda realizada. {quantidade} unidades de {nome} vendidas. Estoque restante: {quantidadeEmEstoque}");
        }
        else
        {
            Console.WriteLine("Quantidade inválida ou insuficiente em estoque.");
        }
    }

    public void ReporEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            quantidadeEmEstoque += quantidade;
            Console.WriteLine($"Estoque de {nome} reposto. Estoque atual: {quantidadeEmEstoque}");
        }
        else
        {
            Console.WriteLine("Quantidade de reposição inválida.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao sistema de controle de estoque!");

        string nome = SolicitarEntrada("Digite o nome do produto: ");
        double preco = LerDouble("Digite o preço do produto: ");
        int quantidadeEmEstoque = LerInteiro("Digite a quantidade em estoque: ");

        Produto meuProduto = new Produto(nome, preco, quantidadeEmEstoque);

        ExibirInformacoesProduto(meuProduto);

        // Venda de produtos
        int quantidadeVenda = LerInteiro("Digite a quantidade de unidades a serem vendidas: ");
        meuProduto.Vender(quantidadeVenda);

        // Reposição de estoque
        int quantidadeReposicao = LerInteiro("Digite a quantidade de unidades a serem repostas no estoque: ");
        meuProduto.ReporEstoque(quantidadeReposicao);

        Console.ReadLine();
    }

    static double LerDouble(string mensagem) => LerValor<double>(mensagem);
    static int LerInteiro(string mensagem) => LerValor<int>(mensagem);

    static T LerValor<T>(string mensagem)
    {
        Console.Write(mensagem);
        while (true)
        {
            if (T.TryParse(Console.ReadLine(), out T valor))
                return valor;

            Console.WriteLine($"Por favor, digite um valor válido para {typeof(T).Name}.");
        }
    }

    static void ExibirInformacoesProduto(Produto produto)
    {
        Console.WriteLine($"Valor total em estoque: {produto.CalcularValorTotalEmEstoque():C}");
        Console.WriteLine($"O produto está disponível? {produto.EstaDisponivel()}");
    }

    static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }
}
