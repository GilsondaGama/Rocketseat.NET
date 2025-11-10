using System;
using System.Text.RegularExpressions;

namespace Desafio_Pratico_01;

public class Exercicio05
{
    public static void Run()
    {
        Console.Write("Digite a placa do veículo (formato ABC1234): ");
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Entrada vazia. Tente novamente.");
            Console.Write("Digite a placa do veículo (formato ABC1234): ");
            input = Console.ReadLine();
        }

        // Remove espaços acidentais e verifica
        string placa = input.Trim().Replace(" ", "");
        bool valido = IsValidBrazilianPlatePre2018(placa);

        Console.WriteLine(valido ? "Verdadeiro" : "Falso");
    }

    private static bool IsValidBrazilianPlatePre2018(string placa)
    {
        if (placa.Length != 7)
            return false;

        // 3 letras (A-Z ou a-z) seguidas por 4 dígitos
        return Regex.IsMatch(placa, @"^[A-Za-z]{3}\d{4}$");
    }
}