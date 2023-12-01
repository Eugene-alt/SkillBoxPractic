using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic7ConsoleApp
{
    struct Worker
    {
        #region Поля
        public bool isEmpty = true; // Определяет, что Worker пустой
        #endregion


        #region Свойства
        /// <summary>
        /// Свойства
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="Data">Дата и время добавления записи</param>
        /// <param name="FIO">Ф.И.О. сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="Height">Рост сотрудника</param>
        /// <param name="DataBirthday">Дата рождения</param>
        /// <param name="PlaceBirthday">Место рождения</param>
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public string FIO { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }
        public DateTime DataBirthday { get; private set; }
        public string PlaceBirthday { get; private set; }
        #endregion


        #region Конструкторы
        public Worker(int Id, string FIO, int Age, int Height, DateTime DataBirthday, string PlaceBirthday)
        {
            this.Id = Id;
            this.Data = DateTime.Now;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.DataBirthday = DataBirthday;
            this.PlaceBirthday = PlaceBirthday;
            this.isEmpty = false;
        }
        public Worker(int Id, string FIO, int Age, int Height, DateTime DataBirthday):
            this(Id, FIO, Age, Height, DataBirthday, "Чихарда")
        {          
        }
        public Worker(int Id, string FIO, int Age, int Height) :
            this(Id, FIO, Age, Height, new DateTime(2000, 1, 1), "Чихарда")
        {
        }
        public Worker(int Id, string FIO, int Age) :
            this(Id, FIO, Age, 100, new DateTime(2000, 1, 1), "Чихарда")
        {
        }
        public Worker(int Id, string FIO) :
            this(Id, FIO, 10, 100, new DateTime(2000, 1, 1), "Чихарда")
        {
        }
        public Worker(int Id) :
            this(Id, "Евгеньев Евгений Евгеньевич", 10, 100, new DateTime(2000, 1, 1), "Чихарда")
        {
        }
        public Worker() :
            this(0, "Евгеньев Евгений Евгеньевич", 10, 100, new DateTime(2000, 1, 1), "Чихарда")
        {
        }
        public Worker(string[] Array)
        {
            this.Id = Convert.ToInt32(Array[0]) ;
            this.Data = DateTime.Parse(Array[1])  ;
            this.FIO = Array[2];
            this.Age = Convert.ToInt32(Array[3]);
            this.Height = Convert.ToInt32(Array[4]);
            this.DataBirthday = DateTime.Parse(Array[5]);
            this.PlaceBirthday = Array[6];
            this.isEmpty = false;
        }
        #endregion


        #region Методы


        /// <summary>
        /// Выводит в консоль информацию о работнике
        /// </summary>
        #region Print
        public void Print()
        {
            if (FIO != null && !isEmpty)
            {
                Console.WriteLine($"ID:{Id}\nData:{Data}\nFIO:{FIO}\nAge:{Age}\nHeight:{Height}\nDataBirthday:{DataBirthday.ToShortDateString()}\nPlaceBirthday:{PlaceBirthday}\n");
            }

        }
        #endregion


        /// <summary>
        /// Устанавливает новый Id сотруднику
        /// </summary>
        /// <param name="Id">Новый Id</param>
        #region SetId
        public void SetId(int Id)
        {
            this.Id = Id;
        }
        #endregion


        #endregion

    }
}
