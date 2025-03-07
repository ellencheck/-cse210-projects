using System;

class Program
{
    static void Main(string[] args)
    {
        // Вызов DisplayWelcome для отображения приветственного сообщения
        DisplayWelcome();

        // Вызов PromptUserName для получения имени пользователя
        string userName = PromptUserName();

        // Вызов PromptUserNumber для получения любимого числа пользователя
        int userNumber = PromptUserNumber();

        // Вызов SquareNumber для вычисления квадрата числа пользователя
        int squaredNumber = SquareNumber(userNumber);

        // Вызов DisplayResult для отображения итогового результата
        DisplayResult(userName, squaredNumber);
    }

    // Функция для отображения приветственного сообщения
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Функция для запроса имени пользователя и его возврата
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Функция для запроса любимого числа пользователя
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }

    // Функция для возведения числа в квадрат
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Функция для отображения результата
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}
