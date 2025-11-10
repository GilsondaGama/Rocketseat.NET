namespace Desafio_Pratico_01;

public class Exercicio02
{
    public static void Run()
    {
        Console.Write("Digite seu nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Digite seu sobrenome: ");
        string? sobreNome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(sobreNome))
            Console.WriteLine("Nome ou Sobrenome não informado. Seja muito bem-vindo!");
        else
            Console.WriteLine($"Olá, {nome} {sobreNome}! Seja muito bem-vindo!");
    }
}