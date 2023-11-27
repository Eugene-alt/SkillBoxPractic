using System.Linq;
class Program
{
    string alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ";

    static string[] SplitText(string text)
    {
        string sortedString = SortString(text);
        string[] splitedString = sortedString.Split(' ');
        string[] splitedStringWithoutSpace = new string[splitedString.Length];
        int i = 0;
        int j = 0;

        while (i < splitedString.Length)
        {
            if (splitedString[i] != string.Empty)
            {
                splitedStringWithoutSpace[j] = splitedString[i];
                j++;
            }
            i++;
        }
        

        return splitedStringWithoutSpace;
    }

    static string SortString(string text, string alphabet = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ")
    {
        string sortedString = "";
        bool inAlphabet;

        for (int i = 0; i < text.Length; i++) // Проходим по каждому символу строки text
        {
            inAlphabet = false;

            for (int j = 0; j < alphabet.Length; j++) // Для каждого символа проверяем, входит ли он в указанный алфавит
            {
                if (text[i] == alphabet[j])
                {
                    inAlphabet = true; break;
                }
            }
            if (inAlphabet)
            {
                sortedString += text[i]; // Добавляем символ в сортированную строку
            }

        }

        return sortedString.Trim();
    }

    static string[] ReverseText(string text)
    {
        return SplitText(text).Reverse().ToArray();
    }

    static void Main(string[] args)
    {
        string alphabet = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ";
        string userString = "";

        Console.Write("Введи строку, над которой будем издеваться >>> ");
        userString = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Разбили строку по словам и вывели форичем через интерполяцию \"${s} \": ");
        foreach (string s in SplitText(userString))
        {
            Console.Write($"{s} ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Разбили по словам, перевернули и вывели форичем через интерполяцию \"${s} \": ");

        foreach (string s in ReverseText(userString))
        {
            Console.Write($"{s} ");
        }
    }
}