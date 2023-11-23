
// Задание 1
#region
int userNumExercise1 = 0;

Console.WriteLine("Задание 1");
Console.Write("Введи целое число для проверки на четность >>> ");
userNumExercise1 = int.Parse(Console.ReadLine());
if(userNumExercise1 % 2 == 0)
{
    Console.WriteLine($"Число {userNumExercise1} является четным\n");
}
else
{
    Console.WriteLine($"Число {userNumExercise1} является нечетным\n");
}
#endregion

// Задание 2
#region
int cartCount = 0;
int sum = 0;
string userAnswer;

Console.WriteLine("Задание 2");
Console.Write("Приветствую в игре \"21\", сколько карт у вас на руках? >>> ");
cartCount = int.Parse(Console.ReadLine());
for(int i = 1; i <= cartCount; i++)
{
    Console.Write($"Введи номинал {i} карты >>> ");
    userAnswer = Console.ReadLine();

    switch (userAnswer)
    {
        case "1":
            sum += int.Parse(userAnswer);
            break;
        case "2":
            sum += int.Parse(userAnswer);
            break;
        case "3":
            sum += int.Parse(userAnswer);
            break;
        case "4":
            sum += int.Parse(userAnswer);
            break;
        case "5":
            sum += int.Parse(userAnswer);
            break;
        case "6":
            sum += int.Parse(userAnswer);
            break;
        case "7":
            sum += int.Parse(userAnswer);
            break;
        case "8":
            sum += int.Parse(userAnswer);
            break;
        case "9":
            sum += int.Parse(userAnswer);
            break;
        case "10":
            sum += int.Parse(userAnswer);
            break;
        case "J":
            sum += 10;
            break;
        case "Q":
            sum += 10;
            break;
        case "K":
            sum += 10;
            break;
        case "T":
            sum += 10;
            break;
        default: 
            Console.WriteLine("Ты втираешь мне какую-то дичь");
            i--;
            break;
    }

}
Console.WriteLine($"Вес всех карт составляет: {sum}\n");
#endregion

// Задание 3
#region
int userNumExercise3 = 0;
bool numIsSimple = true;

Console.WriteLine("Задание 3");
Console.Write("Введи целое число для проверки на простоту >>> ");
userNumExercise3 = int.Parse(Console.ReadLine());

for(int i = 2; i < userNumExercise3; i++)
{
    if (userNumExercise3 % i == 0)
    {
        Console.WriteLine($"Число {userNumExercise3} не простое\n");
        numIsSimple = false;
        break;
    }
}
if (numIsSimple)
{
    Console.WriteLine($"Число {userNumExercise3} простое\n");
}

#endregion

// Задание 4
#region
int lengthNums = 0;
int minNum = int.MaxValue;
int userNumExercise4 = 0;

Console.WriteLine("Задание 4");
Console.Write("Введи длину последовательности чисел >>> ");
lengthNums = int.Parse(Console.ReadLine()); 

for (int i = 0; i < lengthNums; i++)
{
    Console.Write($"Введите число {i+1} >>> ");
    userNumExercise4 = int.Parse(Console.ReadLine());
    if (userNumExercise4 < minNum)
    {
        minNum = userNumExercise4;
    }
}

Console.WriteLine($"Минимальным числом в последовательности является {minNum}\n");
#endregion

// Задание 5
#region
int maxRangeNum;
int randomNum = 0;
string userAnswerExercise5;
Random rnd = new Random();

Console.WriteLine("Задание 5");
Console.Write("Введи максимальное число диапозона >>> ");

maxRangeNum = int.Parse(Console.ReadLine());
randomNum = rnd.Next(0, maxRangeNum);

while (true)
{
    Console.Write("Угадай число >>> ");
    userAnswerExercise5 = Console.ReadLine();

    if(userAnswerExercise5 == " ")
    {
        Console.WriteLine("Выход из игры.");
        break;
    }
    else if (int.Parse(userAnswerExercise5) < randomNum)
    {
        Console.WriteLine("Данное число меньше загаданного.");
    }
    else if(int.Parse(userAnswerExercise5) > randomNum)
    {
        Console.WriteLine("Данное число больше загаданного.");
    }
    else 
    { 
        Console.WriteLine($"Ты угадал! Загаданное число {randomNum}");
        break;
    }

}
#endregion