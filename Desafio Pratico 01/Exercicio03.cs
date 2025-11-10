using System;
using System.Globalization;

namespace Desafio_Pratico_01;

public class Exercicio03
{
    public static void Run()
    {
        double num1 = ReadDouble("Digite o primeiro valor: ");
        double num2 = ReadDouble("Digite o segundo valor: ");

        double soma = num1 + num2;
        double subtracao = num1 - num2;
        double multiplicacao = num1 * num2;
        string divisao = num2 == 0
            ? "Impossível dividir por zero"
            : (num1 / num2).ToString(CultureInfo.InvariantCulture);
        double media = (num1 + num2) / 2.0;

        Console.WriteLine();
        Console.WriteLine($"Valores: {num1.ToString(CultureInfo.InvariantCulture)} e {num2.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Soma: {soma.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Subtração: {subtracao.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Multiplicação: {multiplicacao.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Divisão: {divisao}");
        Console.WriteLine($"Média: {media.ToString(CultureInfo.InvariantCulture)}");
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada vazia. Tente novamente.");
                continue;
            }

            // Normaliza vírgula para ponto e usa InvariantCulture para garantir '.' como separador
            input = input.Trim().Replace(',', '.');

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                return value;

            Console.WriteLine("Valor inválido. Digite um número (ex: 3.14).");
        }
    }
}