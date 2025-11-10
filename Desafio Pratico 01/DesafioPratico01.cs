using System;
using Desafio_Pratico_01;

Console.WriteLine("Escolha o exercício para executar:");
Console.WriteLine("1 - Exercicio 01");
Console.WriteLine("2 - Exercicio 02");
Console.WriteLine("3 - Exercicio 03");
Console.WriteLine("4 - Exercicio 04");
Console.WriteLine("5 - Exercicio 05");
Console.WriteLine("6 - Exercicio 06");
Console.Write("Opção: ");
var opcao = Console.ReadLine();

switch (opcao)
{
    case "1":
        Exercicio01.Run();
        break;
    case "2":
        Exercicio02.Run();
        break;
    case "3":
        Exercicio03.Run();
        break;
    case "4":
        Exercicio04.Run();
        break;
    case "5":
        Exercicio05.Run();
        break;
    case "6":
        Exercicio06.Run();
        break;
    default:
        Console.WriteLine("Opção inválida.");
        break;
}