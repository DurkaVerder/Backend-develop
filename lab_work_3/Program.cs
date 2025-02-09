using Microsoft.Extensions.DependencyInjection;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculatorService, CalculatorService>() // Добавление сервиса CalculatorService
            .AddTransient<IMessageService, MessageService>() // Добавление сервиса MessageService
            .BuildServiceProvider();

        // Тест сервиса CalculatorService
        var calculatorService = serviceProvider.GetService<ICalculatorService>();
        Console.WriteLine("Первый сервис: " + calculatorService?.GetType().Name);
        Console.WriteLine("Введите два числа:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Результат: " + calculatorService?.Add(a, b));
        Console.WriteLine();

        // Тест сервиса MessageService
        var messageService = serviceProvider.GetService<IMessageService>();
        Console.WriteLine("Второй сервис: " + messageService?.GetType().Name);
        messageService?.GetMessage("Hello World");
        Console.WriteLine();
    }
}

public interface IMessageService
{
    void GetMessage(string message);
}   

public class MessageService : IMessageService
{
    public void GetMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public interface ICalculatorService
{
    int Add(int a, int b);
}

public class CalculatorService : ICalculatorService
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}