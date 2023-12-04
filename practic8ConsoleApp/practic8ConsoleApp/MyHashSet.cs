using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic8ConsoleApp
{
    internal class MyHashSet
    {
        HashSet<int> set;

        #region HashSetLife
        private void HashSetLife()
        {
            int userNum;

            Console.WriteLine("Заполнение множеста-----------------------------------");
            while (true)
            {
                userNum = 0;
                string userAnswer;

                Console.Write("Введите число, которое хотите добавить >>> ");
                userAnswer = Console.ReadLine();
                if (String.IsNullOrEmpty(userAnswer)) { break; }

                userNum = Convert.ToInt32(userAnswer);
                if (set.Contains(userNum))
                {
                    Console.WriteLine("Такое число уже есть. Хтьфу") ;
                }
                else
                {
                    set.Add(userNum);
                }
                
            }
            Console.WriteLine("Заполнение закончено----------------------------------");
            Console.WriteLine() ;

            Console.WriteLine("А теперь смотри, что ты там назаполнял----------------");
            Print();
        }
        #endregion

        #region Print
        private void Print()
        {
            foreach(int num in set)
            {
                Console.WriteLine(num);
            }
        }
        #endregion

        #region Конструктор
        public MyHashSet()
        {
            set = new HashSet<int>();
            HashSetLife();

        }
        #endregion
    }
}
