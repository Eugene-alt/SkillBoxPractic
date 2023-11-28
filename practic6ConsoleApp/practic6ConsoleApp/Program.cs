class Program
{
    static void Main(string[] args)
    {
        string filePath = @"file.csv";

        Console.WriteLine("запись или чтение?з/н");

        if(Console.ReadKey(true).Key == ConsoleKey.P)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                string userAnswer;
                do
                {
                    Console.WriteLine("Введите данные следующим образом: ID#ДАТА ВРЕМЯ#Ф И О#ВОЗРАСТ#ДАТАРОЖДЕНИЯ#МЕСТОРОЖДЕНИЯ");
                    foreach (string str in Console.ReadLine().Split('#'))// Записываем данные по своим полям
                    {
                        sw.WriteLine($"{str}\t");
                    }

                    Console.WriteLine("Продолжить запись? д/н");
                } while (Console.ReadKey(true).Key == ConsoleKey.L);
            }
        }
        else if(Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

        

        
    }
}