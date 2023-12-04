using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic8ConsoleApp
{
    internal class MyList
    {
        private List<int> list;


        #region Методы

        #region FillList с перегрузкой

        /// <summary>
        /// Заполняет массив случайными значениями
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        private void FillList(int size, int min, int max)
        {
            Random rnd = new Random();
            for(int i = 0;i<size;i++)
            {
                list.Add(rnd.Next(min, max));
            }
        }
        private void FillList(int size, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(rnd.Next(0, max));
            }
        }

        #endregion

        #region Print
        /// <summary>
        /// Выводит все элементы списка на экран
        /// </summary>
        public void Print()
        {
            foreach(int num in list)
            {
                Console.WriteLine(num);
            }
        }
        #endregion

        #region MyCompareSort удаляет элементы меньше чем lower и при этом больше bigger
        /// <summary>
        /// Удаляет элементы меньше чем lower и при этом больше bigger
        /// </summary>
        /// <param name="lower">Число, меньше которого должны быть элементы</param>
        /// <param name="bigger">Число, больше которого должны быть элементы</param>
        public void MyCompareSort(int lower, int bigger)
        {
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if ((list[i] < lower) && (list[i] > bigger))
                {
                    list.RemoveAt(i);
                }
            }
        }
        #endregion

        #endregion


        #region Конструкторы
        public MyList(int size, int min, int max)
        {
            list = new List<int>();
            FillList(size, min, max);
        }
        public MyList(int size, int max):
            this(size, 0, max)
        { 
        }
        public MyList(int size):
            this(size, 0, 100)
        {
        }
        #endregion


    }
}
