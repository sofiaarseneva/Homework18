using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка корректности скобок в строке!\n\n");
            try
            {
                Console.WriteLine("Введите строку:");
                string str = Console.ReadLine();
                bool result = Check(str);
                if (result)
                    Console.WriteLine("Скобки в строке расставлены корректно!");
                else
                    Console.WriteLine("Скобки в строке расставлены некорректно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex.Message);
            }
            Console.ReadKey();
        }

        static bool Check(string str)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> dict = new Dictionary<char, char>
            {
                {'(',')'},
                {'{','}'},
                {'[',']'},
            };
            foreach (char c in str)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(dict[c]);
                if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != c)
                        return false;
                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;
        }
    }
}
