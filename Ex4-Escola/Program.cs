using System;

/*    Classe para simular sistema de notas de uma escola para saber se o aluno está reprovado ou não
    com a opção de adicionar até mais de 10 notas.
*/
class Aluno
{
    private string nome;
    private int matricula;
    private double[] notas;

    public Aluno(string nome, int matricula, double[] notas)
    {
        this.nome = nome;
        this.matricula = matricula;
        this.notas = notas;
    }

    public double CalcularMedia()
    {
        if (notas.Length == 0)
        {
            Console.WriteLine("O aluno não possui notas.");
            return 0;
        }

        double soma = 0;
        foreach (var nota in notas)
        {
            soma += nota;
        }

        return soma / notas.Length;
    }

    public string VerificarSituacao()
    {
        double media = CalcularMedia();

        if (media >= 7.0)
        {
            return "Aprovado";
        }
        else
        {
            return "Reprovado";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao sistema de controle acadêmico!");

        string nome = SolicitarEntrada("Digite o nome do aluno: ");
        int matricula = LerInteiro("Digite a matrícula do aluno: ");

        int quantidadeNotas = LerInteiro("Digite a quantidade de notas: ");
        double[] notas = LerNotas(quantidadeNotas);

        Aluno meuAluno = new Aluno(nome, matricula, notas);

        Console.WriteLine($"Média do aluno: {meuAluno.CalcularMedia():F2}");
        Console.WriteLine($"Situação do aluno: {meuAluno.VerificarSituacao()}");

        Console.ReadLine();
    }

    static string SolicitarEntrada(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }

    static int LerInteiro(string mensagem)
    {
        int valor;
        while (!int.TryParse(SolicitarEntrada(mensagem), out valor) || valor <= 0)
        {
            Console.WriteLine("Por favor, digite um valor inteiro válido maior que zero.");
        }
        return valor;
    }

    static double[] LerNotas(int quantidade)
    {
        double[] notas = new double[quantidade];
        for (int i = 0; i < quantidade; i++)
        {
            notas[i] = LerDouble($"Digite a nota {i + 1}: ");
        }
        return notas;
    }

    static double LerDouble(string mensagem)
    {
        double valor;
        while (!double.TryParse(SolicitarEntrada(mensagem), out valor) || valor < 0 || valor > 10)
        {
            Console.WriteLine("Por favor, digite um valor válido entre 0 e 10.");
        }
        return valor;
    }
}
