using System;
using System.Globalization;

namespace Desafio_Pratico_01;

public class Exercicio06
{
    public static void Run()
    {
        DateTime agora = DateTime.Now;
        var pt = new CultureInfo("pt-BR");

        Console.WriteLine("Escolha o formato a exibir:");
        Console.WriteLine("1 - Formato completo (dia da semana, dia, mês, ano, hora, minutos, segundos)");
        Console.WriteLine("2 - Apenas a data (dd/MM/yyyy)");
        Console.WriteLine("3 - Apenas a hora (formato 24 horas)");
        Console.WriteLine("4 - Data com mês por extenso");
        Console.WriteLine("5 - Exibir todos");
        Console.Write("Opção (1-5): ");

        string? opcao = Console.ReadLine()?.Trim() ?? "5";

        switch (opcao)
        {
            case "1":
                // Ex.: "sexta-feira, 07 de novembro de 2025 14:05:09"
                Console.WriteLine(agora.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss", pt));
                break;
            case "2":
                // Ex.: "07/11/2025"
                Console.WriteLine(agora.ToString("dd/MM/yyyy", pt));
                break;
            case "3":
                // Ex.: "14:05:09"
                Console.WriteLine(agora.ToString("HH:mm:ss", pt));
                break;
            case "4":
                // Ex.: "07 de novembro de 2025"
                Console.WriteLine(agora.ToString("dd 'de' MMMM 'de' yyyy", pt));
                break;
            default:
                Console.WriteLine("Formato completo: " + agora.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss", pt));
                Console.WriteLine("Data (dd/MM/yyyy): " + agora.ToString("dd/MM/yyyy", pt));
                Console.WriteLine("Hora (24h): " + agora.ToString("HH:mm:ss", pt));
                Console.WriteLine("Data com mês por extenso: " + agora.ToString("dd 'de' MMMM 'de' yyyy", pt));
                break;
        }
    }
}