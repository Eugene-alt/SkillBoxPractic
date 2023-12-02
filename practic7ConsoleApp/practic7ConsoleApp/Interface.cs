using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic7ConsoleApp
{
    internal class Interface
    {
        #region Поля
        private string FilePath;        // Путь к файлу репозитория
        private Repository repository;  // Экземпляр репозитория
        private bool isAlive;           // Переменная отвечающая за жизненный цикл интерфейса
        #endregion


        #region Методы

        #region Приватные методы


        #region Greeting
        /// <summary>
        /// Приветствие пользователя
        /// </summary>
        private void Greeting()
        {
            Console.WriteLine("Приветствую в приложении РаботнИк-чай-за-воротник");
            Console.WriteLine("*Представь, что перед тобой современный интерфейс и ты нажимаешь на настоящие кнопки*");
            Console.WriteLine();
        }
        #endregion


        #region GoodBye
        /// <summary>
        /// Прощание с пользователем
        /// </summary>
        private void Goodbye()
        {
            Console.WriteLine("Жаль, что ты уходишь(нет)");
        }
        #endregion


        #region Init
        /// <summary>
        /// Жизненный цикл программы, запускающийся при инициализации класса
        /// </summary>
        private void Init()
        {
            Greeting();
            while (isAlive)
            {
                ActionChoice();
                Console.WriteLine("Продолжить? Д/Н ");
                Console.WriteLine();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.L: // Продолжаем
                        this.isAlive = true;
                        break;

                    case ConsoleKey.Y: // Конец
                        this.isAlive = false;
                        break;

                    default: 
                        Console.WriteLine("Буду считать, что это значит ДА"); 
                        break;
                }
            }
            Goodbye();
        }
        #endregion


        #region ActionChoice
        /// <summary>
        /// Выбор махинации "Представь, что это кнопки"
        /// </summary>
        private void ActionChoice()
        {
            Console.WriteLine(
                $"Выбери действие 1-5:\n" +
                $"1 - Добавить нового сотрудника\n" +
                $"2 - Удалить сотрудника по индексу\n" +
                $"3 - Просмотреть всех сотрудников\n" +
                $"4 - Просмотреть сотрудника по индексу\n" +
                $"5 - Просмотреть информацию всех сотрудников в указанном диапозоне дат");
            Console.WriteLine();
            switch ( Console.ReadKey(true).Key )
            {
                case ConsoleKey.D1:
                    AddWorker();
                    break;

                case ConsoleKey.D2:
                    DeleteWorker();
                    break;

                case ConsoleKey.D3:
                    GetAllWorkers();
                    break;

                case ConsoleKey.D4:
                    GetWorkerById();
                    break;

                case ConsoleKey.D5:
                    GetWorkersBetweenTwoDates();
                    break;

                default: 
                    Console.WriteLine("Я таких команд не знаю");
                    break;
            }
        }
        #endregion


        #endregion


        #region Взаимодействие с репозиторием

        #region AddWorker
        public void AddWorker()
        {
            repository.AddWorker();
            Console.WriteLine();
        }
        #endregion


        #region DeleteWorker
        /// <summary>
        /// Удаляет сотрудника по индексу
        /// </summary>
        public void DeleteWorker()
        {
            int workerIndex;
            string userAnswer;

            Console.Write("Введи индекс сотрудника, которого хочешь удалить >> ");
            userAnswer = Console.ReadLine();
            Console.WriteLine();
            if (!String.IsNullOrEmpty(userAnswer))
            {
                workerIndex = Convert.ToInt32(userAnswer);
                repository.DeleteWorker(workerIndex);
            }
        }
        #endregion


        #region GetAllWorkers
        public void GetAllWorkers()
        {
            foreach(Worker worker in repository.GetAllWorkers())
            {
                worker.Print();
            }
        }
        #endregion


        #region GetWorkerById
        /// <summary>
        /// Печатает информацию о сотруднике по индексу
        /// </summary>
        public void GetWorkerById()
        {
            int workerId;
            string userAnswer;

            Console.Write("Введи индекс сотрудника, которого хотите просмотреть >> ");
            userAnswer = Console.ReadLine();
            Console.WriteLine();
            if (!String.IsNullOrEmpty(userAnswer))
            {
                workerId = Convert.ToInt32(userAnswer);

                if (workerId < 0) 
                { 
                    Console.WriteLine("Не пиши всякую дичь сюда, мы ж люди серьезные как бы");
                    Console.WriteLine();
                }
                else
                {
                    repository.GetWorkerById(workerId).Print();
                }
            }
            else 
            { 
                Console.WriteLine("Не пиши всякую дичь сюда, мы ж люди серьезные как бы"); 
                Console.WriteLine() ;
            }
        }
        #endregion


        #region GetWorkersBetweenTwoDates
        /// <summary>
        /// Печатает информацию о всех сотрудниках в указанном диапозоне дат
        /// </summary>
        public void GetWorkersBetweenTwoDates()
        {
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now;
            string[] dataBuff;
            string userAnswer;

            Console.WriteLine("Введи даты в формате \"dd.mm.yyyy dd.mm.yyyy\", где первая дата - начальная >>");
            userAnswer = Console.ReadLine();

            if (!String.IsNullOrEmpty(userAnswer))
            {
                dataBuff = userAnswer.Split(" ");

                dateFrom = DateTime.Parse(dataBuff[0]);
                dateTo = DateTime.Parse(dataBuff[1]);

                foreach(Worker worker in repository.GetWorkersBetweenTwoDates(dateFrom, dateTo))
                {
                    worker.Print();
                }
            }
            else
            {
                Console.WriteLine("Ты втираешь мне какую-то дичь");
            }

            
        }
        #endregion

        #endregion

        #endregion


        #region Конструктор
        public Interface(string FilePath)
        {
            this.FilePath = FilePath;
            repository = new Repository(this.FilePath);
            this.isAlive = true;
            Init();
        }
        #endregion 
    }
}
