/*Classe com métodos para verificar se é um triângulo válido e calcular sua área.*/

using System;

class Triangulo
{
    private double ladoA;
    private double ladoB;
    private double ladoC;

    public Triangulo(double ladoA, double ladoB, double ladoC)
    {
        this.ladoA = ladoA;
        this.ladoB = ladoB;
        this.ladoC = ladoC;
    }

    public bool ETrianguloValido()
    {
        // A soma de dois lados de um triângulo deve ser maior que o terceiro lado
        return ladoA + ladoB > ladoC && ladoA + ladoC > ladoB && ladoB + ladoC > ladoA;
    }

    public double CalcularArea()
    {
        // Fórmula de Herão para calcular a área de um triângulo
        double semiperimetro = (ladoA + ladoB + ladoC) / 2;
        return Math.Sqrt(semiperimetro * (semiperimetro - ladoA) * (semiperimetro - ladoB) * (semiperimetro - ladoC));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao programa de cálculo de triângulos!");

        try
        {
            double ladoA = LerDouble("Digite o comprimento do lado A: ");
            double ladoB = LerDouble("Digite o comprimento do lado B: ");
            double ladoC = LerDouble("Digite o comprimento do lado C: ");

            Triangulo meuTriangulo = new Triangulo(ladoA, ladoB, ladoC);

            if (meuTriangulo.ETrianguloValido())
            {
                Console.WriteLine($"É um triângulo válido.");
                Console.WriteLine($"Área do triângulo: {meuTriangulo.CalcularArea():F2}");
            }
            else
            {
                Console.WriteLine("Não é um triângulo válido.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Por favor, digite valores numéricos válidos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }

        Console.ReadLine();
    }

    static double LerDouble(string mensagem)
    {
        double valor;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
            {
                return valor;
            }
            Console.WriteLine("Por favor, digite um valor válido maior que zero.");
        }
    }
}
