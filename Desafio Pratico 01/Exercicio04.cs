using System;

namespace Desafio_Pratico_01;

public class Exercicio04
{
    public static void Run()
    {
        Console.Write("Digite uma ou mais palavras: ");
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Entrada vazia. Digite pelo menos uma palavra.");
            Console.Write("Digite uma ou mais palavras: ");
            input = Console.ReadLine();
        }

        int quantidade = CountNonSpaceChars(input);

        Console.WriteLine();
        Console.WriteLine($"Texto: \"{input}\"");
        Console.WriteLine($"Quantidade de caracteres (ignorando espaços): {quantidade}");
    }

    private static int CountNonSpaceChars(string s)
    {
        int contador = 0;
        foreach (char ch in s)
        {
            if (!char.IsWhiteSpace(ch))
                contador++;
        }
        return contador;
    }
}