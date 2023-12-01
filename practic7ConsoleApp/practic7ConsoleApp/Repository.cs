using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic7ConsoleApp
{
    class Repository
    {
        #region Поля
        private Worker[] workers;   // Массив с работниками
        private string path;        // Путь к файлу
        private int index;          // Индекс последнего несчитанного работника
        private string[] title;     // Массив для заголовков столбцов (если нужно)
        #endregion

        #region Методы


        #region Resize
        /// <summary>
        /// Расширение массива workers
        /// </summary>
        /// <param name="flag">Определяет необходимость расширения</param>
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }
        #endregion 


        #region Load
        /// <summary>
        /// Подгрузка файла. Заполнение массива работников и определение index
        /// </summary>
        private void Load()
        {
            if(File.Exists(path))
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line != String.Empty)
                        {
                            AddWorkerToWorkers(line.Split("\t").ToArray());
                            index++;
                        }
                    }
                }
            }
            else
            {
                File.Create(path);
            }
        }
        #endregion


        #region GetWorkerById
        /// <summary>
        /// Возвращает работника по индексу
        /// </summary>
        /// <param name="id">Индекс работника, нужного нам</param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            return workers[id];
        }
        #endregion


        #region GetAllWorkers
        /// <summary>
        /// Возвращает массив работников workers
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            return workers;
        }
        #endregion


        #region GetWorkersBetweenTwoDates
        /// <summary>
        /// Возвращает массив работников в определенном диапазоне дат записи
        /// </summary>
        /// <param name="dateFrom">Начало диапозона дат записи</param>
        /// <param name="dateTo">Конец диапозона дат записи</param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] result = new Worker[workers.Length];
            TimeSpan startSpan = dateFrom - new DateTime(2000, 10, 10);
            TimeSpan endSpan = dateTo - new DateTime(2000, 10, 10);

            int i = 0;

            foreach(Worker worker in workers)
            {
                TimeSpan workerSpan = worker.Data - new DateTime(2000, 10, 10);
                if(workerSpan.TotalDays > startSpan.TotalDays && workerSpan.TotalDays < endSpan.TotalDays)
                {
                    result[i] = worker;
                    i++;
                }
            }
            return result;
        }
        #endregion


        #region AddWorkerToWorkers
        /// <summary>
        /// Добавление работника в массив работников workers
        /// </summary>
        /// <param name="array">Строковый массив необходимых данных</param>
        private void AddWorkerToWorkers(string[] array)
        {
            Resize((index >= workers.Length) ? true : false);
            this.workers[index] = new Worker(array);
        }

        /// <summary>
        /// Добавление работника в массив работников workers
        /// </summary>
        /// <param name="array">Строковый массив необходимых данных</param>
        private void AddWorkerToWorkers(Worker worker)
        {
            Resize((index >= workers.Length) ? true : false);
            this.workers[index] = worker;
        }
        #endregion


        #region AddWorker
        /// <summary>
        /// Ввод данных, добавление нового работника в массив и файл
        /// </summary>
        public void AddWorker()
        {
            Resize((index > workers.Length) ? true : false);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                string fio = "NoName";                                                                                                     
                int age = 0;                                                                                                               
                int height = 0;                                                                                                            
                string[] dataBuff = new string[3];                                                                                         
                DateTime bornDay = DateTime.Now;                                                                                           
                string bornPlace = "Street";                                                                                               


                Console.WriteLine("Введите данные");                                                                                        
                DateTime dateTime = DateTime.Now;                                                                                           
                Console.Write("Введите ФИО:");                                                                                              
                fio = Console.ReadLine();                                                                                                   
                Console.Write("Введите ВОЗРАСТ:");                                                                                          
                age = Convert.ToInt32(Console.ReadLine());                                                                                  
                Console.Write("Введите РОСТ:");                                                                                             
                height = Convert.ToInt32(Console.ReadLine());                                                                               
                Console.Write("Введите ДАТУ РОЖДЕНИЯ в формате DD.MM.YYYY:");                                                               
                dataBuff = Console.ReadLine().Split(".");                                                                                   
                if (dataBuff.Length == 3)                                                                                                   
                {                                                                                                                           
                    bornDay = new DateTime(Convert.ToInt32(dataBuff[2]), Convert.ToInt32(dataBuff[1]), Convert.ToInt32(dataBuff[0]));
                    bornDay = bornDay;
                }                                                                                                                           
                Console.Write("Введите МЕСТО РОЖДЕНИЯ:");                                                                                   
                bornPlace = Console.ReadLine();                                                                                             

                AddWorkerToWorkers(new Worker(index, fio, age, height, bornDay, bornPlace));
                sw.WriteLine($"{index}\t{dateTime}\t{fio}\t{age}\t{height}\t{bornDay}\t{bornPlace}");                                       
            }
            index += 1;
        }
        #endregion


        #region DeleteWorker
        /// <summary>
        /// Удаляет работника с указанным индексом
        /// </summary>
        /// <param name="workerIndex">Индекс работника, которого нужно удалить</param>
        public void DeleteWorker(int workerIndex)
        {
            if (workerIndex < this.index)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int i = 0;
                    Worker[] before = new Worker[workerIndex];
                    Worker[] after = new Worker[workers.Length - workerIndex - 1];

                    while (i < workerIndex) // Присваиваем значениям массива before всех работников, стоящих перед удаляемым
                    {
                        before[i] = workers[i];
                        i++;
                    }
                    i++;
                    while (i > workerIndex && i < workers.Length) // Присваиваем значениям массива after всех работников, стоящих после удаляемого
                    {
                        after[i-workerIndex-1] = workers[i];
                        //if (sr.EndOfStream) break;
                        i++;
                    }

                    before.CopyTo(workers, 0);
                    after.CopyTo(workers, before.Length);
                    
                }
                WorkersSave(true);
            }
        }
        #endregion


        #region WorkersSave
        /// <summary>
        /// Записывает в файл всех работников
        /// </summary>
        private void WorkersSave(bool isDelet = false)
        { 
            File.Delete(path);
            File.Create(path).Close();

            using(StreamWriter sw = new StreamWriter(path))
            {
                if (isDelet)
                {
                    index -= 1;
                }
                for(int i = 0; i < index; i++)
                {
                    Worker worker = workers[i];
                    sw.WriteLine($"{i}\t{worker.Data}\t{worker.FIO}\t{worker.Age}\t{worker.Height}\t{worker.DataBirthday}\t{worker.PlaceBirthday}");
                }
            }
        }
        #endregion


        #endregion

        #region Конструктор
        /// <summary>
        /// Создание нового репозитория
        /// </summary>
        /// <param name="Path">Путь к файлу с сотрудниками</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.workers = new Worker[2];
            this.title = new string[7];
            Load();
        }
        #endregion
    }
}
