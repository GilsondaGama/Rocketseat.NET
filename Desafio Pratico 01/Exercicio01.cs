namespace Desafio_Pratico_01;

public class Exercicio01
{
    public static void Run()
    {
        Console.Write("Digite seu nome: ");
        string? nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
            Console.WriteLine("Nome não informado. Seja muito bem-vindo!");
        else
            Console.WriteLine($"Olá, {nome}! Seja muito bem-vindo!");
    }
}