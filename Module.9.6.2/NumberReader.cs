using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Module._9._6._2
{
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

            if (number != 1 && number != 2) throw new FormatException("Ошибка: неверный ввод.");

            NumberEntered(number, namesList);
        }
        protected virtual void NumberEntered(int number, List<string> namesList)
        {
            NumberEnteredEvent?.Invoke(number, namesList);
        }
    }
}
