using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*1.    Создать класс для моделирования счета в банке. Предусмотреть закрытые поля для номера счета, баланса, ФИО владельца. 
            Класс должен быть объявлен как обобщенный. Универсальный параметр T должен определять тип номера счета. Разработать  методы  для  доступа 
            к  данным  –  заполнения  и  чтения.
            Создать  несколько экземпляров класса, параметризированного различными типам. Заполнить его поля и вывести информацию об экземпляре класса на печать.*/

            Console.WriteLine("Введите данные аккаунта №1 с циферным номером карты");
            Console.Write("Номер счета: ");
            Random random = new Random();
            string numberInput1 = Console.ReadLine();
            long number1 = 0;
            string name1=null;
            decimal balance1=0;
            if (long.TryParse(numberInput1, out long result1))
            {
                number1 = result1;
                Console.Write("Ф. И. О. Владелца: ");
                name1 = Console.ReadLine();
                balance1 = Convert.ToDecimal(random.Next(-100000, 100000000)) + Convert.ToDecimal(random.NextDouble());//баланс случайный
            }
            else
            {
                Console.WriteLine("Ошибка: в номере счета допускаются только цифры");
            }
            Account<long> account1 = new Account<long>(number1, name1, balance1);

            Console.WriteLine("Введите данные аккаунта №2 с коротким циферным номером карты");
            Console.Write("Номер счета: ");
            string numberInput2 = Console.ReadLine();
            int number2 = 0;
            string name2 = null;
            decimal balance2 = 0;
            if (int.TryParse(numberInput2, out int result2))
            {
                number2 = result2;
                Console.Write("Ф. И. О. Владелца: ");
                name2 = Console.ReadLine();
                balance2 = Convert.ToDecimal(random.Next(-100000, 100000000)) + Convert.ToDecimal(random.NextDouble());//баланс случайный
            }
            else
            {
                Console.WriteLine("Ошибка: в номере счета допускаются только цифры. Номер карты не может быть больше 2147483647");
            }
            Account<int> account2 = new Account<int>(number2, name2, balance2);

            Console.WriteLine("Введите данные аккаунта №3 с буквенно-циферным номером карты");
            Console.Write("Номер счета: ");
            string number3 = Console.ReadLine();
            Console.Write("Ф. И. О. Владелца: ");
            string name3 = Console.ReadLine();
            decimal balance3 = Convert.ToDecimal(random.Next(-100000, 100000000)) + Convert.ToDecimal(random.NextDouble());
            Account<string> account3 = new Account<string>(number3, name3, balance3);

            Console.Clear();

            account1.Print();
            Console.WriteLine();
            account2.Print();
            Console.WriteLine();
            account3.Print();
            Console.WriteLine();

            Console.WriteLine("\nСводка по всем счетам:");
            Console.WriteLine("Номера счетов:\n     {0}\n     {1}\n     {2}\n", account1.Number, account2.Number, account3.Number);
            Console.WriteLine("ФИО владельцев:\n     {0}\n     {1}\n     {2}\n", account1.Name, account2.Name, account3.Name);
            Console.WriteLine("Общий баланс на счетах: {0:f2}\n", account1.Balance + account2.Balance + account3.Balance);

            Console.ReadKey();
        }
        class Account<T>
        {
            private T number;
            private string name;
            private decimal balance;
            public Account(T Number, string Name, decimal Balance)//метод для заполнения данных.
            {
                number = Number;
                name = Name;
                balance = Balance;
            }

            public T Number { get { return number; } }          //метод для чтения данных. Ввести данные можно только через конструктор.
            public string Name { get { return name; } }
            public decimal Balance { get { return balance; } }

            public void Print()
            {
                Console.WriteLine("Номер счета: {0}\nФ.И.О.Владельца: {1}\nБаланс: {2:f2}", number, name, balance);
            }

        }

    }
    
}
