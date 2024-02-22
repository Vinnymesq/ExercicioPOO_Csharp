using System;

class Program
{
    static void Main()
    {
        Calendario calendario = new Calendario();

        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());

        Console.Write("Digite o número do mês (1 a 12): ");
        int mes = int.Parse(Console.ReadLine());

        calendario.ExibirCalendario(ano, mes);

        Console.Write("Digite uma data no formato (dd/MM/yyyy) para verificar se é feriado: ");
        DateTime dataVerificar = DateTime.Parse(Console.ReadLine());

        if (calendario.VerificarFeriado(dataVerificar))
        {
            Console.WriteLine($"{dataVerificar.ToShortDateString()} é feriado!");
        }
        else
        {
            Console.WriteLine($"{dataVerificar.ToShortDateString()} não é feriado.");
        }

        Console.Write("Digite a data inicial no formato (dd/MM/yyyy) para calcular a diferença de dias: ");
        DateTime dataInicial = DateTime.Parse(Console.ReadLine());

        Console.Write("Digite a data final no formato (dd/MM/yyyy): ");
        DateTime dataFinal = DateTime.Parse(Console.ReadLine());

        int diferencaDias = calendario.CalcularDiferencaDias(dataInicial, dataFinal);
        Console.WriteLine($"A diferença de dias entre {dataInicial.ToShortDateString()} e {dataFinal.ToShortDateString()} é de {diferencaDias} dias.");

        Console.ReadLine();
    }
}

class Calendario
{
    public void ExibirCalendario(int ano, int mes)
    {
        Console.WriteLine($"Calendário de {GetNomeMes(mes)} de {ano}:");

        int diasNoMes = DateTime.DaysInMonth(ano, mes);
        DateTime primeiroDia = new DateTime(ano, mes, 1);
        DayOfWeek diaDaSemana = primeiroDia.DayOfWeek;

        Console.WriteLine("Dom Seg Ter Qua Qui Sex Sab");

        for (int i = 0; i < (int)diaDaSemana; i++)
        {
            Console.Write("    ");
        }

        for (int dia = 1; dia <= diasNoMes; dia++)
        {
            Console.Write($"{dia,3}");

            if (diaDaSemana == DayOfWeek.Saturday)
            {
                Console.WriteLine();
            }

            diaDaSemana = (DayOfWeek)(((int)diaDaSemana + 1) % 7);
        }

        Console.WriteLine();
    }

    public bool VerificarFeriado(DateTime data)
    {
        // Adicione aqui a lógica para verificar se a data é feriado
        // Neste exemplo, consideraremos apenas o Natal como feriado
        return data.Month == 12 && data.Day == 25;
    }

    public int CalcularDiferencaDias(DateTime dataInicial, DateTime dataFinal)
    {
        TimeSpan diferenca = dataFinal - dataInicial;
        return diferenca.Days;
    }

    private string GetNomeMes(int mes)
    {
        return new DateTime(1, mes, 1).ToString("MMMM");
    }
}
