class Program
{
    static void Main(string[] args)
    {
        string filePath = @"file.csv";

        if(!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        
        //20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва

        if(File.Exists(filePath))
        {
            int maxId = 0;
            Console.WriteLine("запись или чтение?w/r");
            if (Console.ReadKey(true).Key == ConsoleKey.W)
            {
                string[] userData = new string[6];
                using (StreamReader sr = new StreamReader(filePath, true))
                {
                    int i = 0;
                    

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        maxId++;

                        i += 1;
                    }


                }
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    do
                    {
                        string fio = "NoName";                                                                                                     // Объяввление переменных
                        int age = 0;                                                                                                               //
                        int height = 0;                                                                                                            //
                        string[] dataBuff = new string[3];                                                                                         //
                        DateTime bornDay = DateTime.Now;                                                                                           //
                        string bornPlace = "Street";                                                                                               //


                        Console.WriteLine("Введите данные");                                                                                        // Ввод данных
                        DateTime dateTime = DateTime.Now;                                                                                           //
                        Console.Write("Введите ФИО:");                                                                                              //
                        fio = Console.ReadLine();                                                                                                   //
                        Console.Write("Введите ВОЗРАСТ:");                                                                                          //
                        age = Convert.ToInt32(Console.ReadLine());                                                                                  //
                        Console.Write("Введите РОСТ:");                                                                                             //
                        height = Convert.ToInt32(Console.ReadLine());                                                                               //
                        Console.Write("Введите ДАТУ РОЖДЕНИЯ в формате DD.MM.YYYY:");                                                               //
                        dataBuff = Console.ReadLine().Split(".");                                                                                   //
                        if(dataBuff.Length == 3)                                                                                                    //
                        {                                                                                                                           //
                            bornDay = new DateTime(Convert.ToInt32(dataBuff[2]), Convert.ToInt32(dataBuff[1]), Convert.ToInt32(dataBuff[0]));       //
                        }                                                                                                                           //
                        Console.Write("Введите МЕСТО РОЖДЕНИЯ:");                                                                                   //
                        bornPlace = Console.ReadLine();                                                                                             //

                        sw.WriteLine($"{maxId}\t{dateTime}\t{fio}\t{age}\t{height}\t{bornDay}\t{bornPlace}");                                       // Запись данных в файл

                        maxId += 1;

                        Console.WriteLine("Продолжить запись? y/n");
                    } while (Console.ReadKey(true).Key == ConsoleKey.Y) ;
                    
                }
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.R)
            {
                Console.WriteLine();
                using (StreamReader sr2 = new StreamReader(filePath))
                {
                    while (!sr2.EndOfStream)
                    {
                        Console.WriteLine($"{sr2.ReadLine()}");
                    } 
                }
                
            }
        }
        else
        {
            Console.WriteLine("Файла не существует");
        }
        

        

        
    }
}