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
            Console.WriteLine("запись или чтение?w/r");
            if (Console.ReadKey(true).Key == ConsoleKey.W)
            {
                string[] userData = new string[6];
                string[] data = new string[7];
                using (StreamReader sr = new StreamReader(filePath, true))
                {
                    int i = 0;
                    int maxId = 0;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (i % 7 == 0)
                        {
                            maxId++;
                            
                        }
                        i += 1;
                    }
                    data[0] = (maxId + 1).ToString();


                }
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    do
                    {
                        Console.WriteLine("Введите данные следующим образом: ДАТА ВРЕМЯ#Ф И О#ВОЗРАСТ#РОСТ#ДАТАРОЖДЕНИЯ#МЕСТОРОЖДЕНИЯ");
                        userData = Console.ReadLine().Split('#');
                        userData.CopyTo(data, 1);

                        foreach (string str in data) // Записываем данные по своим полям
                        {
                            sw.WriteLine($"{str}\t");
                        }
                        data[0] =  (Convert.ToInt32(data[0])+1).ToString();

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