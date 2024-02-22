using System;

/*Classe para calcular area e perimetro do retangulo
*/
class Retangulo
{
    public double Largura
    {
        get { return largura; }
        set
        {
            if (value > 0)
                largura = value;
            else
                Console.WriteLine("A largura deve ser maior que zero.");
        }
    }

    public double Altura
    {
        get { return altura; }
        set
        {
            if (value > 0)
                altura = value;
            else
                Console.WriteLine("A altura deve ser maior que zero.");
        }
    }

    private double largura;
    private double altura;

    public Retangulo(double largura, double altura)
    {
        Largura = largura;
        Altura = altura;
    }

    public double CalcularArea()
    {
        return Largura * Altura;
    }

    public double CalcularPerimetro()
    {
        return 2 * (Largura + Altura);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Digite a largura do retângulo: ");
        double largura = LerValor();

        Console.Write("Digite a altura do retângulo: ");
        double altura = LerValor();

        Retangulo meuRetangulo = new Retangulo(largura, altura);

        Console.WriteLine($"Área do retângulo: {meuRetangulo.CalcularArea()}");

        Console.WriteLine($"Perímetro do retângulo: {meuRetangulo.CalcularPerimetro()}");

        Console.ReadLine();
    }

    static double LerValor()
    {
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.WriteLine("Por favor, digite um valor válido maior que zero.");
        }
        return valor;
    }
}
