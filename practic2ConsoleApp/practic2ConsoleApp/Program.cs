using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic2ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fio = "Chigorin Sergey Ivanovich";
            int age = 19; // Да, я знаю, что есть целочисленные типы, отнимающие меньше памяти, но тут нет смысла их использовать
            string email = "some.email@gmail.com";
            int codeMark = 80;
            int mathMark = 74;
            int physicMark = 70;

            int sumMark = codeMark+mathMark+physicMark;
            int middleMark = sumMark/3 ;

            // Да, это ужасно читать, зато красиво смотрится 
            Console.WriteLine($"\n\tИнформация об обучающемся:\n\tФИО: {fio}\n\tВозраст: {age}\n\tEmail: {email}\n\n\tБаллы по предметам:\n\tПрограммирование: \t{codeMark}\n\tМатематика: \t\t{mathMark}\n\tФизика: \t\t{physicMark}\n");
            Console.WriteLine("\tНажми любую кнопку >>>");
            Console.ReadKey();
            Console.WriteLine($"\n\tСумма баллов: \t\t{sumMark}\n\tСреднее: \t\t{middleMark}\n");
        }
    }
}
