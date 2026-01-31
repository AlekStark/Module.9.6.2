using System;
using System.Collections.Generic;
using System.Data;
using static System.Console;

class Program
{
    static void Main()
    {
        // Список исходных фамилий
        List<string> names = new List<string>() { "Иванов", "Петров", "Сидоров", "Федоров", "Семенов" };

        WriteLine("Список фамилий:");
        foreach (var name in names)
        {
            WriteLine(name);
        }

        NumberReader numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += ShowNumber;
        try
        {

            numberReader.Read(names);
        }
        catch (FormatException ex)
        {
            WriteLine("Ошибка: введен недопустимый номер выбора.");
        }
        finally
        {
            WriteLine("Работа программы завершена.");
        }
    }

    static void ShowNumber(int number,List<string> namesList)
    {
        switch(number)
        {
            case 1:
                SortNames(namesList, true);   // Сортируем по возрастанию (А-Я)
                break;
            case 2:
                SortNames(namesList, false);   // Сортируем по возрастанию (А-Я)
                break;
        }
    }


    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number, List<string> namesList);  // делегат
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read(List<string> namesList)
        {
            WriteLine("Выберите способ сортировки:");
            WriteLine("1. А-Я");
            WriteLine("2. Я-А");

            int number = Convert.ToInt32(ReadLine());

            if (number != 1 && number != 2 ) throw new FormatException("Ошибка: неверный ввод.");
            
            NumberEntered(number, namesList);
        }
        protected virtual void NumberEntered(int number, List<string> namesList)
        {
            NumberEnteredEvent?.Invoke(number, namesList);
        }
    }

    // Метод для сортировки списка имен
    private static void SortNames(List<string> list, bool ascendingOrder)
    {
        list.Sort((a, b) => ascendingOrder ? a.CompareTo(b) : b.CompareTo(a));
        WriteLine("Отсортированные фамилии:");
        foreach (string name in list)
        {
            WriteLine(name);
        }
    }
}
