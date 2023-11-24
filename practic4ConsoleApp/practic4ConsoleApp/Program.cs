
Random rnd = new Random();

int m = 0;
int n  = 0;
int sum = 0;
int lifeTime = 10; // Бактерии живут 10 лет (10 итераций)
int countAlive = 0;
bool life = true;

Console.Write("Введи количество строк m >>> ");
m = int.Parse(Console.ReadLine());
Console.Write("Введи количество столбцов n >>> ");
n =  int.Parse(Console.ReadLine());
Console.WriteLine();


#region Объявление и инициализация всех матриц
int[,] matrix_A = new int[m, n];
int[,] matrix_B = new int[m, n];
int[,] matrix_C = new int[m, n];
bool[,] life_matrix = new bool[10, 10];
#endregion


#region Матрица A (заполнение и отображение)
Console.WriteLine("Матрица A: ");
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        matrix_A[i, j] = rnd.Next(10);
        
        sum += matrix_A[i, j];
        Console.Write($"{ matrix_A[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine();
#endregion 


#region Матрица B (заполнение и отображение)
Console.WriteLine("Матрица B: ");
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        matrix_B[i, j] = rnd.Next(10);
        Console.Write($"{matrix_B[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine();
#endregion


Console.WriteLine($"Сумма всех элементов матрицы A: {sum} ");
Console.WriteLine();


#region Матрица Сложения (заполнение и отображение)
Console.WriteLine("Матрица C(матрица сложения A и B): ");
for (int i = 0;i < m; i++)
{
    for(int j = 0;j < n; j++)
    {
        matrix_C[i, j] = matrix_A[i, j] + matrix_B[i, j];
        Console.Write($"{matrix_C[i, j]} ");
    }
    Console.WriteLine("");
}
Console.WriteLine();
#endregion


#region Матрица Бактерий (заполнение и отображение)
Console.WriteLine("Жизнь бактерий: ");
for (int i = 0; i < life_matrix.GetLength(0); i++)
{
    for (int j = 0; j < life_matrix.GetLength(1); j++)
    {
        life_matrix[i,j] = (rnd.Next(0,2) == 1) ? true : false; // Случайное заполнение 
        countAlive += (life_matrix[i, j]) == true ? 1 : 0; // Подсчет живых бактерий
        if (life_matrix[i, j]) { Console.Write("1 "); }
        else { Console.Write("0 "); }
    }
    Console.WriteLine();
}
Console.WriteLine(countAlive);
#endregion

#region Цикл жизни бактерий
while (life){

    bool[,] life_matrix_copy = new bool[10, 10];
    Array.ConstrainedCopy(life_matrix,0,life_matrix_copy, 0, life_matrix.Length);

    for (int i = 0; i < life_matrix.GetLength(0) ; i++) // Применение правил жизни 1 и 2
    {
        for(int j = 0; j < life_matrix.GetLength(1); j++)
        {
            // Правило 1: возле живой бактерии должно быть минимум 3 живых бактерии, инач она не выживет
            if (!life_matrix_copy[i, j]) {  } // Пропускаем пустые клетки
            else
            {
                
                int aliveAround = 0;
                for (int k = i - 1; k < i + 2; k++) // Начинаем проверку с левой верхней по диагонале от данной бактерии k l
                {
                    for (int l = j - 1; l < j + 2; l++)
                    {
                        if (k < 0 || l < 0 || k > 9 || l > 9 || (k == i && l == j)) { } // Пропускаем клетки, выходящие за матрицу
                        else // Остальные проверяем на наличие жизни
                        {
                            if (life_matrix[k, l])
                            {
                                aliveAround += 1;
                            }
                        }
                    }
                }
                if (aliveAround < 3)
                {
                    life_matrix_copy[i, j] = false;
                    countAlive--;
                }

            }

            // Правило 2: возле живой бактерии больше 5-ти мертвых, она не выдерживает стресс и умирает
            if (!life_matrix_copy[i, j]) {  } // Пропускаем пустые клетки
            else
            {
                int deadAround = 0;
                for (int k = i - 1; k < i + 2; k++) // Начинаем проверку с левой верхней по диагонале от данной бактерии k l
                {
                    for (int l = j - 1; l < j + 2; l++)
                    {
                        if (k < 0 || l < 0 || k > 9 || l > 9 || (k == i && l == j)) { } // Пропускаем клетки, выходящие за матрицу
                        else // Остальные проверяем на отсутствие жизни
                        {
                            if (!life_matrix[k, l])
                            {
                                deadAround += 1;
                            }
                        }
                    }
                }
                if (deadAround >= 5)
                {
                    life_matrix_copy[i, j] = false;
                    countAlive--;
                }

            }

            
        }
        
    }

    if (countAlive <= 30) //Правило 3: когда живых бактерий 30 или меньше, прибегают новые бактерии на подмогу
    {
        int newBact = 6; // Максимальное новое количество бактерий

        while (newBact > 0)
        {
            int m_rnd = rnd.Next(0, life_matrix_copy.GetLength(0));
            int n_rnd = rnd.Next(0, life_matrix_copy.GetLength(1));

            if (!life_matrix_copy[m_rnd, n_rnd])
            {
                life_matrix_copy[m_rnd, n_rnd] = true;
                newBact--;
                countAlive++;
            }
        }
    }
    

    Array.ConstrainedCopy(life_matrix_copy, 0, life_matrix, 0, life_matrix.Length);

    Console.WriteLine("Оставшиеся в живых клетки");
    for (int i = 0; i < life_matrix.GetLength(0); i++) // Вывод оставшихся бактерий
    {
        for (int j = 0; j < life_matrix.GetLength(1); j++)
        {
            if (life_matrix[i, j]) { Console.Write("1 "); }
            else { Console.Write("0 "); }
        }
        Console.WriteLine();
    }
    Console.WriteLine(countAlive);

    lifeTime--;
    if(lifeTime <= 0 || countAlive <= 10)
    {
        break;
    }
}
#endregion