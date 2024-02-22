/*Classe com métodos para calcular o salário líquido, considerando 
descontos de impostos e benefícios.*/

using System;

class Funcionario
{
    private const double TaxaImpostoPadrao = 0.1;
    private const double TaxaBeneficioPadrao = 0.05;

    private string nome;
    private double salario;
    private string cargo;

    public Funcionario(string nome, double salario, string cargo)
    {
        this.nome = nome;
        this.salario = salario;
        this.cargo = cargo;
    }

    public double CalcularSalarioLiquido(double taxaImposto = TaxaImpostoPadrao, double taxaBeneficio = TaxaBeneficioPadrao)
    {
        double descontoImposto = salario * taxaImposto;
        double beneficio = salario * taxaBeneficio;

        double salarioLiquido = salario - descontoImposto + beneficio;
        return salarioLiquido;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cargo: {cargo}");
        Console.WriteLine($"Salário Bruto: {salario:C}");
        Console.WriteLine($"Salário Líquido: {CalcularSalarioLiquido():C}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao sistema de gestão de funcionários!");

        string nome = SolicitarEntrada("Digite o nome do funcionário: ");

        double salario = LerDouble("Digite o salário do funcionário: ");

        string cargo = SolicitarEntrada("Digite o cargo do funcionário: ");

        Funcionario meuFuncionario = new Funcionario(nome, salario, cargo);

        Console.Write("Deseja personalizar as taxas de imposto e benefício? (S/N): ");
        if (Console.ReadLine().ToUpper() == "S")
        {
            double taxaImposto = LerDouble("Digite a taxa de imposto (porcentagem): ") / 100.0;
            double taxaBeneficio = LerDouble("Digite a taxa de benefício (porcentagem): ") / 100.0;

            Console.WriteLine($"Salário Líquido Personalizado: {meuFuncionario.CalcularSalarioLiquido(taxaImposto, taxaBeneficio):C}");
        }
        else
        {
            meuFuncionario.ExibirInformacoes();
        }

        Console.ReadLine();
    }

    static double LerDouble(string mensagem)
    {
        double valor;
        while (!double.TryParse(SolicitarEntrada(mensagem), out valor) || valor < 0)
        {
            Console.WriteLine("Por favor, digite um valor válido maior ou igual a zero.");
        }
        return valor;
    }

    static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }
}
